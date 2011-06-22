using System;
using System.Collections;
using System.Collections.Generic;
using AegisBornCommon;
using ExitGames.Client.Photon;

public class Disconnected : IGameState
{

    public static readonly IGameState Instance = new Disconnected();

    public GameState State
    {
        get { return GameState.Disconnected; }
    }

    public Dictionary<OperationCode, IOperationHandler> Handlers
    {
        get { throw new NotImplementedException(); }
    }

    public void OnEventReceive(Game gameLogic, EventCode eventCode, Hashtable eventData)
    {
        gameLogic.OnUnexpectedEventReceive(eventCode, eventData);
    }

    public void OnOperationReturn(Game gameLogic, OperationCode operationCode, int returnCode, Hashtable returnValues)
    {
        gameLogic.OnUnexpectedPhotonReturn(returnCode, operationCode, returnValues);
    }

    public void OnPeerStatusCallback(Game gameLogic, StatusCode returnCode)
    {
        gameLogic.OnUnexpectedPhotonReturn((int)returnCode, OperationCode.Nil, null);
    }

    public void OnUpdate(Game gameLogic)
    {
        // Do nothing on updates because we are disconnected.
    }

    public void SendOperation(Game gameLogic, OperationCode operationCode, Hashtable parameter, bool sendReliable, byte channelId, bool encrypt)
    {
        // Do not send operations because we are disconnected.
    }
}
