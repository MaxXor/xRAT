using System;
using xServer.Core.Networking;

namespace xServer.Core.Packets.ClientPackets
{
    public enum SearchProgress
    {
        Starting,
        Working,
        Finished
    }

    [Serializable]
    public class SearchDirectoryResponse : IPacket
    {

        public string[] Files { get; set; }

        public string[] Folders { get; set; }

        public long[] FilesSize { get; set; }

        public DateTime[] LastModificationDates { get; set; }

        public DateTime[] CreationDates { get; set; }

        public SearchProgress Progress { get; set; }

        public SearchDirectoryResponse()
        {
        }

        public void Execute(Client client)
        {
            client.Send(this);
        }
    }
}