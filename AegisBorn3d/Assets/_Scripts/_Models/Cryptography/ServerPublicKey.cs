using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;
using Sfs2X.Entities.Data;

public class ServerPublicKey : ReceivableObject
{
    public RSAParameters parameters
    {
        get;
        set;
    }

    public ServerPublicKey()
        : base(false)
    {
    }

    public override bool FromSFSObject(Sfs2X.Entities.Data.ISFSObject data)
    {
        // We just pull the data straight out of the packet because we don't have a GetByteArray that works with encryption
        bool retVal = false;
        if (data.ContainsKey("key"))
        {
            ISFSObject publicKeyData = data.GetSFSObject("key");
            var tempParams = new RSAParameters();
            tempParams.Modulus = publicKeyData.GetByteArray("mod").Bytes;
            tempParams.Exponent = publicKeyData.GetByteArray("exp").Bytes;
            parameters = tempParams;
        }
        return retVal;
    }
}
