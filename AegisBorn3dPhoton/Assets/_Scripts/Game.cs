using System;
using ExitGames.Client.Photon;

public class Game : IPhotonPeerListener
{

    PhotonPeer peer;

    public string status = "disconnected";

    public void DebugReturn(DebugLevel level, string message)
    {
    }

    public void EventAction(byte eventCode, System.Collections.Hashtable photonEvent)
    {
    }

    public void OperationResult(byte opCode, int returnCode, System.Collections.Hashtable returnValues, short invocID)
    {
    }

    public void PeerStatusCallback(StatusCode statusCode)
    {
        switch (statusCode)
        {
            case StatusCode.Connect:
                {
                    status = "connected";
                    break;
                }

            case StatusCode.Disconnect:
            case StatusCode.DisconnectByServer:
            case StatusCode.DisconnectByServerLogic:
            case StatusCode.DisconnectByServerUserLimit:
            case StatusCode.TimeoutDisconnect:
                {
                    status = "disconnected";
                    break;
                }

            default:
                {
                    status = "unexpected";
                    break;
                }
        }
    }

    public void Initialize(PhotonPeer peer, string serverAddress, string applicationName)
    {
        this.peer = peer;
        peer.Connect(serverAddress, applicationName);
    }

    public void Disconnect()
    {
        peer.Disconnect();
    }

    public void Update()
    {
        peer.Service();
    }
}
