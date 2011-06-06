using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sfs2X.Entities.Data;

public class ReceivableObject : IReceivableObject
{
    protected bool receiveEncrypted
    {
        get;
        set;
    }

    protected string packetName;

    private EncryptionProvider provider;

    protected ReceivableObject(bool encrypted)
    {
        provider = EncryptionProvider.GetInstance();
        receiveEncrypted = encrypted;
    }

    private ReceivableObject()
    {
    }

    #region Retrieve Data
    public string GetString(ISFSObject data, string key)
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

    public int GetInt(ISFSObject data, string key)
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

    public long GetLong(ISFSObject data, string key)
    {
        if (receiveEncrypted)
        {
            return provider.DecryptLong(data.GetByteArray(key));
        }
        else
        {
            return data.GetLong(key);
        }
    }

    public bool GetBool(ISFSObject data, string key)
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

    public float GetFloat(ISFSObject data, string key)
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

    public double GetDouble(ISFSObject data, string key)
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

    public bool TryGetString(ISFSObject data, string key, out string value)
    {
        if (data.ContainsKey(key))
        {
            value = GetString(data, key);
            return true;
        }
        value = "";
        return false;
    }

    public bool TryGetInt(ISFSObject data, string key, out int value)
    {
        if (data.ContainsKey(key))
        {
            value = GetInt(data, key);
            return true;
        }
        value = 0;
        return false;
    }

    public bool TryGetBool(ISFSObject data, string key, out bool value)
    {
        if (data.ContainsKey(key))
        {
            value = GetBool(data, key);
            return true;
        }
        value = false;
        return false;
    }

    public bool TryGetFloat(ISFSObject data, string key, out float value)
    {
        if (data.ContainsKey(key))
        {
            value = GetFloat(data, key);
            return true;
        }
        value = 0f;
        return false;
    }

    public bool TryGetDouble(ISFSObject data, string key, out double value)
    {
        if (data.ContainsKey(key))
        {
            value = GetDouble(data, key);
            return true;
        }
        value = 0d;
        return false;
    }

    #endregion

    public virtual bool FromSFSObject(ISFSObject data)
    {
        return false;
    }
}
