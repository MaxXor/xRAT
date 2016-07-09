using System;
using xServer.Core.Networking;

namespace xServer.Core.Packets.ServerPackets
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
