using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Security.Cryptography;
using System.Text.RegularExpressions;

namespace DayZLauncher.LauncherLogic
{
    public class ModInfo
    {
        public string Name { get; set; }
        public string FolderName { get; set; }
        public string FullPath { get; set; }
        public string Version { get; set; }
        public string Author { get; set; }
        public string Description { get; set; }
        public bool HasValidStructure { get; set; }
        public bool IsSteamWorkshopMod { get; set; }
        public string SteamWorkshopID { get; set; }
        public DateTime LastUpdated { get; set; }
        public long SizeInBytes { get; set; }
        public string SizeFormatted => FormatFileSize(SizeInBytes);

        // Dependencies and load order
        public List<string> Dependencies { get; set; } = new List<string>();
        public int SuggestedLoadOrder { get; set; }

        private string FormatFileSize(long bytes)
        {
            string[] suffixes = { "B", "KB", "MB", "GB", "TB" };
            int counter = 0;
            double size = bytes;

            while (size > 1024 && counter < suffixes.Length - 1)
            {
                size /= 1024;
                counter++;
            }

            return $"{size:0.##} {suffixes[counter]}";
        }
    }

    public static class ModManager
    {
        private static Dictionary<string, ModInfo> _modCache = new Dictionary<string, ModInfo>();

        /// <summary>
        /// Gets a list of mod folder names in the specified directory
        /// </summary>
        public static List<string> GetModFolders(string modsDirectory)
        {
            var mods = new List<string>();

            if (!Directory.Exists(modsDirectory))
                return mods;

            var directories = Directory.GetDirectories(modsDirectory);
            foreach (var dir in directories)
            {
                var folderName = Path.GetFileName(dir);
                if (folderName.StartsWith("@")) // Only mods with @ prefix
                    mods.Add(folderName);
            }

            return mods;
        }

        /// <summary>
        /// Creates a mod launch string for DayZ server
        /// </summary>
        public static string BuildModLaunchString(string modsDirectory, List<string> modList = null)
        {
            if (modList == null || modList.Count == 0)
                return string.Empty;

            // Combine into launch string: -mod=@CF;@Trader;@SomeMod
            return "-mod=" + string.Join(";", modList);
        }

        /// <summary>
        /// Get detailed information about all mods in the directory
        /// </summary>
        public static async Task<List<ModInfo>> GetModInfoList(string modsDirectory)
        {
            var result = new List<ModInfo>();

            if (!Directory.Exists(modsDirectory))
                return result;

            var modFolders = GetModFolders(modsDirectory);

            foreach (var modFolder in modFolders)
            {
                var modInfo = await GetModInfo(Path.Combine(modsDirectory, modFolder));
                if (modInfo != null)
                {
                    result.Add(modInfo);
                }
            }

            return result;
        }

        /// <summary>
        /// Get detailed information about a specific mod
        /// </summary>
        public static async Task<ModInfo> GetModInfo(string modPath)
        {
            // Check cache first
            if (_modCache.ContainsKey(modPath))
                return _modCache[modPath];

            var folderName = Path.GetFileName(modPath);

            if (!Directory.Exists(modPath) || !folderName.StartsWith("@"))
                return null;

            var modInfo = new ModInfo
            {
                FolderName = folderName,
                FullPath = modPath,
                Name = folderName.Substring(1), // Remove @ prefix for display name
                LastUpdated = Directory.GetLastWriteTime(modPath)
            };

            // Calculate mod size
            modInfo.SizeInBytes = await Task.Run(() => CalculateDirectorySize(new DirectoryInfo(modPath)));

            // Check for Steam Workshop ID in folder name
            var workshopMatch = Regex.Match(folderName, @"@(\d+)");
            if (workshopMatch.Success)
            {
                modInfo.IsSteamWorkshopMod = true;
                modInfo.SteamWorkshopID = workshopMatch.Groups[1].Value;
            }

            // Check basic mod structure
            var addonFolder = Path.Combine(modPath, "addons");
            var metaFile = Path.Combine(modPath, "meta.cpp");
            var configFile = Path.Combine(modPath, "config.cpp");

            modInfo.HasValidStructure = Directory.Exists(addonFolder);

            // Try to parse mod meta data
            if (File.Exists(metaFile))
            {
                ParseMetaFile(metaFile, modInfo);
            }
            else if (File.Exists(configFile))
            {
                ParseConfigFile(configFile, modInfo);
            }

            // Try to detect dependencies
            DetectDependencies(modPath, modInfo);

            // Add to cache
            _modCache[modPath] = modInfo;

            return modInfo;
        }

