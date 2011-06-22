using AegisBornCommon;
using ExitGames.Client.Photon;

public class Connected : IGameState
{

    public static readonly IGameState Instance = new Connected();

    public GameState State
    {
        get { return GameState.Connected; }
    }

    public void OnEventReceive(Game gameLogic, AegisBornCommon.EventCode eventCode, System.Collections.Hashtable eventData)
    {
        gameLogic.OnUnexpectedEventReceive(eventCode, eventData);
    }

    public void OnOperationReturn(Game gameLogic, AegisBornCommon.OperationCode operationCode, int returnCode, System.Collections.Hashtable returnValues)
    {
        gameLogic.OnUnexpectedPhotonReturn(returnCode, operationCode, returnValues);
    }

    public void OnPeerStatusCallback(Game gameLogic, ExitGames.Client.Photon.StatusCode returnCode)
    {
        switch (returnCode)
        {
            case StatusCode.Disconnect:
            case StatusCode.DisconnectByServer:
            case StatusCode.DisconnectByServerLogic:
            case StatusCode.DisconnectByServerUserLimit:
            case StatusCode.TimeoutDisconnect:
                {
                    gameLogic.SetDisconnected(returnCode);
                    break;
                }

            default:
                {
                    gameLogic.OnUnexpectedPhotonReturn((int)returnCode, OperationCode.Nil, null);
                    break;
                }
        }
    }

    public void OnUpdate(Game gameLogic)
    {
        gameLogic.Peer.Service();
    }

    public void SendOperation(Game gameLogic, AegisBornCommon.OperationCode operationCode, System.Collections.Hashtable parameter, bool sendReliable, byte channelId, bool encrypt)
    {
        gameLogic.Peer.OpCustom((byte)operationCode, parameter, sendReliable, channelId, false);
    }
}
