using AegisBornCommon;
using Photon.SocketServer;
using Photon.SocketServer.Rpc;
using System.Collections.Generic;
using Photon.SocketServer.Rpc.Reflection;
using System;
using Photon.SocketServer.Security;

namespace AegisBorn
{
    class AegisBornPeer : Peer, IOperationHandler
    {
        private static readonly OperationMethodInfoCache Operations = new OperationMethodInfoCache();

        private readonly OperationDispatcher _dispatcher;

        static AegisBornPeer()
        {
            Operations = new OperationMethodInfoCache();
            try
            {
                Operations.RegisterOperations(typeof(AegisBornPeer));
            }
            catch (Exception e)
            {
                ErrorHandler.OnUnexpectedException(Operations, e);
            }
        }

        public AegisBornPeer(PhotonPeer photonPeer)
            : base(photonPeer)
        {
            _dispatcher = new OperationDispatcher(Operations, this);
            SetCurrentOperationHandler(this);
        }

        public void OnDisconnect(Peer peer)
        {
            SetCurrentOperationHandler(OperationHandlerDisconnected.Instance);
            Dispose();
        }

        public void OnDisconnectByOtherPeer(Peer peer)
        {
            peer.ResponseQueue.EnqueueAction(() => peer.RequestQueue.EnqueueAction(() => peer.PhotonPeer.Disconnect()));
        }

        public OperationResponse OnOperationRequest(Peer peer, OperationRequest operationRequest)
        {
            OperationResponse result;
            if (_dispatcher.DispatchOperationRequest(peer, operationRequest, out result))
            {
                return result;
            }
            return new OperationResponse(operationRequest, 0, "Ok", new Dictionary<short, object> { { 100, "We get signal." } });
        }

        [Operation(OperationCode = (byte)OperationCode.ExchangeKeysForEncryption)]
        public OperationResponse OperationKeyExchange(Peer peer, OperationRequest request)
        {
            var operation = new EstablishSecureCommunicationOperation(request);
            if (operation.IsValid == false)
            {
                return new OperationResponse(request, (int)ErrorCode.InvalidOperationParameter, operation.GetErrorMessage());
            }

            // initialize the peer to support encrytion
            operation.ServerKey = peer.PhotonPeer.InitializeEncryption(operation.ClientKey);

            // publish the servers public key to the client
            return operation.GetOperationResponse(0, "OK");
        }
    }
}
