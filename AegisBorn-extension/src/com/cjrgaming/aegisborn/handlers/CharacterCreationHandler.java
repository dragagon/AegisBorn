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
public class CharacterCreationHandler extends BaseClientRequestHandler {

    @Override
    public void handleClientRequest(User u, ISFSObject data)
    {
        World world = RoomHelper.getWorld(this);
        AegisBornAccount player = world.getPlayer(u);
        if (player.canAddCharacters())
        {
            EntityManager entityManager = ((AegisBornExtension) this.getParentExtension()).getEntityManagerFactory().createEntityManager();
            entityManager.getTransaction().begin();
            AegisBornCharacter character = new AegisBornCharacter(new com.cjrgaming.aegisborn.persistence.AegisBornCharacter());
            character.loadFromSFSObject(data);

            Query q = entityManager.createNamedQuery("AegisBornCharacter.findByName");
            q.setParameter("name", character.getCharacter().getName());
            try
            {
                q.getSingleResult();
                SFSObject err = new SFSObject();
                err.putUtfString("error", "That name is taken.");
                send("error", err, u);

            }
            catch(NoResultException e)
            {
                SfGuardUser guard = entityManager.find(SfGuardUser.class, player.getGuardID());
                character.getCharacter().setUserId(guard);
                // No character with that name, go ahead and create it!
                entityManager.persist(character.getCharacter());
                entityManager.flush();
                entityManager.getTransaction().commit();
                send("characterCreated", new SFSObject(), u);
            }
        }
        else
        {
            SFSObject err = new SFSObject();
            err.putUtfString("error", "No empty character slots.");
            send("error", err, u);
        }
    }
}
