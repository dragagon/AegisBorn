/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */

package com.cjrgaming.aegisborn.handlers;

import com.cjrgaming.aegisborn.persistence.AegisBornCharacter;
import com.cjrgaming.aegisborn.simulation.AegisBornAccount;
import com.cjrgaming.aegisborn.simulation.World;
import com.cjrgaming.aegisborn.util.RoomHelper;
import com.smartfoxserver.v2.entities.User;
import com.smartfoxserver.v2.entities.data.ISFSObject;
import com.smartfoxserver.v2.entities.data.SFSObject;
import com.smartfoxserver.v2.extensions.BaseClientRequestHandler;
import java.io.IOException;
import java.io.InputStream;
import java.util.Properties;

/**
 *
 * @author richach7
 */
public class CharacterListHandler  extends BaseClientRequestHandler {

    @Override
    public void handleClientRequest(User u, ISFSObject data) {
        try {
            trace("got character list request");
                        World world = RoomHelper.getWorld(this);
            AegisBornAccount player = world.getPlayer(u);
            

            trace("loading properties");
            Properties serverProps = new Properties();
            try
            {
                InputStream in = this.getClass().getResourceAsStream("/com/cjrgaming/aegisborn/ServerConfig.properties");
                serverProps.load(in);
            }
            catch(IOException e)
            {
                trace(e);
            }

            trace("loaded properties");
            ISFSObject outputObject = new SFSObject();
            outputObject.putInt("maxCharacters", Integer.parseInt(serverProps.getProperty("MaxCharacters", "0")));
            ISFSObject characterList = new SFSObject();
            int i = 0;
            trace("loading characters");
            for(AegisBornCharacter character : player.getGuardUser().getAegisBornCharacterCollection())
            {
                com.cjrgaming.aegisborn.models.AegisBornCharacter ABCharacter = new com.cjrgaming.aegisborn.models.AegisBornCharacter(character);
                trace("outputting character"+i);
                characterList.putSFSObject("character"+i++, ABCharacter.createSFSObject());
            }
            outputObject.putSFSObject("characters", characterList);
            send("characterlist", outputObject, u);
        } catch (Exception e) {
            trace(e);
        }
    }
}
