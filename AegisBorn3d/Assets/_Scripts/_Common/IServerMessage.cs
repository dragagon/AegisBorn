using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sfs2X.Entities.Data;
using Sfs2X;
using Sfs2X.Requests;

public abstract class IServerMessage
{
    public bool receiveEncrypted
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

    public IServerMessage(SFSObject data, bool encrypted)
    {
        provider = EncryptionProvider.GetInstance();
        receiveEncrypted = encrypted;
        this.data = data;
    }

    protected IServerMessage()
    {
    }

    public string GetString(string key)
    {
        if (receiveEncrypted)
        {
            return provider.DecryptString(data.GetByteArray(key));
        }
        else
        {
            return data.GetUtfString(key);
        }
    }

    public int GetInt(string key)
    {
        if (receiveEncrypted)
        {
            return provider.DecryptInt(data.GetByteArray(key));
        }
        else
        {
            return data.GetInt(key);
        }
    }

    public bool GetBool(string key)
    {
        if (receiveEncrypted)
        {
            return provider.DecryptBool(data.GetByteArray(key));
        }
        else
        {
            return data.GetBool(key);
        }
    }

    public float GetFloat(string key)
    {
        if (receiveEncrypted)
        {
            return provider.DecryptFloat(data.GetByteArray(key));
        }
        else
        {
            return data.GetFloat(key);
        }
    }

    public double GetDouble(string key)
    {
        if (receiveEncrypted)
        {
            return provider.DecryptDouble(data.GetByteArray(key));
        }
        else
        {
            return data.GetDouble(key);
        }
    }

    public bool TryGetString(string key, out string value)
    {
        if (data.ContainsKey(key))
        {
            value = GetString(key);
            return true;
        }
        value = "";
        return false;
    }

    public bool TryGetInt(string key, out int value)
    {
        if (data.ContainsKey(key))
        {
            value = GetInt(key);
            return true;
        }
        value = 0;
        return false;
    }

    public bool TryGetBool(string key, out bool value)
    {
        if (data.ContainsKey(key))
        {
            value = GetBool(key);
            return true;
        }
        value = false;
        return false;
    }

    public bool TryGetFloat(string key, out float value)
    {
        if (data.ContainsKey(key))
        {
            value = GetFloat(key);
            return true;
        }
        value = 0f;
        return false;
    }

    public bool TryGetDouble(string key, out double value)
    {
        if (data.ContainsKey(key))
        {
            value = GetDouble(key);
            return true;
        }
        value = 0d;
        return false;
    }

}