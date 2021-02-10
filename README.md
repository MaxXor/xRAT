# Quasar

[![Build status](https://ci.appveyor.com/api/projects/status/5857hfy6r1ltb5f2?svg=true)](https://ci.appveyor.com/project/MaxXor/quasar)
[![Downloads](https://img.shields.io/github/downloads/quasar/Quasar/total.svg)](https://github.com/quasar/Quasar/releases)
[![License](https://img.shields.io/github/license/quasar/Quasar.svg)](LICENSE)

**Free, Open-Source Remote Administration Tool for Windows**

Quasar is a fast and light-weight remote administration tool coded in C#. The usage ranges from user support through day-to-day administrative work to employee monitoring. Providing high stability and an easy-to-use user interface, Quasar is the perfect remote administration solution for you.

## Screenshots

![remote-shell](Images/remote-shell.png)

![remote-desktop](Images/remote-desktop.png)

![remote-files](Images/remote-files.png)

## Features
* TCP network stream (IPv4 & IPv6 support)
* Fast network serialization (Protocol Buffers)
* Compressed (QuickLZ) & Encrypted (TLS) communication
* UPnP Support
* Task Manager
* File Manager
* Startup Manager
* Remote Desktop
* Remote Shell
* Remote Execution
* Remote .NET Code Execution
* System Information
* Registry Editor
* System Power Commands (Restart, Shutdown, Standby)
* Keylogger (Unicode Support)
* Reverse Proxy (SOCKS5)
* Password Recovery (Common Browsers and FTP Clients)
* ... and many more!

## Download
* [Latest stable release](https://github.com/quasar/Quasar/releases) (recommended)
* [Latest development snapshot](https://ci.appveyor.com/project/MaxXor/quasar)

## Supported runtimes and operating systems
* .NET Framework 4.5.2 or higher
* Supported operating systems (32- and 64-bit)
  * Windows 10
  * Windows Server 2019
  * Windows Server 2016
  * Windows 8/8.1
  * Windows Server 2012
  * Windows 7
  * Windows Server 2008
  * Windows Vista
* For older systems please use [Quasar version 1.3.0](https://github.com/quasar/Quasar/releases/tag/v1.3.0.0)

## Compiling
Open the project `Quasar.sln` in Visual Studio 2019+ with installed .NET desktop development features and [restore the NuGET packages](https://docs.microsoft.com/en-us/nuget/consume-packages/package-restore). Once all packages are installed the project can be compiled as usual by clicking `Build` at the top or by pressing `F6`. The resulting executables can be found in the `Bin` directory. See below which build configuration to choose from.

## Building a client
| Build configuration         | Usage scenario | Description
| ----------------------------|----------------|--------------
| Debug configuration         | Testing        | The pre-defined [Settings.cs](/Quasar.Client/Config/Settings.cs) will be used, so edit this file before compiling the client. You can execute the client directly with the specified settings.
| Release configuration       | Production     | Start `Quasar.exe` and use the client builder.

## Contributing
See [CONTRIBUTING.md](CONTRIBUTING.md)

## Roadmap
See [ROADMAP.md](ROADMAP.md)

## Documentation
See the [wiki](https://github.com/quasar/Quasar/wiki) for usage instructions and other documentation.

## License
Quasar is distributed under the [MIT License](LICENSE).  
Third-party licenses are located [here](Licenses).

## Thank you!
I really appreciate all kinds of feedback and contributions. Thanks for using and supporting Quasar!
