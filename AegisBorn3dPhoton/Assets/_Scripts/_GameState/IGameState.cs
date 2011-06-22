using System.Collections;
using System.Collections.Generic;
using AegisBornCommon;
using ExitGames.Client.Photon;

public interface IGameState
{

    Dictionary<OperationCode, IOperationHandler> Handlers { get; }

    GameState State { get; }

    void OnEventReceive(Game gameLogic, EventCode eventCode, Hashtable eventData);

    void OnOperationReturn(Game gameLogic, OperationCode operationCode, int returnCode, Hashtable returnValues);

    void OnPeerStatusCallback(Game gameLogic, StatusCode returnCode);

    void OnUpdate(Game gameLogic);

    void SendOperation(Game gameLogic, OperationCode operationCode, Hashtable parameter, bool sendReliable, byte channelId, bool encrypt);
}
