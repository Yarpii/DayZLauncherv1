using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using DayZLauncher.LauncherLogic;
using WinFormsTimer = System.Windows.Forms.Timer;

namespace DayZLauncher
{
    public partial class MainForm : Form
    {
        private LauncherConfig config;
        private List<string> availableMods = new List<string>();
        private List<string> selectedMods = new List<string>();
        private Process serverProcess;
        private WinFormsTimer statusTimer;

        public MainForm()
        {
            InitializeComponent();
            LoadConfig();
            InitializeStatusTimer();

            // Register form closing event
            FormClosing += MainForm_FormClosing;
        }

        private void InitializeStatusTimer()
        {
            statusTimer = new WinFormsTimer();
            statusTimer.Interval = 5000; // Check every 5 seconds
            statusTimer.Tick += StatusTimer_Tick;
            statusTimer.Start();
        }

        private void StatusTimer_Tick(object sender, EventArgs e)
        {
            UpdateServerStatus();
        }

        private void UpdateServerStatus()
        {
            if (serverProcess != null && !serverProcess.HasExited)
            {
                lblServerStatus.Text = "Server Status: RUNNING";
                lblServerStatus.ForeColor = Color.Green;
                btnStartServer.Enabled = false;
                btnStopServer.Enabled = true;

                try
                {
                    // Update memory usage
                    serverProcess.Refresh();
                    lblMemoryUsage.Text = $"Memory: {serverProcess.WorkingSet64 / (1024 * 1024)} MB";
                    lblUptime.Text = $"Uptime: {(DateTime.Now - serverProcess.StartTime).ToString(@"hh\:mm\:ss")}";
                }
                catch (Exception)
                {
                    // Process might have exited between checks
                    serverProcess = null;
                    UpdateServerStatus();
                }
            }
            else
            {
                lblServerStatus.Text = "Server Status: OFFLINE";
                lblServerStatus.ForeColor = Color.Red;
                btnStartServer.Enabled = true;
                btnStopServer.Enabled = false;
                lblMemoryUsage.Text = "Memory: N/A";
                lblUptime.Text = "Uptime: 00:00:00";
                serverProcess = null;
            }
        }

        private void LoadConfig()
        {
            config = LauncherConfig.Load();

            // Update UI with configuration
            txtServerPath.Text = config.Server.ServerPath;
            txtModsFolder.Text = config.Server.ModsFolder;
            txtExecutable.Text = string.IsNullOrEmpty(config.Server.Executable) ? "DayZServer_x64.exe" : config.Server.Executable;
            txtConfigFile.Text = string.IsNullOrEmpty(config.Server.ConfigFile) ? "serverDZ.cfg" : config.Server.ConfigFile;
            txtBattlEyePath.Text = config.Server.BattlEyePath;

            // Resource settings
            chkCustomResources.Checked = config.Resources.UseCustomResources;
            numMaxMemory.Value = Math.Max(numMaxMemory.Minimum, Math.Min(numMaxMemory.Maximum, config.Resources.MaxMemoryMB));
            numCpuCount.Value = Math.Max(numCpuCount.Minimum, Math.Min(numCpuCount.Maximum, config.Resources.CpuCount));

            // Enable/disable resource controls based on checkbox
            numMaxMemory.Enabled = chkCustomResources.Checked;
            numCpuCount.Enabled = chkCustomResources.Checked;

            // Load available mods
            RefreshModsList();

            UpdateServerStatus();
        }

        private void RefreshModsList()
        {
            lstAvailableMods.Items.Clear();
            lstSelectedMods.Items.Clear();
            availableMods.Clear();
            selectedMods.Clear();

            if (string.IsNullOrEmpty(config.Server.ModsFolder) || !Directory.Exists(config.Server.ModsFolder))
                return;

            availableMods = ModManager.GetModFolders(config.Server.ModsFolder);

            foreach (var mod in availableMods)
            {
                lstAvailableMods.Items.Add(mod);
            }

            lblModCount.Text = $"Available Mods: {availableMods.Count}";
        }

