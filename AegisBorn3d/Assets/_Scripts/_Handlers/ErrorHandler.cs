class ErrorHandler: IMessageHandler
{
    public string errorMessage = "";
    public override void OnHandleMessage(Sfs2X.Entities.Data.ISFSObject data)
    {
        errorMessage = data.GetUtfString("error");
    }
}