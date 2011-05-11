using System;
using Sfs2X.Entities.Data;
using UnityEngine;

public class Character
{
	string name;
	int level;
	
	public Character ()
	{
	}
	
	public static Character LoadFromSFSObject(ISFSObject data)
	{
		Character newCharacter = new Character();
		try
		{
		newCharacter.name = data.GetUtfString("name");
		newCharacter.level = data.GetInt("level");
		}
		catch(Exception e)
		{
			Debug.Log(e);
		}
		return newCharacter;
	}
}