        /// <summary>
        /// Clear the mod info cache
        /// </summary>
        public static void ClearCache()
        {
            _modCache.Clear();
        }

        /// <summary>
        /// Creates a backup of a mod folder
        /// </summary>
        public static async Task<bool> BackupMod(string modPath, string backupDirectory)
        {
            try
            {
                var modFolderName = Path.GetFileName(modPath);
                var timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");
                var backupPath = Path.Combine(backupDirectory, $"{modFolderName}_{timestamp}");

                if (!Directory.Exists(backupDirectory))
                    Directory.CreateDirectory(backupDirectory);

                await Task.Run(() => CopyDirectory(modPath, backupPath, true));
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// Suggests an optimal load order for mods based on dependencies
        /// </summary>
        public static List<string> SuggestLoadOrder(List<ModInfo> mods)
        {
            var result = new List<string>();
            var dependencyGraph = new Dictionary<string, List<string>>();

            // Build dependency graph
            foreach (var mod in mods)
            {
                dependencyGraph[mod.FolderName] = mod.Dependencies;
            }

            // Use topological sort to order mods
            var visited = new HashSet<string>();
            var temp = new HashSet<string>();

            foreach (var mod in mods)
            {
                if (!visited.Contains(mod.FolderName))
                {
                    TopologicalSort(mod.FolderName, dependencyGraph, visited, temp, result);
                }
            }

            // Reverse the result since we want dependencies first
            result.Reverse();
            return result;
        }

        /// <summary>
        /// Verifies the integrity of a mod by checking key files
        /// </summary>
        public static async Task<bool> VerifyModIntegrity(string modPath)
        {
            if (!Directory.Exists(modPath))
                return false;

            var addonFolder = Path.Combine(modPath, "addons");
            if (!Directory.Exists(addonFolder))
                return false;

            // Check for essential files
            var hasKeyFiles = false;
            var hasPboFiles = false;

            await Task.Run(() => {
                // Look for .bikey files in keys folder
                var keysFolder = Path.Combine(modPath, "keys");
                if (Directory.Exists(keysFolder))
                {
                    hasKeyFiles = Directory.GetFiles(keysFolder, "*.bikey").Length > 0;
                }

                // Look for .pbo files in addons folder
                hasPboFiles = Directory.GetFiles(addonFolder, "*.pbo").Length > 0;
            });

            return hasKeyFiles && hasPboFiles;
        }

        /// <summary>
        /// Extracts keys from a mod for server setup
        /// </summary>
        public static async Task<List<string>> ExtractModKeys(string modPath, string destinationFolder)
        {
            var extractedKeys = new List<string>();

            if (!Directory.Exists(modPath) || !Directory.Exists(destinationFolder))
                return extractedKeys;

            var keysFolder = Path.Combine(modPath, "keys");
            if (!Directory.Exists(keysFolder))
                return extractedKeys;

            await Task.Run(() => {
                foreach (var keyFile in Directory.GetFiles(keysFolder, "*.bikey"))
                {
                    var keyFileName = Path.GetFileName(keyFile);
                    var destPath = Path.Combine(destinationFolder, keyFileName);

                    if (!File.Exists(destPath))
                    {
                        File.Copy(keyFile, destPath);
                        extractedKeys.Add(keyFileName);
                    }
                }
            });

            return extractedKeys;
        }

        #region Helper Methods

        private static void ParseMetaFile(string metaFile, ModInfo modInfo)
        {
            try
            {
                var content = File.ReadAllText(metaFile);

                // Extract name
                var nameMatch = Regex.Match(content, @"name\s*=\s*""([^""]+)""");
                if (nameMatch.Success)
                    modInfo.Name = nameMatch.Groups[1].Value;

                // Extract author
                var authorMatch = Regex.Match(content, @"author\s*=\s*""([^""]+)""");
                if (authorMatch.Success)
                    modInfo.Author = authorMatch.Groups[1].Value;

                // Extract version
                var versionMatch = Regex.Match(content, @"version\s*=\s*""([^""]+)""");
                if (versionMatch.Success)
                    modInfo.Version = versionMatch.Groups[1].Value;

                // Extract description
                var descMatch = Regex.Match(content, @"description\s*=\s*""([^""]+)""");
                if (descMatch.Success)
                    modInfo.Description = descMatch.Groups[1].Value;
            }
            catch
            {
                // Ignore parsing errors
            }
        }

        private static void ParseConfigFile(string configFile, ModInfo modInfo)
        {
            try
            {
                var content = File.ReadAllText(configFile);

                // Similar parsing as meta.cpp but config.cpp can have a different structure
                var nameMatch = Regex.Match(content, @"name\s*=\s*""([^""]+)""");
                if (nameMatch.Success)
                    modInfo.Name = nameMatch.Groups[1].Value;
            }
            catch
            {
                // Ignore parsing errors
            }
        }

        private static void DetectDependencies(string modPath, ModInfo modInfo)
        {
            try
            {
                // Look for common patterns that indicate dependencies
                var configFiles = Directory.GetFiles(modPath, "*.cpp", SearchOption.AllDirectories);
                foreach (var file in configFiles)
                {
                    var content = File.ReadAllText(file);

                    // Look for "requiredAddons" section
                    var requiredMatch = Regex.Match(content, @"requiredAddons\[\]\s*=\s*\{([^}]+)\}");
                    if (requiredMatch.Success)
                    {
                        var addons = requiredMatch.Groups[1].Value;
                        var addonList = Regex.Matches(addons, @"""([^""]+)""");

                        foreach (Match match in addonList)
                        {
                            var addon = match.Groups[1].Value;
                            // Convert addon name to possible mod folder name
                            var possibleModName = "@" + addon;
                            if (!modInfo.Dependencies.Contains(possibleModName))
                                modInfo.Dependencies.Add(possibleModName);
                        }
                    }
                }
            }
            catch
            {
                // Ignore errors in dependency detection
            }
        }

        private static void TopologicalSort(string modName, Dictionary<string, List<string>> dependencyGraph,
                                           HashSet<string> visited, HashSet<string> temp, List<string> result)
        {
            if (temp.Contains(modName))
                return; // Detected a cycle, skip

            if (visited.Contains(modName))
                return;

            temp.Add(modName);

            // Process dependencies if they exist
            if (dependencyGraph.ContainsKey(modName))
            {
                foreach (var dependency in dependencyGraph[modName])
                {
                    if (dependencyGraph.ContainsKey(dependency))
                    {
                        TopologicalSort(dependency, dependencyGraph, visited, temp, result);
                    }
                }
            }

            temp.Remove(modName);
            visited.Add(modName);
            result.Add(modName);
        }

        private static long CalculateDirectorySize(DirectoryInfo directory)
        {
            long size = 0;

            // Add file sizes
            var files = directory.GetFiles();
            foreach (var file in files)
            {
                size += file.Length;
            }

            // Add subdirectory sizes
            var subdirectories = directory.GetDirectories();
            foreach (var subdirectory in subdirectories)
            {
                size += CalculateDirectorySize(subdirectory);
            }

            return size;
        }

        private static void CopyDirectory(string sourceDir, string destinationDir, bool recursive)
        {
            // Create destination directory
            Directory.CreateDirectory(destinationDir);

            // Copy files
            foreach (var file in Directory.GetFiles(sourceDir))
            {
                var fileName = Path.GetFileName(file);
                var destFile = Path.Combine(destinationDir, fileName);
                File.Copy(file, destFile, true);
            }

            // Copy subdirectories
            if (recursive)
            {
                foreach (var directory in Directory.GetDirectories(sourceDir))
                {
                    var dirName = Path.GetFileName(directory);
                    var destDir = Path.Combine(destinationDir, dirName);
                    CopyDirectory(directory, destDir, true);
                }
            }
        }

        #endregion
    }
}