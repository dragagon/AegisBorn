/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package com.cjrgaming.aegisborn.handlers;

import com.cjrgaming.aegisborn.simulation.World;
import com.cjrgaming.aegisborn.util.RoomHelper;
import com.smartfoxserver.v2.entities.User;
import com.smartfoxserver.v2.entities.data.ISFSObject;
import com.smartfoxserver.v2.extensions.BaseClientRequestHandler;
import javax.crypto.Cipher;

/**
 *
 * @author richach7
 */
public class EncryptedStringHandler extends BaseClientRequestHandler {

    @Override
    public void handleClientRequest(User u, ISFSObject data) {
        try {
            trace("Got a encrypted string");
            ISFSObject keyData = data.getSFSObject("encStr");
            trace("string: " + keyData.getByteArray("str"));

            World world = RoomHelper.getWorld(this);
            Cipher cipher = world.getPlayer(u).GetCipher();
            byte[] decryptData = cipher.doFinal(keyData.getByteArray("str"));

            trace("String: " + new String(decryptData));


        } catch (Exception e) {
            trace(e);
        }
    }
}
