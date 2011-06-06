using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class ServerPublicKeyHandler : IMessageHandler
{
    public override void OnHandleMessage(Sfs2X.Entities.Data.ISFSObject data)
    {
        ServerPublicKey pubKey = new ServerPublicKey();
        pubKey.FromSFSObject(data);

        EncryptionProvider.GetInstance().SetServerPublicKeyParameters(pubKey.parameters);
    }
}
