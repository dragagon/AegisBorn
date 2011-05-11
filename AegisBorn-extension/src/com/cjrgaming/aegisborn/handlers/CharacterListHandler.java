/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package com.cjrgaming.aegisborn.handlers;

import com.cjrgaming.aegisborn.AegisBornExtension;
import com.cjrgaming.aegisborn.persistence.AegisBornCharacter;
import com.cjrgaming.aegisborn.persistence.SfGuardUser;
import com.cjrgaming.aegisborn.simulation.AegisBornAccount;
import com.cjrgaming.aegisborn.simulation.World;
import com.cjrgaming.aegisborn.util.RoomHelper;
import com.smartfoxserver.v2.entities.User;
import com.smartfoxserver.v2.entities.data.ISFSObject;
import com.smartfoxserver.v2.entities.data.SFSObject;
import com.smartfoxserver.v2.extensions.BaseClientRequestHandler;
import javax.crypto.Cipher;
import javax.persistence.EntityManager;
import javax.persistence.Query;

/**
 *
 * @author richach7
 */
public class CharacterListHandler extends BaseClientRequestHandler {

    @Override
    public void handleClientRequest(User u, ISFSObject data) {
        EntityManager entityManager = ((AegisBornExtension) this.getParentExtension()).getEntityManagerFactory().createEntityManager();
        entityManager.getTransaction().begin();
        try {
            trace("got character list request");
            World world = RoomHelper.getWorld(this);
            AegisBornAccount player = world.getPlayer(u);
                        
            ISFSObject outputObject = new SFSObject();
            SfGuardUser guard = entityManager.find(SfGuardUser.class, player.getGuardID());
            player.setGuardUserValues(guard);
            outputObject.putInt("maxCharacters", player.getMaxCharacters());
            ISFSObject characterList = new SFSObject();
            int i = 0;
            trace("loading characters");
            Cipher cipher = player.GetCipher();
            for (AegisBornCharacter character : guard.getAegisBornCharacterCollection()) {
                com.cjrgaming.aegisborn.models.AegisBornCharacter ABCharacter = new com.cjrgaming.aegisborn.models.AegisBornCharacter(character);
                trace("outputting character" + i);
                characterList.putSFSObject("character" + i++, ABCharacter.createSFSObject());
            }
            outputObject.putSFSObject("characters", characterList);
            send("characterlist", outputObject, u);
        } catch (Exception e) {
            trace(e);
        } finally {
            entityManager.getTransaction().rollback();
        }
    }
}
