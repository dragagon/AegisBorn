using System.Collections;
using System.Collections.Generic;
using AegisBornCommon;
using ExitGames.Client.Photon;

public class Connected : IGameState
{

    public static readonly IGameState Instance = new Connected();

    private readonly Dictionary<OperationCode, IOperationHandler> _handlers;
    public Dictionary<OperationCode, IOperationHandler> Handlers
    {
        get { return _handlers; }
    }

    public GameState State
    {
        get { return GameState.Connected; }
    }

    public Connected()
    {
        _handlers = new Dictionary<OperationCode, IOperationHandler>();
        // Add handlers here
        var keyHandler = new ExchangeKeysHandler();
        _handlers.Add(OperationCode.ExchangeKeysForEncryption, keyHandler);
    }

    public void OnEventReceive(Game gameLogic, EventCode eventCode, Hashtable eventData)
    {
        gameLogic.OnUnexpectedEventReceive(eventCode, eventData);
    }

    public void OnOperationReturn(Game gameLogic, OperationCode operationCode, int returnCode, Hashtable returnValues)
    {
        IOperationHandler handler;

        if (_handlers.TryGetValue(operationCode, out handler))
        {
            handler.HandleMessage(gameLogic, operationCode, returnCode, returnValues);
        }
        else
        {
            gameLogic.OnUnexpectedPhotonReturn(returnCode, operationCode, returnValues);
        }
    }

    public void OnPeerStatusCallback(Game gameLogic, StatusCode returnCode)
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

    public void SendOperation(Game gameLogic, OperationCode operationCode, Hashtable parameter, bool sendReliable, byte channelId, bool encrypt)
    {
        gameLogic.Peer.OpCustom((byte)operationCode, parameter, sendReliable, channelId, encrypt);
    }

}