        private void btnStartServer_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(config.Server.ServerPath))
            {
                MessageBox.Show("No server path configured. Please set the correct path in the Settings tab.",
                    "Configuration Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                tabControl.SelectedTab = tabSettings;
                return;
            }

            Cursor = Cursors.WaitCursor;

            // Build command line parameters
            string parameters = BuildLaunchParameters();

            try
            {
                var exePath = Path.Combine(config.Server.ServerPath, config.Server.Executable);

                var startInfo = new ProcessStartInfo
                {
                    FileName = exePath,
                    WorkingDirectory = config.Server.ServerPath,
                    UseShellExecute = false,
                    CreateNoWindow = false,
                    Arguments = parameters
                };

                serverProcess = Process.Start(startInfo);

                AppendToLog($"Server started at {DateTime.Now}");
                AppendToLog($"Launch parameters: {parameters}");

                UpdateServerStatus();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to start the server:\n\n{ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                AppendToLog($"ERROR: {ex.Message}");
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        private string BuildLaunchParameters()
        {
            string parameters = txtLaunchParameters.Text.Trim();

            // Add config and profiles parameters if not already present
            if (!parameters.Contains("-config="))
            {
                parameters += $" -config={config.Server.ConfigFile}";
            }

            if (!parameters.Contains("-profiles="))
            {
                parameters += $" -profiles={config.Server.ProfilesFolder}";
            }

            // Add custom resource parameters if enabled
            if (config.Resources.UseCustomResources)
            {
                // Add memory limit parameter
                parameters += $" -maxMem={config.Resources.MaxMemoryMB}";

                // Add CPU count parameter
                parameters += $" -cpuCount={config.Resources.CpuCount}";

                // Add noLogs parameter if needed
                if (config.Resources.NoLogs)
                {
                    parameters += " -noLogs";
                }
            }

            // Add mod parameters if there are selected mods
            if (selectedMods.Count > 0)
            {
                string modString = ModManager.BuildModLaunchString(config.Server.ModsFolder, selectedMods);

                if (!string.IsNullOrEmpty(parameters))
                    parameters += " " + modString;
                else
                    parameters = modString;
            }

            return parameters.Trim();
        }

        private void btnStopServer_Click(object sender, EventArgs e)
        {
            if (serverProcess != null && !serverProcess.HasExited)
            {
                try
                {
                    if (MessageBox.Show("Are you sure you want to stop the server?", "Confirm",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        serverProcess.Kill();
                        AppendToLog($"Server stopped at {DateTime.Now}");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Failed to stop the server:\n\n{ex.Message}",
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            UpdateServerStatus();
        }

        private void btnSaveSettings_Click(object sender, EventArgs e)
        {
            config.Server.ServerPath = txtServerPath.Text.Trim();
            config.Server.ModsFolder = txtModsFolder.Text.Trim();
            config.Server.Executable = txtExecutable.Text.Trim();
            config.Server.ConfigFile = txtConfigFile.Text.Trim();
            config.Server.BattlEyePath = txtBattlEyePath.Text.Trim();

            // Resource settings
            config.Resources.UseCustomResources = chkCustomResources.Checked;
            config.Resources.MaxMemoryMB = (int)numMaxMemory.Value;
            config.Resources.CpuCount = (int)numCpuCount.Value;

            config.Save();
            AppendToLog("Configuration saved successfully");
            RefreshModsList();
        }

        private void btnBrowseServer_Click(object sender, EventArgs e)
        {
            using (var dialog = new FolderBrowserDialog())
            {
                dialog.Description = "Select DayZ Server Folder";
                if (!string.IsNullOrEmpty(config.Server.ServerPath) && Directory.Exists(config.Server.ServerPath))
                    dialog.SelectedPath = config.Server.ServerPath;

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    txtServerPath.Text = dialog.SelectedPath;
                }
            }
        }

        private void btnBrowseMods_Click(object sender, EventArgs e)
        {
            using (var dialog = new FolderBrowserDialog())
            {
                dialog.Description = "Select DayZ Mods Folder";
                if (!string.IsNullOrEmpty(config.Server.ModsFolder) && Directory.Exists(config.Server.ModsFolder))
                    dialog.SelectedPath = config.Server.ModsFolder;

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    txtModsFolder.Text = dialog.SelectedPath;
                }
            }
        }

        private void btnAddMod_Click(object sender, EventArgs e)
        {
            if (lstAvailableMods.SelectedItem == null)
                return;

            string selectedMod = lstAvailableMods.SelectedItem.ToString();
            if (!selectedMods.Contains(selectedMod))
            {
                selectedMods.Add(selectedMod);
                lstSelectedMods.Items.Add(selectedMod);
                lblSelectedModCount.Text = $"Selected Mods: {selectedMods.Count}";
            }
        }

        private void btnRemoveMod_Click(object sender, EventArgs e)
        {
            if (lstSelectedMods.SelectedItem == null)
                return;

            string selectedMod = lstSelectedMods.SelectedItem.ToString();
            selectedMods.Remove(selectedMod);
            lstSelectedMods.Items.Remove(selectedMod);
            lblSelectedModCount.Text = $"Selected Mods: {selectedMods.Count}";
        }

        private void btnAddAllMods_Click(object sender, EventArgs e)
        {
            selectedMods.Clear();
            lstSelectedMods.Items.Clear();

            foreach (var mod in availableMods)
            {
                selectedMods.Add(mod);
                lstSelectedMods.Items.Add(mod);
            }

            lblSelectedModCount.Text = $"Selected Mods: {selectedMods.Count}";
        }

        private void btnClearMods_Click(object sender, EventArgs e)
        {
            selectedMods.Clear();
            lstSelectedMods.Items.Clear();
            lblSelectedModCount.Text = $"Selected Mods: {selectedMods.Count}";
        }

        private void btnOpenServerFolder_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(config.Server.ServerPath) || !Directory.Exists(config.Server.ServerPath))
            {
                MessageBox.Show("Server folder path is not set or does not exist.",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Process.Start("explorer.exe", config.Server.ServerPath);
        }

        private void btnOpenModsFolder_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(config.Server.ModsFolder) || !Directory.Exists(config.Server.ModsFolder))
            {
                MessageBox.Show("Mods folder path is not set or does not exist.",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Process.Start("explorer.exe", config.Server.ModsFolder);
        }

        private void btnRefreshMods_Click(object sender, EventArgs e)
        {
            RefreshModsList();
        }

        private void btnClearLog_Click(object sender, EventArgs e)
        {
            txtLog.Clear();
        }

        private void AppendToLog(string message)
        {
            txtLog.AppendText($"[{DateTime.Now:HH:mm:ss}] {message}{Environment.NewLine}");
            // Auto-scroll to the bottom
            txtLog.SelectionStart = txtLog.Text.Length;
            txtLog.ScrollToCaret();
        }

        private void btnSaveLog_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog dialog = new SaveFileDialog())
            {
                dialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
                dialog.DefaultExt = "txt";
                dialog.FileName = $"DayZServerLauncher_Log_{DateTime.Now:yyyy-MM-dd}";

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        File.WriteAllText(dialog.FileName, txtLog.Text);
                        MessageBox.Show($"Log saved to {dialog.FileName}", "Success",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Failed to save log:\n\n{ex.Message}",
                            "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Check if server is running and prompt user
            if (serverProcess != null && !serverProcess.HasExited)
            {
                var result = MessageBox.Show("The DayZ server is still running. Do you want to stop it before closing?",
                    "Server Running", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    try
                    {
                        serverProcess.Kill();
                        AppendToLog("Server stopped due to launcher closing");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Failed to stop the server:\n\n{ex.Message}",
                            "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else if (result == DialogResult.Cancel)
                {
                    e.Cancel = true;
                    return;
                }
            }

            // Stop the status timer
            statusTimer.Stop();
        }

        private void btnBrowseConfig_Click(object sender, EventArgs e)
        {
            using (var dialog = new OpenFileDialog())
            {
                dialog.Title = "Select DayZ Server Configuration File";
                dialog.Filter = "Config Files (*.cfg)|*.cfg|All Files (*.*)|*.*";
                dialog.InitialDirectory = config.Server.ServerPath;

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    txtConfigFile.Text = Path.GetFileName(dialog.FileName);
                }
            }
        }

        private void btnBrowseBattlEye_Click(object sender, EventArgs e)
        {
            using (var dialog = new FolderBrowserDialog())
            {
                dialog.Description = "Select BattlEye Folder";
                if (!string.IsNullOrEmpty(config.Server.BattlEyePath) && Directory.Exists(config.Server.BattlEyePath))
                    dialog.SelectedPath = config.Server.BattlEyePath;
                else if (!string.IsNullOrEmpty(config.Server.ServerPath))
                    dialog.SelectedPath = config.Server.ServerPath;

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    txtBattlEyePath.Text = dialog.SelectedPath;
                }
            }
        }

        private void chkCustomResources_CheckedChanged(object sender, EventArgs e)
        {
            bool enabled = chkCustomResources.Checked;
            numMaxMemory.Enabled = enabled;
            numCpuCount.Enabled = enabled;
        }

    }
}