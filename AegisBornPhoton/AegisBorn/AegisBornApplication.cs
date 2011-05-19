using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Photon.SocketServer;

namespace AegisBorn
{
    public class AegisBornApplication : Application
    {
        protected override IPeer CreatePeer(PhotonPeer photonPeer, InitRequest initRequest)
        {
            return new AegisBornPeer(photonPeer);
        }

        protected override void Setup()
        {
           
        }

        protected override void TearDown()
        {
            
        }
    }
}
