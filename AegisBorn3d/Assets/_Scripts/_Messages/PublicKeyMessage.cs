using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sfs2X;
using Sfs2X.Entities.Data;
using Sfs2X.Util;

class PublicKeyMessage : SendableObject
{
    public PublicKeyMessage(SmartFox conn, EncryptionProvider provider)
        : base(conn, false)
    {
        packetName = "publickey";
        
        data.PutSFSObject("key", new ClientPublicKey().ToSFSObject());
    }

    private PublicKeyMessage()
    {
    }
}
