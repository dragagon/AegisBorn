/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package com.cjrgaming.aegisborn.handlers;

import com.cjrgaming.aegisborn.AegisBornExtension;
import com.cjrgaming.aegisborn.persistence.SfGuardUser;
import com.cjrgaming.aegisborn.simulation.AegisBornAccount;
import com.cjrgaming.aegisborn.simulation.World;
import com.cjrgaming.aegisborn.util.RoomHelper;
import com.smartfoxserver.v2.entities.User;
import com.smartfoxserver.v2.entities.data.ISFSObject;
import com.smartfoxserver.v2.entities.data.SFSObject;
import com.smartfoxserver.v2.extensions.BaseClientRequestHandler;
import java.math.BigInteger;
import java.security.MessageDigest;
import java.util.List;
import javax.crypto.Cipher;
import javax.persistence.EntityManager;
import javax.persistence.Query;

/**
 *
 * @author Christian
 */
public class DBLoginHandler extends BaseClientRequestHandler {

    @Override
    public void handleClientRequest(User u, ISFSObject data) {
        try {
            // Get the world and add the player.
            World world = RoomHelper.getWorld(this);
            AegisBornAccount player = world.getPlayer(u);
            Cipher cipher = player.GetCipher();
            ISFSObject keyData = data.getSFSObject("login");
            String user = new String(cipher.doFinal(keyData.getByteArray("user")));
            String password = new String(cipher.doFinal(keyData.getByteArray("password")));

            EntityManager entityManager = ((AegisBornExtension)this.getParentExtension()).getEntityManagerFactory().createEntityManager();
            entityManager.getTransaction().begin();
            //Query q = entityManager.createQuery("SELECT s FROM SfGuardUser s WHERE s.username = :username", SfGuardUser.class);
            Query q = entityManager.createNamedQuery("SfGuardUser.findByUsername", SfGuardUser.class);
            q.setParameter("username", user);
            SfGuardUser guard = (SfGuardUser)q.getSingleResult();

            // Execute query
            MessageDigest digest = MessageDigest.getInstance("SHA-1");
            digest.reset();
            digest.update(guard.getSalt().concat(password).getBytes());
            byte[] sha1Password = digest.digest();
            BigInteger bi = new BigInteger(1, sha1Password);
            String result = bi.toString(16);
            if (result.length() % 2 != 0) {
                result = "0" + result;
            }
            trace("Result: " + result);
            if (guard.getPassword().equalsIgnoreCase(result)) {
                player.setGuardUser(guard);
                 send("loginsuccess", new SFSObject(), u);
            } else {
                this.getApi().kickUser(u, null, "Username or Password is incorrect.", 4);
            }
        } catch (Exception e) {
            trace(e);
        }
    }
}
