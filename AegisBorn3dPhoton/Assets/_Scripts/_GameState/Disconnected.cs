using AegisBornCommon;

public class Disconnected : IGameState
{

    public static readonly IGameState Instance = new Disconnected();

    public GameState State
    {
        get { return GameState.Disconnected; }
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
        gameLogic.OnUnexpectedPhotonReturn((int)returnCode, OperationCode.Nil, null);
    }

    public void OnUpdate(Game gameLogic)
    {
        // Do nothing on updates because we are disconnected.
    }

    public void SendOperation(Game gameLogic, AegisBornCommon.OperationCode operationCode, System.Collections.Hashtable parameter, bool sendReliable, byte channelId)
    {
        // Do not send operations because we are disconnected.
    }
}
