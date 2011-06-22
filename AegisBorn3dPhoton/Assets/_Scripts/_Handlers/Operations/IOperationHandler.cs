using System.Collections;
using AegisBornCommon;

public abstract class IOperationHandler
{
    public delegate void BeforeMessageRecieved();
    public BeforeMessageRecieved beforeMessageRecieved;

    public delegate void AfterMessageRecieved();
    public AfterMessageRecieved afterMessageRecieved;

    public void HandleMessage(Game gameLogic, OperationCode operationCode, int returnCode, Hashtable returnValues)
    {
        if (beforeMessageRecieved != null)
        {
            beforeMessageRecieved();
        }
        OnHandleMessage(gameLogic, operationCode, returnCode, returnValues);
        if (afterMessageRecieved != null)
        {
            afterMessageRecieved();
        }
    }

    public abstract void OnHandleMessage(Game gameLogic, OperationCode operationCode, int returnCode, Hashtable returnValues);
}
