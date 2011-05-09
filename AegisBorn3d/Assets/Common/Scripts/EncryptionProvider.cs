using System;
using Sfs2X.Entities.Data;
using System.Security.Cryptography;
using Sfs2X.Util;
using UnityEngine;

public class EncryptionProvider
{
	// Singleton pattern
	private static EncryptionProvider provider;
    public static EncryptionProvider GetInstance()
    {
		if(provider == null)
		{
			provider = new EncryptionProvider();
		}
		return provider;
    }

    public delegate void AfterServerPKRecieved();
    public AfterServerPKRecieved afterServerPKRecieved;

    public bool HasServerPK
    {
        get;
        protected set;
    }

	RSACryptoServiceProvider ClientRSA;
	RSACryptoServiceProvider ServerRSA;

	private EncryptionProvider()
	{
		ClientRSA = new RSACryptoServiceProvider();
        HasServerPK = false;
	}
	
	public ISFSObject ClientPublicKeyToSFSObject()
	{
		ISFSObject tr = new SFSObject();
				
		tr.PutByteArray("mod", new ByteArray(ClientRSA.ExportParameters(false).Modulus));
		tr.PutByteArray("exp", new ByteArray(ClientRSA.ExportParameters(false).Exponent));
		
		ISFSObject data = new SFSObject();
		data.PutSFSObject("key", tr);
		
		return data;
	}
	
	public void ServerPublicKeyFromSFSObject(ISFSObject data)
	{
        HasServerPK = true;
		Debug.Log("Got Server Public Key");
		ISFSObject playerData = data.GetSFSObject("key");
		ServerRSA = new RSACryptoServiceProvider();
		RSAParameters param = new RSAParameters();
		param.Modulus = playerData.GetByteArray("mod").Bytes;
		param.Exponent = playerData.GetByteArray("exp").Bytes;
		ServerRSA.ImportParameters(param);

        afterServerPKRecieved();
	}

	public ByteArray EncryptString(string strToEncrypt)
	{
		System.Text.UTF8Encoding enc = new System.Text.UTF8Encoding();
		return new ByteArray(ServerRSA.Encrypt(enc.GetBytes(strToEncrypt), false));
	}

    public ByteArray EncryptInt(int itemToEncrypt)
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
}

