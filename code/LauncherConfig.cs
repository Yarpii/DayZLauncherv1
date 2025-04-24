using System;
using System.IO;
using System.Text.Json;

namespace DayZLauncher.LauncherLogic
{
    public class ServerSettings
    {
        public string ServerPath { get; set; } = string.Empty;
        public string Executable { get; set; } = "DayZServer_x64.exe";
        public string ModsFolder { get; set; } = string.Empty;
        public string ConfigFile { get; set; } = "serverDZ.cfg";
        public string ProfilesFolder { get; set; } = "ServerProfiles";
        public string BattlEyePath { get; set; } = string.Empty;
    }

    public class ResourceSettings
    {
        public bool UseCustomResources { get; set; } = false;
        public int MaxMemoryMB { get; set; } = 8192;
        public int CpuCount { get; set; } = 4;
        public bool NoLogs { get; set; } = false;
    }

    public class LauncherConfig
    {
        public ServerSettings Server { get; set; } = new ServerSettings();
        public ResourceSettings Resources { get; set; } = new ResourceSettings();
        public string DefaultLaunchParameters { get; set; } = "-config=serverDZ.cfg -profiles=ServerProfiles";

        private static string configPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "config.json");

        /// <summary>
        /// Loads the config from config.json
        /// </summary>
        public static LauncherConfig Load()
        {
            try
            {
                if (!File.Exists(configPath))
                    return new LauncherConfig(); // default empty config

                var json = File.ReadAllText(configPath);
                return JsonSerializer.Deserialize<LauncherConfig>(json) ?? new LauncherConfig();
            }
            catch
            {
                return new LauncherConfig();
            }
        }

        /// <summary>
        /// Saves the config to config.json
        /// </summary>
        public void Save()
        {
            var options = new JsonSerializerOptions { WriteIndented = true };
            var json = JsonSerializer.Serialize(this, options);
            File.WriteAllText(configPath, json);
        }
    }
}