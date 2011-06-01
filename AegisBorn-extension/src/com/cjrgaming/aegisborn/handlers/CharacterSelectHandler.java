/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package com.cjrgaming.aegisborn.handlers;

import com.cjrgaming.aegisborn.AegisBornExtension;
import com.cjrgaming.aegisborn.models.AegisBornCharacter;
import com.cjrgaming.aegisborn.persistence.SfGuardUser;
import com.cjrgaming.aegisborn.simulation.AegisBornAccount;
import com.cjrgaming.aegisborn.simulation.World;
import com.cjrgaming.aegisborn.util.RoomHelper;
import com.smartfoxserver.v2.entities.User;
import com.smartfoxserver.v2.entities.data.ISFSObject;
import com.smartfoxserver.v2.entities.data.SFSObject;
import com.smartfoxserver.v2.extensions.BaseClientRequestHandler;
import javax.persistence.EntityManager;
import javax.persistence.NoResultException;
import javax.persistence.Query;

/**
 *
 * @author Christian Richards
 */
public class CharacterSelectHandler extends BaseClientRequestHandler {

    @Override
    public void handleClientRequest(User u, ISFSObject data)
    {
        World world = RoomHelper.getWorld(this);
        AegisBornAccount player = world.getPlayer(u);
        
            EntityManager entityManager = ((AegisBornExtension) this.getParentExtension()).getEntityManagerFactory().createEntityManager();
            entityManager.getTransaction().begin();

            trace("got character select request for: " + data.getLong("characterID"));
            Query q = entityManager.createNamedQuery("AegisBornCharacter.findById");
            q.setParameter("id", data.getLong("characterID"));
            try
            {
                
                AegisBornCharacter character = new AegisBornCharacter((com.cjrgaming.aegisborn.persistence.AegisBornCharacter)q.getSingleResult());
                trace("found character");
                if(character.getCharacter().getUserId().getId() == player.getGuardID())
                {
                    player.setSelectedCharacter(character);
                    // This needs to send all the player data. from armor, to items, to location
                    send("characterSelected", new SFSObject(), u);
                    // Tell everyone the player entered the world use a smaller set of data because they shouldn't know everything the player knows.
                    send("characterEnteredWorld", player.getSelectedCharacter().createSFSObject(), RoomHelper.getCurrentRoom(this).getPlayersList());
                }
                else
                {
                    SFSObject err = new SFSObject();
                    err.putUtfString("error", "That is not a valid character");
                    send("error", err, u);
                }
            }
            catch(NoResultException nre)
            {
                trace(nre);
                SFSObject err = new SFSObject();
                err.putUtfString("error", "That is not a valid character");
                send("error", err, u);
            }
            catch(Exception e)
            {
                trace(e);
                SFSObject err = new SFSObject();
                err.putUtfString("error", "That is not a valid character");
                send("error", err, u);
            }
            trace("leaving handler");
    }
}
