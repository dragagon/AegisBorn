using Photon.SocketServer;
using Photon.SocketServer.Rpc;

namespace AegisBorn
{
    class AegisBornPeer : Peer, IOperationHandler
    {
        public AegisBornPeer(PhotonPeer photonPeer)
            : base(photonPeer)
        {
            this.SetCurrentOperationHandler(this);
        }

        public void OnDisconnect(Peer peer)
        {
            this.SetCurrentOperationHandler(OperationHandlerDisconnected.Instance);
            this.Dispose();
        }

        public void OnDisconnectByOtherPeer(Peer peer)
        {
            peer.ResponseQueue.EnqueueAction(() => peer.RequestQueue.EnqueueAction(() => peer.PhotonPeer.Disconnect()));
        }

        public OperationResponse OnOperationRequest(Peer peer, OperationRequest operationRequest)
        {
            return new OperationResponse(operationRequest, 0, "Ok");
        }
    }
}
