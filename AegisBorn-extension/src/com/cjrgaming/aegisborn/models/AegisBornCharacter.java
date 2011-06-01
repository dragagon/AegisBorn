/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package com.cjrgaming.aegisborn.models;

import com.smartfoxserver.v2.entities.data.ISFSObject;
import com.smartfoxserver.v2.entities.data.SFSObject;
import java.math.BigInteger;

/**
 *
 * @author Christian Richards
 */
public class AegisBornCharacter 
{

    protected com.cjrgaming.aegisborn.persistence.AegisBornCharacter character;

    public AegisBornCharacter(com.cjrgaming.aegisborn.persistence.AegisBornCharacter character) 
    {
        this.character = character;
    }

    public void loadFromSFSObject(ISFSObject data) 
    {
        character.setLevel(BigInteger.valueOf(1));
        character.setPositionX(BigInteger.ZERO);
        character.setPositionY(BigInteger.ZERO);
        character.setCreatedAt(new java.util.Date());
        character.setUpdatedAt(new java.util.Date());
        
        for(String key : data.getKeys())
        {
            if(key.equalsIgnoreCase("characterName"))
                character.setName(data.getUtfString(key));
            if(key.equalsIgnoreCase("sex"))
                character.setSex(data.getUtfString(key));
            if(key.equalsIgnoreCase("characterClass"))
                character.setClass1(data.getUtfString(key));
        }
    }

    public ISFSObject createSFSObject() 
    {
        ISFSObject data = new SFSObject();
        data.putLong("id", character.getId());
        data.putUtfString("name", character.getName());
        data.putInt("level", character.getLevel().intValue());
        return data;
    }

    public com.cjrgaming.aegisborn.persistence.AegisBornCharacter getCharacter() 
    {
        return character;
    }
}
