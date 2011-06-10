using System;
using ExitGames.Client.Photon;
using System.Collections;

public class Game : IPhotonPeerListener
{

    PhotonPeer _peer;

    public string Status = "disconnected";

    public void DebugReturn(DebugLevel level, string message)
    {
    }

    public void EventAction(byte eventCode, Hashtable photonEvent)
    {
    }

    public void OperationResult(byte opCode, int returnCode, Hashtable returnValues, short invocId)
    {
        var debug = (string)returnValues[(byte)100];

        Status = debug;
    }

    public void PeerStatusCallback(StatusCode statusCode)
    {
        switch (statusCode)
        {
            case StatusCode.Connect:
                {
                    Status = "connected";
                    break;
                }

            case StatusCode.Disconnect:
            case StatusCode.DisconnectByServer:
            case StatusCode.DisconnectByServerLogic:
            case StatusCode.DisconnectByServerUserLimit:
            case StatusCode.TimeoutDisconnect:
                {
                    Status = "disconnected";
                    break;
                }

            default:
                {
                    Status = "unexpected";
                    break;
                }
        }
    }

    public void Initialize(PhotonPeer peer, string serverAddress, string applicationName)
    {
        _peer = peer;
        peer.Connect(serverAddress, applicationName);
    }

    public void Disconnect()
    {
        _peer.Disconnect();
    }

    public void Update()
    {
        _peer.Service();
    }

    public void SendOp()
    {
        _peer.OpCustom(100, new Hashtable(), true, 0);
    }
}
