using System;
using xClient.Core.Networking;

namespace xClient.Core.Packets.ServerPackets
{
    [Serializable]
    public class DoChatStop : IPacket
    {
        public DoChatStop()
        {
        }

        public void Execute(Client client)
        {
            client.Send(this);
        }
    }
}
