using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace DayZLauncher.LauncherLogic
{
    public class ConfigSetting
    {
        public string Key { get; set; }
        public string Value { get; set; }
        public string Comment { get; set; }
        public bool IsArray { get; set; }
        public List<string> ArrayValues { get; set; } = new List<string>();
    }

    public static class ConfigReader
    {
        /// <summary>
        /// Reads a .cfg file and returns the settings as key-value dictionary
        /// </summary>
        /// <param name="filePath">Path to the .cfg file</param>
        /// <returns>Dictionary with settings</returns>
        public static Dictionary<string, string> ReadConfig(string filePath)
        {
            var config = new Dictionary<string, string>();

            try
            {
                foreach (var line in File.ReadAllLines(filePath))
                {
                    string trimmed = line.Trim();

                    // Skip empty lines and comments
                    if (string.IsNullOrEmpty(trimmed) || trimmed.StartsWith("//"))
                        continue;

                    // Expect: key = "value";
                    var splitIndex = trimmed.IndexOf('=');
                    if (splitIndex > 0 && trimmed.EndsWith(";"))
                    {
                        var key = trimmed.Substring(0, splitIndex).Trim();
                        var value = trimmed.Substring(splitIndex + 1).Trim().Trim('"', ';');

                        config[key] = value;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[ConfigReader] Error reading config: {ex.Message}");
            }

            return config;
        }

        /// <summary>
        /// Reads a DayZ server config file with advanced parsing for arrays and comments
        /// </summary>
        /// <param name="filePath">Path to the config file</param>
        /// <returns>List of config settings with metadata</returns>
        public static async Task<List<ConfigSetting>> ReadServerConfigAsync(string filePath)
        {
            var settings = new List<ConfigSetting>();

            if (!File.Exists(filePath))
                return settings;

            try
            {
                var content = await File.ReadAllTextAsync(filePath);
                var lines = content.Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);

                string currentComment = null;
                ConfigSetting currentArraySetting = null;
                bool inArrayBlock = false;

                foreach (var line in lines)
                {
                    string trimmed = line.Trim();

                    // Handle comments
                    if (trimmed.StartsWith("//"))
                    {
                        // Store for next non-comment line
                        currentComment = trimmed.Substring(2).Trim();
                        continue;
                    }

                    // Handle array end
                    if (inArrayBlock && trimmed.StartsWith("};"))
                    {
                        inArrayBlock = false;
                        if (currentArraySetting != null)
                        {
                            settings.Add(currentArraySetting);
                            currentArraySetting = null;
                        }
                        continue;
                    }

                    // Handle array item
                    if (inArrayBlock)
                    {
                        // Process array item: "value",
                        if (trimmed.StartsWith("\"") && currentArraySetting != null)
                        {
                            var arrayValue = trimmed.Trim('"', ',', ' ');
                            if (!string.IsNullOrEmpty(arrayValue))
                                currentArraySetting.ArrayValues.Add(arrayValue);
                        }
                        continue;
                    }

                    // Handle array start: keyName[] = {
                    if (trimmed.Contains("[]") && trimmed.Contains("{"))
                    {
                        var key = trimmed.Substring(0, trimmed.IndexOf("[]")).Trim();

                        currentArraySetting = new ConfigSetting
                        {
                            Key = key,
                            IsArray = true,
                            Comment = currentComment
                        };

                        inArrayBlock = true;
                        currentComment = null;
                        continue;
                    }

                    // Handle regular key-value: key = "value";
                    var splitIndex = trimmed.IndexOf('=');
                    if (splitIndex > 0 && trimmed.EndsWith(";"))
                    {
                        var key = trimmed.Substring(0, splitIndex).Trim();
                        // Handle different value formats (with or without quotes)
                        var valueWithSemicolon = trimmed.Substring(splitIndex + 1).Trim();
                        var value = valueWithSemicolon.TrimEnd(';').Trim();

                        // Remove quotes if present
                        if (value.StartsWith("\"") && value.EndsWith("\""))
                            value = value.Substring(1, value.Length - 2);

                        var setting = new ConfigSetting
                        {
                            Key = key,
                            Value = value,
                            Comment = currentComment,
                            IsArray = false
                        };

                        settings.Add(setting);
                        currentComment = null;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[ConfigReader] Error reading server config: {ex.Message}");
                // Add a setting to indicate the error
                settings.Add(new ConfigSetting
                {
                    Key = "ERROR",
                    Value = ex.Message,
                    Comment = "Error occurred while parsing config file"
                });
            }

            return settings;
        }

        /// <summary>
        /// Writes settings to a DayZ server config file
        /// </summary>
        /// <param name="filePath">Path to the config file</param>
        /// <param name="settings">List of config settings to write</param>
        /// <returns>True if successful, false otherwise</returns>
        public static async Task<bool> WriteServerConfigAsync(string filePath, List<ConfigSetting> settings)
        {
            try
            {
                var content = new StringBuilder();

                // Add header
                content.AppendLine("// DayZ Server Config");
                content.AppendLine("// Generated by DayZ Server Launcher");
                content.AppendLine($"// {DateTime.Now:yyyy-MM-dd HH:mm:ss}");
                content.AppendLine();

                foreach (var setting in settings)
                {
                    // Add comment if present
                    if (!string.IsNullOrEmpty(setting.Comment))
                    {
                        content.AppendLine($"// {setting.Comment}");
                    }

                    // Handle arrays
                    if (setting.IsArray)
                    {
                        content.AppendLine($"{setting.Key}[] = {{");

                        foreach (var arrayValue in setting.ArrayValues)
                        {
                            content.AppendLine($"\t\"{arrayValue}\",");
                        }

                        content.AppendLine("};");
                    }
                    // Handle regular key-value pairs
                    else
                    {
                        content.AppendLine($"{setting.Key} = \"{setting.Value}\";");
                    }

                    // Add blank line after each setting for readability
                    content.AppendLine();
                }

                // Create directory if it doesn't exist
                var directory = Path.GetDirectoryName(filePath);
                if (!Directory.Exists(directory) && !string.IsNullOrEmpty(directory))
                {
                    Directory.CreateDirectory(directory);
                }

                await File.WriteAllTextAsync(filePath, content.ToString());
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[ConfigReader] Error writing server config: {ex.Message}");
                return false;
            }
        }

        /// <summary>
        /// Creates a backup of a config file
        /// </summary>
        /// <param name="filePath">Path to the config file</param>
        /// <returns>Path to the backup file or null if failed</returns>
        public static string BackupConfigFile(string filePath)
        {
            try
            {
                if (!File.Exists(filePath))
                    return null;

                var backupPath = $"{filePath}.{DateTime.Now:yyyyMMdd_HHmmss}.bak";
                File.Copy(filePath, backupPath, true);
                return backupPath;
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// Extracts specific server settings from a config file
        /// </summary>
        /// <param name="filePath">Path to the config file</param>
        /// <returns>Dictionary with common server settings</returns>
        public static async Task<Dictionary<string, string>> GetServerSettingsAsync(string filePath)
        {
            var result = new Dictionary<string, string>();

            try
            {
                var settings = await ReadServerConfigAsync(filePath);

                // Extract common server settings
                var commonKeys = new[] { "hostname", "password", "passwordAdmin", "maxPlayers", "serverTime", "verifySignatures", "forceSameBuild" };

                foreach (var setting in settings)
                {
                    if (Array.IndexOf(commonKeys, setting.Key) >= 0)
                    {
                        result[setting.Key] = setting.IsArray ? string.Join(", ", setting.ArrayValues) : setting.Value;
                    }
                }
            }
            catch
            {
                // Return empty dictionary on error
            }

            return result;
        }
    }
}