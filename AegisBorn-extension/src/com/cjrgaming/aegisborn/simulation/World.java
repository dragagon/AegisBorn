/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package com.cjrgaming.aegisborn.simulation;

import com.cjrgaming.aegisborn.AegisBornExtension;
import com.smartfoxserver.v2.entities.User;
import com.smartfoxserver.v2.entities.data.ISFSObject;
import java.util.ArrayList;
import java.util.List;

/**
 *
 * @author richach7
 */
public class World {

    private AegisBornExtension extension; // Reference to the server extension
    // Players
    private List<AegisBornAccount> players = new ArrayList<AegisBornAccount>();

    public World(AegisBornExtension extension) {
        this.extension = extension;
    }

    public List<AegisBornAccount> getPlayers() {
        return players;
    }

    // Add new player if he doesn't exist, or resurrect him if he already added
    public boolean addPlayer(User user, ISFSObject data) {
        AegisBornAccount player = getPlayer(user);
        boolean didAddPlayer = false;
        try
        {
            if (player == null)
            {
                    player = new AegisBornAccount(user, data);

                players.add(player);
                extension.send("publickey", player.serverPublicKeyToSFSObject(), user);
                didAddPlayer = true;
            }
            else 
            {
                player.SetPublicKey(data);
            }
        }
        catch(Exception e)
        {
            extension.trace(e);
        }
        finally
        {
            return didAddPlayer;
        }
    }

    // Gets the player corresponding to the specified SFS user
    public AegisBornAccount getPlayer(User u) {
        for (AegisBornAccount player : players) {
            if (player.getSfsUser().getId() == u.getId()) {
                return player;
            }
        }

        return null;
    }

    // When user lefts the room or disconnects - removing him from the players list
    public void userLeft(User user) {
        AegisBornAccount player = this.getPlayer(user);
        if (player == null) {
            return;
        }
        players.remove(player);
    }
}
