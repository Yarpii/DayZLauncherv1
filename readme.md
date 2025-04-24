# DayZ Server Launcher

A comprehensive Windows application for managing and starting DayZ game servers. This launcher provides an intuitive interface for server configuration, mod management, and server monitoring.

![DayZ Server Launcher](https://github.com/Yarpii/DayZLauncherv1/blob/main/screenshots/Screenshot1.png)
![DayZ Server Launcher](https://github.com/Yarpii/DayZLauncherv1/blob/main/screenshots/Screenshot2.png)
![DayZ Server Launcher](https://github.com/Yarpii/DayZLauncherv1/blob/main/screenshots/Screenshot3.png)
![DayZ Server Launcher](https://github.com/Yarpii/DayZLauncherv1/blob/main/screenshots/Screenshot4.png)

## Features

- **Easy Server Management**: Start/stop your DayZ server with a single click
- **Mod Management**: Select which mods to load with your server from a visual interface
- **Advanced Configuration**: Customize server settings including resource allocation
- **Server Monitoring**: View real-time server status, memory usage, and uptime
- **Launch Parameter Control**: Fine-tune your server launch options
- **Event Logging**: Built-in log viewer to track server events

## System Requirements

- Windows 10 or newer
- .NET 9.0 or higher
- DayZ Server installation

## Installation

1. Download the latest release from the [Releases](https://github.com/yarpii/DayZLauncherv1/releases) section
2. Extract the ZIP file to your preferred location
3. Run `DayZLauncher.exe`

## First-time Setup

1. Launch the application
2. Go to the **Settings** tab
3. Set the following paths:
   - Server Path: Directory containing your DayZ server installation
   - Mods Folder: Directory containing your DayZ mods (usually within the server folder)
   - Server Executable: Name of the server executable (default: `DayZServer_x64.exe`)
   - Config File: Your server configuration file (default: `serverDZ.cfg`)
   - BattlEye Path: Directory containing your BattlEye files
4. Optionally configure custom resource allocation:
   - Enable "Use custom resource settings"
   - Set maximum memory allocation
   - Set CPU count
5. Click **Save Settings**

## Using the Launcher

### Starting the Server

1. Go to the **Main** tab
2. Add any additional launch parameters if needed
3. Click **Start DayZ Server**

### Managing Mods

1. Go to the **Mods** tab
2. Available mods will be displayed on the left
3. Use the **Add >** and **< Remove** buttons to select which mods to use
4. Alternatively, use **Select All** to include all mods or **Clear All** to remove all mods
5. When starting the server, selected mods will be automatically included

### Monitoring

While the server is running, the launcher will show:
- Server running status
- Memory usage
- Uptime

### Logs

The **Log** tab displays launcher events and operations. You can:
- Clear the log with the **Clear** button
- Save the log to a text file with the **Save Log** button

## Project Structure

```
DayZLauncher/
├── DayZLauncher.sln                  <-- Visual Studio Solution
├── DayZLauncher/                     <-- Main project folder
│   ├── DayZLauncher.csproj           <-- Project file
│   ├── Program.cs                    <-- Entry point
│   ├── MainForm.cs                   <-- GUI form code
│   ├── MainForm.Designer.cs          <-- GUI layout code
│   ├── LauncherLogic/                <-- Business logic
│   │   ├── LauncherConfig.cs         <-- Configuration management
│   │   ├── ServerStarter.cs          <-- Server process management
│   │   ├── ConfigReader.cs           <-- Config file parsing
│   │   └── ModManager.cs             <-- Mod management
│   ├── Resources/                    <-- Icons, images, etc.
│   │   └── launcher.ico              <-- Application icon
│   └── config.json                   <-- Configuration storage
```

## Configuration

The launcher uses a `config.json` file to store your settings, which is created automatically when you save your configuration. The structure includes:

```json
{
  "Server": {
    "ServerPath": "C:\\Path\\To\\DayZServer",
    "Executable": "DayZServer_x64.exe",
    "ModsFolder": "C:\\Path\\To\\DayZServer\\Mods",
    "ConfigFile": "serverDZ.cfg",
    "ProfilesFolder": "ServerProfiles",
    "BattlEyePath": "C:\\Path\\To\\DayZServer\\BattlEye"
  },
  "Resources": {
    "UseCustomResources": false,
    "MaxMemoryMB": 8192,
    "CpuCount": 4,
    "NoLogs": false
  },
  "DefaultLaunchParameters": "-config=serverDZ.cfg -profiles=ServerProfiles"
}
```

## Building from Source

1. Clone the repository: `git clone https://github.com/yourusername/DayZServerLauncher.git`
2. Open `DayZLauncher.sln` in Visual Studio 2022 or newer
3. Build the solution (Ctrl+Shift+B)
4. Run the application (F5)

## License

[MIT License](LICENSE)

## Acknowledgments

- DayZ development team for creating an amazing game
- The DayZ modding community for their contributions

---

## Troubleshooting

### Common Issues

**Server won't start**
- Verify your server path is correct
- Ensure the executable name matches the actual file
- Check the log tab for specific error messages

**Mods not loading**
- Confirm your mods folder path is correct
- Make sure mods are properly installed with the `@` prefix
- Check your server logs for mod loading errors

**Performance issues**
- Try adjusting the memory and CPU allocation in settings
- Reduce the number of mods if performance is poor
