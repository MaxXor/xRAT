QuasarRAT
=========
[![Build status](https://ci.appveyor.com/api/projects/status/5857hfy6r1ltb5f2?svg=true)](https://ci.appveyor.com/project/MaxXor/quasarrat) [![Join the chat at https://gitter.im/quasar/QuasarRAT](https://badges.gitter.im/Join%20Chat.svg)](https://gitter.im/quasar/QuasarRAT)

**Free, Open-Source Remote Administration Tool for Windows**

Quasar is a fast and light-weight remote administration tool coded in C#. Providing high stability and an easy-to-use user interface, Quasar is the perfect remote administration solution for you.

Features
---
* TCP network stream (IPv4 & IPv6 support)
* Fast network serialization (NetSerializer)
* Compressed (QuickLZ) & Encrypted (AES-128) communication
* Multi-Threaded
* UPnP Support
* No-Ip.com Support
* Visit Website (hidden & visible)
* Show Messagebox
* Task Manager
* File Manager
* Startup Manager
* Remote Desktop
* Remote Webcam
* Remote Shell
* Remote Chat
* Download & Execute
* Upload & Execute
* System Information
* Computer Commands (Restart, Shutdown, Standby)
* Keylogger (Unicode Support)
* Reverse Proxy (SOCKS5)
* Password Recovery (Common Browsers and FTP Clients)
* Registry Editor

Requirements
---
* .NET Framework 4.0 Client Profile ([Download](https://www.microsoft.com/en-us/download/details.aspx?id=24872))
* Supported Operating Systems (32- and 64-bit)
  * Windows XP SP3
  * Windows Server 2003
  * Windows Vista
  * Windows Server 2008
  * Windows 7
  * Windows Server 2012
  * Windows 8/8.1
  * Windows 10

Compiling
---
Open the project in Visual Studio and click build, or use one of the batch files included in the root directory.

| Batch file        | Description
| ----------------- |:-------------
| build-debug.bat   | Builds the application using the debug configuration (for testing)
| build-release.bat | Builds the application using the release configuration  (for publishing)

Building a client
---
| Build configuration         | Description
| ----------------------------|:-------------
| debug configuration         | The pre-defined [Settings.cs](/Client/Config/Settings.cs) will be used. The client builder does not work in this configuration. You can execute the client directly with the specified settings.
| release configuration       | Use the client builder to build your client otherwise it is going to crash.

ToDo
---
* [Open Issues](https://github.com/quasar/QuasarRAT/issues)

Contributing
---
See [CONTRIBUTING.md](/CONTRIBUTING.md)

License
---
See [LICENSE.md](/LICENSE.md)

Donate
---
Bitcoin: `1M18ncC8yGRXG6vRTfj2hJENLfx46ipw2d`

Credits
---
NetSerializer  
Copyright (c) 2015 Tomi Valkeinen  
https://github.com/tomba/netserializer

ResourceLib  
Copyright (c) 2008-2013 Daniel Doubrovkine, Vestris Inc.  
https://github.com/dblock/resourcelib

GlobalMouseKeyHook  
Copyright (c) 2004-2015 George Mamaladze  
https://github.com/gmamaladze/globalmousekeyhook

Mono.Cecil  
Copyright (c) 2008 - 2015 Jb Evain, Copyright (c) 2008 - 2011 Novell, Inc.  
https://github.com/jbevain/cecil

Mono.Nat  
Copyright (c) 2006 Alan McGovern, Copyright (c) 2007 Ben Motmans  
https://github.com/nterry/Mono.Nat

Thank you!
---
I really appreciate all kinds of feedback and contributions. Thanks for using and supporting Quasar!
