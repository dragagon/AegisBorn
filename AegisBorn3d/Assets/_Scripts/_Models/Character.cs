using System;
using Sfs2X.Entities.Data;
using UnityEngine;

public class Character
{
    string name;
    int level;
    long id;

    public Character()
    {
    }

    public static Character LoadFromSFSObject(ISFSObject data)
    {
        Character newCharacter = new Character();
        try
        {
            if (data.ContainsKey("id"))
            {
                newCharacter.id = data.GetLong("id");
            }
            else
            {
                Debug.Log("SFS Message did not contain character key");
            }
            newCharacter.name = data.GetUtfString("name");
            newCharacter.level = data.GetInt("level");
        }
        catch (Exception e)
        {
            Debug.Log(e);
        }
        return newCharacter;
    }
}

