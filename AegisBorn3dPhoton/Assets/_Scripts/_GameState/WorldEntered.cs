﻿using System;

public class WorldEntered : IGameState
{
    public GameState State
    {
        get { return GameState.WorldEntered; }
    }

    public void OnEventReceive(Game gameLogic, AegisBornCommon.EventCode eventCode, System.Collections.Hashtable eventData)
    {
        throw new NotImplementedException();
    }

    public void OnOperationReturn(Game gameLogic, AegisBornCommon.OperationCode operationCode, int returnCode, System.Collections.Hashtable returnValues)
    {
        throw new NotImplementedException();
    }

    public void OnPeerStatusCallback(Game gameLogic, ExitGames.Client.Photon.StatusCode returnCode)
    {
        throw new NotImplementedException();
    }

    public void OnUpdate(Game gameLogic)
    {
        throw new NotImplementedException();
    }

    public void SendOperation(Game gameLogic, AegisBornCommon.OperationCode operationCode, System.Collections.Hashtable parameter, bool sendReliable, byte channelId)
    {
        throw new NotImplementedException();
    }
}
