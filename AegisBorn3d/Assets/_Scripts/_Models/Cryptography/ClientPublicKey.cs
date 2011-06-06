using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sfs2X.Entities.Data;
using Sfs2X.Util;

public class ClientPublicKey : SendableObject
{

    public override ISFSObject ToSFSObject()
    {
        EncryptionProvider provider = EncryptionProvider.GetInstance();
        ISFSObject tr = new SFSObject();

        tr.PutByteArray("mod", new ByteArray(provider.ClientRSA.ExportParameters(false).Modulus));
        tr.PutByteArray("exp", new ByteArray(provider.ClientRSA.ExportParameters(false).Exponent));

        return tr;
    }
}
