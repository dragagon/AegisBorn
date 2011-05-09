/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package com.cjrgaming.aegisborn.simulation;

import com.cjrgaming.aegisborn.persistence.SfGuardUser;
import com.smartfoxserver.v2.entities.User;
import com.smartfoxserver.v2.entities.data.ISFSObject;
import com.smartfoxserver.v2.entities.data.SFSObject;
import java.math.BigInteger;
import java.security.InvalidKeyException;
import java.security.KeyFactory;
import java.security.KeyPair;
import java.security.KeyPairGenerator;
import java.security.NoSuchAlgorithmException;
import java.security.PrivateKey;
import java.security.PublicKey;
import java.security.spec.InvalidKeySpecException;
import java.security.spec.RSAPrivateKeySpec;
import java.security.spec.RSAPublicKeySpec;
import javax.crypto.Cipher;
import javax.crypto.NoSuchPaddingException;

/**
 *
 * @author richach7
 */
public class AegisBornAccount {

    private User sfsUser; // SFS user that corresponds to this player
    private PublicKey pubKey;
    private RSAPrivateKeySpec privKey;
    private RSAPublicKeySpec serverPubKey;
    private Cipher cipher;
    private SfGuardUser guardUser;
    public User getSfsUser() {
        return sfsUser;
    }

    public AegisBornAccount(User sfsUser, ISFSObject data) throws NoSuchAlgorithmException, InvalidKeySpecException {
        this.sfsUser = sfsUser;
        SetPublicKey(data);

        try {
            KeyPairGenerator kpg = KeyPairGenerator.getInstance("RSA");
            kpg.initialize(2048);
            KeyPair kp = kpg.genKeyPair();
            KeyFactory fact = KeyFactory.getInstance("RSA");
            serverPubKey = fact.getKeySpec(kp.getPublic(),
                    RSAPublicKeySpec.class);
            privKey = fact.getKeySpec(kp.getPrivate(),
                    RSAPrivateKeySpec.class);
            readyCipher();
        } catch (Exception e) {
            //trace(e);
        }

    }

    public void SetPublicKey(ISFSObject data) throws NoSuchAlgorithmException, InvalidKeySpecException {
                ISFSObject keyData = data.getSFSObject("key");
                RSAPublicKeySpec keySpec = new RSAPublicKeySpec(new BigInteger(keyData.getByteArray("mod")), new BigInteger(keyData.getByteArray("exp")));
                KeyFactory fact = KeyFactory.getInstance("RSA");
                pubKey = fact.generatePublic(keySpec);
    }

    public RSAPublicKeySpec GetServerPubKey()
    {
        return serverPubKey;
    }

    public RSAPrivateKeySpec GetPrivateKey()
    {
        return privKey;
    }

    public PublicKey GetPublicKey()
    {
        return pubKey;
    }

    public Cipher GetCipher()
    {
        return cipher;
    }

    public void setGuardUser(SfGuardUser guard)
    {
        this.guardUser = guard;
    }

    public SfGuardUser getGuardUser()
    {
        return this.guardUser;
    }

    private void readyCipher() throws NoSuchAlgorithmException, NoSuchPaddingException, InvalidKeySpecException, InvalidKeyException {
        cipher = Cipher.getInstance("RSA");
        KeyFactory fact = KeyFactory.getInstance("RSA");
        PrivateKey PK = fact.generatePrivate(GetPrivateKey());
        cipher.init(Cipher.DECRYPT_MODE, PK);
    }
    
    public ISFSObject serverPublicKeyToSFSObject() {
        ISFSObject tr = new SFSObject();

        tr.putByteArray("mod", GetServerPubKey().getModulus().toByteArray());
        tr.putByteArray("exp", GetServerPubKey().getPublicExponent().toByteArray());

        ISFSObject data = new SFSObject();
        data.putSFSObject("key", tr);

        return data;

    }


}
