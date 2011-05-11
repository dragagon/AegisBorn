using System;
using Sfs2X.Entities.Data;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSelectHandler : IMessageHandler
{
	public List<Character> characterList;
	public int maxCharacters;
	
	public CharacterSelectHandler ()
	{
		characterList = new List<Character>();
		maxCharacters = 0;
	}
	
    public override void OnHandleMessage(ISFSObject data)
    {
        maxCharacters = data.GetInt("maxCharacters");
        ISFSObject characters = data.GetSFSObject("characters");
        foreach (string key in characters.GetKeys())
        {
            Debug.Log("Adding character: " + key);
            characterList.Add(Character.LoadFromSFSObject(characters.GetSFSObject(key)));
        }

        Debug.Log("Max: " + maxCharacters);
        Debug.Log("Characters: " + characterList.Count);

    }
}

