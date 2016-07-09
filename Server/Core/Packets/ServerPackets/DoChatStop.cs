using System;
using xServer.Core.Networking;

namespace xServer.Core.Packets.ServerPackets
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
