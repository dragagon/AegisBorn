using System;
using Sfs2X.Entities.Data;
using System.Security.Cryptography;
using Sfs2X.Util;
using UnityEngine;

public class EncryptionProvider
{
    #region Singleton pattern
    private static EncryptionProvider provider;
    public static EncryptionProvider GetInstance()
    {
		if(provider == null)
		{
			provider = new EncryptionProvider();
		}
		return provider;
    }

    #endregion

    #region Properties
    public bool HasServerPK
    {
        get;
        protected set;
    }

    public RSACryptoServiceProvider ClientRSA
    {
        get;
        set;
    }

    public RSACryptoServiceProvider ServerRSA
    {
        get;
        set;
    }

    #endregion

    private EncryptionProvider()
	{
		ClientRSA = new RSACryptoServiceProvider();
        HasServerPK = false;
	}

    public void SetServerPublicKeyParameters(RSAParameters param)
	{
        HasServerPK = true;
		Debug.Log("Got Server Public Key");
		ServerRSA = new RSACryptoServiceProvider();
		ServerRSA.ImportParameters(param);
	}

    #region Encrypt Functions
    public ByteArray EncryptString(string strToEncrypt)
	{
		System.Text.UTF8Encoding enc = new System.Text.UTF8Encoding();
		return new ByteArray(ServerRSA.Encrypt(enc.GetBytes(strToEncrypt), false));
	}

    public ByteArray EncryptInt(int itemToEncrypt)
    {
        return new ByteArray(ServerRSA.Encrypt(BitConverter.GetBytes(itemToEncrypt), false));
    }

    public ByteArray EncryptLong(long itemToEncrypt)
    {
        return new ByteArray(ServerRSA.Encrypt(BitConverter.GetBytes(itemToEncrypt), false));
    }

    public ByteArray EncryptBool(bool itemToEncrypt)
    {
        return new ByteArray(ServerRSA.Encrypt(BitConverter.GetBytes(itemToEncrypt), false));
    }

    public ByteArray EncryptFloat(float itemToEncrypt)
    {
        return new ByteArray(ServerRSA.Encrypt(BitConverter.GetBytes(itemToEncrypt), false));
    }

    public ByteArray EncryptDouble(double itemToEncrypt)
    {
        return new ByteArray(ServerRSA.Encrypt(BitConverter.GetBytes(itemToEncrypt), false));
    }

    #endregion

    #region Decrypt Functions
    public string DecryptString(ByteArray strTodecrypt)
    {
        return BitConverter.ToString(ClientRSA.Decrypt(strTodecrypt.Bytes, false));
    }

    public int DecryptInt(ByteArray itemToDecrypt)
    {
        return BitConverter.ToInt32(ClientRSA.Decrypt(itemToDecrypt.Bytes, false), 0);
    }

    public long DecryptLong(ByteArray itemToDecrypt)
    {
        return BitConverter.ToInt64(ClientRSA.Decrypt(itemToDecrypt.Bytes, false), 0);
    }

    public bool DecryptBool(ByteArray itemToDecrypt)
    {
        return BitConverter.ToBoolean(ClientRSA.Decrypt(itemToDecrypt.Bytes, false), 0);
    }

    public float DecryptFloat(ByteArray itemToDecrypt)
    {
        return BitConverter.ToSingle(ClientRSA.Decrypt(itemToDecrypt.Bytes, false), 0);
    }

    public double DecryptDouble(ByteArray itemToDecrypt)
    {
        return BitConverter.ToDouble(ClientRSA.Decrypt(itemToDecrypt.Bytes, false), 0);
    }
    #endregion
}

