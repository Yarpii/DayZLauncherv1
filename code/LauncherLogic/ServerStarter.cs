using System;
using System.Diagnostics;
using System.IO;
using System.Threading;
using System.Collections.Generic;

namespace DayZLauncher.LauncherLogic
{
    public static class ServerStarter
    {
        private static Process _serverProcess;
        public static event EventHandler<ServerStatusEventArgs> ServerStatusChanged;

        public class ServerStartResult
        {
            public bool Success { get; set; }
            public string ErrorMessage { get; set; }
            public Process ServerProcess { get; set; }
        }

        public class ServerStatusEventArgs : EventArgs
        {
            public bool IsRunning { get; set; }
            public string StatusMessage { get; set; }
            public Process ServerProcess { get; set; }
        }

        /// <summary>
        /// Starts the DayZ server with the specified parameters
        /// </summary>
        /// <param name="serverPath">Path to the server directory</param>
        /// <param name="exeName">Name of the server executable</param>
        /// <param name="arguments">Command line arguments</param>
        /// <returns>Result of the server start operation</returns>
        public static ServerStartResult StartServer(string serverPath, string exeName = "DayZServer_x64.exe", string arguments = "")
        {
            try
            {
                var exePath = Path.Combine(serverPath, exeName);

                if (!Directory.Exists(serverPath))
                {
                    return new ServerStartResult
                    {
                        Success = false,
                        ErrorMessage = $"Server directory does not exist: {serverPath}"
                    };
                }

                if (!File.Exists(exePath))
                {
                    return new ServerStartResult
                    {
                        Success = false,
                        ErrorMessage = $"Server executable not found: {exePath}"
                    };
                }

                var startInfo = new ProcessStartInfo
                {
                    FileName = exePath,
                    WorkingDirectory = serverPath,
                    UseShellExecute = false,
                    CreateNoWindow = false,
                    Arguments = arguments
                };

                _serverProcess = Process.Start(startInfo);

                // Subscribe to process exit event
                if (_serverProcess != null)
                {
                    _serverProcess.EnableRaisingEvents = true;
                    _serverProcess.Exited += (sender, args) =>
                    {
                        OnServerStatusChanged(new ServerStatusEventArgs
                        {
                            IsRunning = false,
                            StatusMessage = "Server process has exited",
                            ServerProcess = null
                        });
                        _serverProcess = null;
                    };

                    // Notify subscribers that server has started
                    OnServerStatusChanged(new ServerStatusEventArgs
                    {
                        IsRunning = true,
                        StatusMessage = "Server started successfully",
                        ServerProcess = _serverProcess
                    });
                }

                return new ServerStartResult
                {
                    Success = true,
                    ServerProcess = _serverProcess
                };
            }
            catch (Exception ex)
            {
                return new ServerStartResult
                {
                    Success = false,
                    ErrorMessage = $"Error starting server:\n{ex.Message}"
                };
            }
        }

        /// <summary>
        /// Stops the server if it's running
        /// </summary>
        /// <param name="forceKill">Force kill the process if true</param>
        /// <returns>True if stopped successfully, false otherwise</returns>
        public static bool StopServer(bool forceKill = true)
        {
            if (_serverProcess != null && !_serverProcess.HasExited)
            {
                try
                {
                    if (forceKill)
                    {
                        _serverProcess.Kill();
                    }
                    else
                    {
                        // Try graceful shutdown first (send close signal)
                        _serverProcess.CloseMainWindow();

                        // Wait for up to 10 seconds for graceful shutdown
                        if (!_serverProcess.WaitForExit(10000))
                        {
                            // If not exited after timeout, force kill
                            _serverProcess.Kill();
                        }
                    }

                    OnServerStatusChanged(new ServerStatusEventArgs
                    {
                        IsRunning = false,
                        StatusMessage = "Server stopped",
                        ServerProcess = null
                    });

                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }

            return false;
        }

        /// <summary>
        /// Gets the running server process, if any
        /// </summary>
        /// <returns>Server process or null if not running</returns>
        public static Process GetServerProcess()
        {
            if (_serverProcess != null && !_serverProcess.HasExited)
                return _serverProcess;

            return null;
        }

        /// <summary>
        /// Checks if the server is running
        /// </summary>
        /// <returns>True if server is running, false otherwise</returns>
        public static bool IsServerRunning()
        {
            return _serverProcess != null && !_serverProcess.HasExited;
        }

        /// <summary>
        /// Gets memory usage of the server in MB
        /// </summary>
        /// <returns>Memory usage in MB or -1 if server is not running</returns>
        public static double GetMemoryUsageMB()
        {
            if (_serverProcess != null && !_serverProcess.HasExited)
            {
                try
                {
                    _serverProcess.Refresh();
                    return Math.Round(_serverProcess.WorkingSet64 / (1024.0 * 1024.0), 2);
                }
                catch
                {
                    return -1;
                }
            }

            return -1;
        }

        /// <summary>
        /// Gets the uptime of the server
        /// </summary>
        /// <returns>TimeSpan representing uptime or TimeSpan.Zero if not running</returns>
        public static TimeSpan GetUptime()
        {
            if (_serverProcess != null && !_serverProcess.HasExited)
            {
                try
                {
                    return DateTime.Now - _serverProcess.StartTime;
                }
                catch
                {
                    return TimeSpan.Zero;
                }
            }

            return TimeSpan.Zero;
        }

        /// <summary>
        /// Tries to find running DayZ server processes
        /// </summary>
        /// <param name="processName">Process name to look for</param>
        /// <returns>List of potential DayZ server processes</returns>
        public static List<Process> FindRunningServers(string processName = "DayZServer_x64")
        {
            var processes = new List<Process>();

            try
            {
                foreach (var process in Process.GetProcessesByName(processName))
                {
                    processes.Add(process);
                }
            }
            catch
            {
                // Return empty list on error
            }

            return processes;
        }

        /// <summary>
        /// Try to attach to an already running server process
        /// </summary>
        /// <param name="process">Process to attach to</param>
        /// <returns>True if successful, false otherwise</returns>
        public static bool AttachToRunningServer(Process process)
        {
            if (process != null && !process.HasExited)
            {
                try
                {
                    _serverProcess = process;
                    _serverProcess.EnableRaisingEvents = true;
                    _serverProcess.Exited += (sender, args) =>
                    {
                        OnServerStatusChanged(new ServerStatusEventArgs
                        {
                            IsRunning = false,
                            StatusMessage = "Server process has exited",
                            ServerProcess = null
                        });
                        _serverProcess = null;
                    };

                    OnServerStatusChanged(new ServerStatusEventArgs
                    {
                        IsRunning = true,
                        StatusMessage = "Attached to running server",
                        ServerProcess = _serverProcess
                    });

                    return true;
                }
                catch
                {
                    return false;
                }
            }

            return false;
        }

        private static void OnServerStatusChanged(ServerStatusEventArgs e)
        {
            ServerStatusChanged?.Invoke(null, e);
        }
    }
}