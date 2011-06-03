using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sfs2X.Entities.Data;
using Sfs2X;
using Sfs2X.Requests;

public abstract class IClientMessage
{
    private SmartFox connection
    {
        get;
        set;
    }

    public bool sendEncrypted
    {
        get;
        set;
    }

    private SFSObject data
    {
        get;
        set;
    }

    protected string packetName;

    private EncryptionProvider provider;

    public IClientMessage(SmartFox conn, bool encrypt)
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

    protected IClientMessage()
    {
    }

    public void PutInt(string key, int item)
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

    public void PutBool(string key, bool item)
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

    public void PutFloat(string key, float item)
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

    public void PutDouble(string key, double item)
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

}