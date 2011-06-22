using System.Collections;
using AegisBornCommon;

public class ExchangeKeysHandler : IOperationHandler
{
    public override void OnHandleMessage(Game gameLogic, OperationCode operationCode, int returnCode, Hashtable returnValues)
    {
        gameLogic.Peer.DeriveSharedKey((byte[])returnValues[(byte)ParameterCode.ServerKey]);
        gameLogic.NotifyKeysExchanged();
    }
}
