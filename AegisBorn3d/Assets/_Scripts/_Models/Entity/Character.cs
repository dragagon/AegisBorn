using System;
using Sfs2X.Entities.Data;
using UnityEngine;

public class Character : ReceivableObject
{
    string name;
    int level;
    long id;

    public Character()
        : base(false)
    {
    }

    public override bool FromSFSObject(ISFSObject data)
    {
        bool retVal = false;
        try
        {
            if (data.ContainsKey("id"))
            {
                id = GetLong(data, "id");
            }
            else
            {
                throw new Exception("SFSObject did not contain character id");
            }
            name = GetString(data, "name");
            level = GetInt(data, "level");
            retVal = true;
        }
        catch (Exception e)
        {
            Debug.Log(e);
        }
        return retVal;
    }

    public string Name
    {
        get { return name; }
        set { name = value; }
    }

    public long ID
    {
        get { return id; }
        set { id = value; }
    }

    public int Level
    {
        get { return level; }
        set { level = value; }
    }
}

