/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package com.cjrgaming.aegisborn.models;

import com.smartfoxserver.v2.entities.data.ISFSObject;
import com.smartfoxserver.v2.entities.data.SFSObject;

/**
 *
 * @author Christian Richards
 */
public class AegisBornCharacter {
    protected com.cjrgaming.aegisborn.persistence.AegisBornCharacter character;
    
    public AegisBornCharacter(com.cjrgaming.aegisborn.persistence.AegisBornCharacter character)
    {
        this.character = character;
    }
    
    public void loadFromSFSObject(ISFSObject data)
    {

    }

    public ISFSObject createSFSObject()
    {
        ISFSObject data = new SFSObject();
        data.putUtfString("name", character.getName());
        data.putInt("level", character.getLevel().intValue());
        return data;
    }

}
