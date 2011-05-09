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

/**
 *
 * @author Christian
 */
public class PublicKeyHandler extends BaseClientRequestHandler {
    	@Override
	public void handleClientRequest(User u, ISFSObject data) {
                // read the object data.

                // Get the world and add the player.
                World world = RoomHelper.getWorld(this);
		world.addPlayer(u, data);
	}

}
