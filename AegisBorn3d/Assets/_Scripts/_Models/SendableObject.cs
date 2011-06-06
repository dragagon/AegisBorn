using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sfs2X.Entities.Data;
using Sfs2X;
using Sfs2X.Requests;

public class SendableObject : ISendableObject
{
    private SmartFox connection
    {
        get;
        set;
    }

    private bool sendEncrypted
    {
        get;
        set;
    }

    protected ISFSObject data
    {
        get;
        set;
    }

    protected string packetName;

    private EncryptionProvider provider;

    public SendableObject(SmartFox conn, bool encrypt)
    {
        provider = EncryptionProvider.GetInstance();
        sendEncrypted = encrypt;
        connection = conn;
        data = new SFSObject();
    }

    public virtual void Send()
    {
        connection.Send(new ExtensionRequest(packetName, data));
    }

    protected SendableObject()
    {
    }

    public void PutString(ISFSObject data, string key, string item)
    {
        if (sendEncrypted)
        {
            data.PutByteArray(key, provider.EncryptString(item));
        }
        else
        {
            data.PutUtfString(key, item);
        }
    }

    public void PutInt(ISFSObject data, string key, int item)
    {
        if (sendEncrypted)
        {
            data.PutByteArray(key, provider.EncryptInt(item));
        }
        else
        {
            data.PutInt(key, item);
        }
    }

    public void PutLong(ISFSObject data, string key, long item)
    {
        if (sendEncrypted)
        {
            data.PutByteArray(key, provider.EncryptLong(item));
        }
        else
        {
            data.PutLong(key, item);
        }
    }

    public void PutBool(ISFSObject data, string key, bool item)
    {
        if (sendEncrypted)
        {
            data.PutByteArray(key, provider.EncryptBool(item));
        }
        else
        {
            data.PutBool(key, item);
        }
    }

    public void PutFloat(ISFSObject data, string key, float item)
    {
        if (sendEncrypted)
        {
            data.PutByteArray(key, provider.EncryptFloat(item));
        }
        else
        {
            data.PutFloat(key, item);
        }
    }

    public void PutDouble(ISFSObject data, string key, double item)
    {
        if (sendEncrypted)
        {
            data.PutByteArray(key, provider.EncryptDouble(item));
        }
        else
        {
            data.PutDouble(key, item);
        }
    }


    public virtual ISFSObject ToSFSObject()
    {
        return data;
    }
}