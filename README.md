# Windows Power Service BSOD
This repository contains two Proof of Concepts for vulnerabilities in the Windows Power Service that lead to a BSOD. The Power Service in Windows loads the `\System32\umpo.dll` module. This contains the RPC interface `6c9b7b96-45a8-4cca-9eb3-e21ccf8b5a89`, which contains two vulnerable procedures. Both calls take among others an `GUID` as parameter. When specifying a `NULL` value for the `GUID` when invoking the RPC call, the Power service crashes and causes an BSOD.

One of the RPC calls, `UmpoRpcReadProfileAlias`, only works on Windows-11 based systems, so Windows 11, Windows server 2025, etc. The other call, `UmpoRpcReadFromUserPowerKey`, was tested successfully against Windows-10 systems as well. Any user can invoke the RPC calls. 

The impact is that an low privileged user is able to DoS a Windows client or server by crashing the Power service that results in an BSOD. The Power service cannot be turned off because it is a core system service responsible for managing power settings, battery status, and power policies. Windows does not allow stopping or disabling it through Services (services.msc) or via command-line tools like `sc config` or `net stop`.

## UmpoRpcReadProfileAlias


https://github.com/user-attachments/assets/3cfd0516-5447-4f56-bdcd-fc155e07be4e



## UmpoRpcReadFromUserPowerKey


https://github.com/user-attachments/assets/b7dd0f4c-fa4f-449d-b5fb-0f395b236093



For more details about these vulnerabilities, check out the blog post: https://incendium.rocks/posts/Unplugging-Power-Service/
