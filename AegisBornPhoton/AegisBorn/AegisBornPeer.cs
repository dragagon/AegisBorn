using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Photon.SocketServer;

namespace AegisBorn
{
    class AegisBornPeer : IPeer
    {
        private readonly PhotonPeer photonPeer;

        public AegisBornPeer(PhotonPeer photonPeer)
        {
            this.photonPeer = photonPeer;
        }

        public void OnDisconnect()
        {
        }

        public void OnOperationRequest(OperationRequest request)
        {
        }

        public PhotonPeer PhotonPeer
        {
            get { return this.photonPeer; }
        }
    }
}
