using System;
using AegisBornCommon;
using ExitGames.Client.Photon;
using System.Collections;

public class Game : IPhotonPeerListener
{

    private readonly Game _instance;

    private PhotonPeer _peer;

    public string Status = "disconnected";

    private IGameListener _listener;

    private IGameState _stateStrategy;


    public delegate void AfterKeysExchanged();
    public AfterKeysExchanged afterKeysExchanged;

    public Game(IGameListener listener)
    {
        _listener = listener;
        _stateStrategy = Disconnected.Instance;
        _instance = this;
    }

    public Game Instance
    {
        get { return _instance; }
    }

    public PhotonPeer Peer
    {
        get { return _peer; }
    }

    public GameState State
    {
        get
        {
            return _stateStrategy.State;
        }
    }

    #region Inherited Interfaces

    #region IPhotonPeerListener

    public void DebugReturn(DebugLevel level, string message)
    {
        if (_listener.IsDebugLogEnabled)
        {
            _listener.LogDebug(this, message);
        }
    }

    public void EventAction(byte eventCode, Hashtable photonEvent)
    {
        _stateStrategy.OnEventReceive(this, (EventCode)eventCode, photonEvent);
    }

    public void OperationResult(byte operationCode, int returnCode, Hashtable returnValues, short invocId)
    {
        try
        {
            _stateStrategy.OnOperationReturn(this, (OperationCode)operationCode, returnCode, returnValues);
        }
        catch (Exception e)
        {
            _listener.LogError(this, e);
        }
    }

    public void PeerStatusCallback(StatusCode returnCode)
    {
        try
        {
            _stateStrategy.OnPeerStatusCallback(this, returnCode);
        }
        catch (Exception e)
        {
            _listener.LogError(this, e);
        }
    }

    #endregion

    #endregion

    public void Initialize(PhotonPeer peer, string serverAddress, string applicationName)
    {
        _peer = peer;
        _stateStrategy = WaitingForConnect.Instance;
        peer.Connect(serverAddress, applicationName);
    }

    public void Disconnect()
    {
        if (Peer != null)
        {
            Peer.Disconnect();
        }
    }

    public void Update()
    {
        _stateStrategy.OnUpdate(this);
    }

    public void SendOp(OperationCode operationCode, Hashtable parameter, bool sendReliable, byte channelId, bool encrypt)
    {
        _stateStrategy.SendOperation(this, operationCode, parameter, sendReliable, channelId, encrypt);
    }

    #region error handling

    public void OnUnexpectedEventReceive(EventCode eventCode, Hashtable eventData)
    {
        _listener.LogError(this, string.Format("unexpected event {0}", eventCode));
    }

    public void OnUnexpectedOperationError(OperationCode operationCode, ErrorCode errorCode, string debugMessage, Hashtable hashtable)
    {
        _listener.LogError(this, string.Format("unexpected operation error {0} from operation {1} in state {2}", errorCode, operationCode, _stateStrategy.State));
    }

    public void OnUnexpectedPhotonReturn(int photonReturnCode, OperationCode operationCode, Hashtable hashtable)
    {

        _listener.LogError(this, string.Format("opcode: {1} - unexpected return {0}", photonReturnCode, operationCode));
    }

    #endregion

    public void SetConnected()
    {
        _stateStrategy = Connected.Instance;
        _listener.OnConnect(this);
        _peer.OpExchangeKeysForEncryption();
    }

    public void NotifyKeysExchanged()
    {
        if (afterKeysExchanged != null)
        {
            afterKeysExchanged();
        }
        _listener.LogInfo(this, "Keys successfully exchanged");
    }

    public void SetDisconnected(StatusCode returnCode)
    {
        _stateStrategy = Disconnected.Instance;
        _listener.OnDisconnect(this, 0);
    }

}
