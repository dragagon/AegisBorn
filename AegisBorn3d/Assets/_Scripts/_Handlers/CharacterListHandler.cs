using System;
using Sfs2X.Entities.Data;
using System.Collections.Generic;
using UnityEngine;

public class CharacterListHandler : IMessageHandler
{
	public List<Character> characterList;
	public int maxCharacters;
	
	public CharacterListHandler ()
	{
		characterList = new List<Character>();
		maxCharacters = 0;
	}
	
    public override void OnHandleMessage(ISFSObject data)
    {
        maxCharacters = data.GetInt("maxCharacters");
        ISFSObject characters = data.GetSFSObject("characters");
        Character character;
        foreach (string key in characters.GetKeys())
        {
            character = new Character();
            Debug.Log("Adding character: " + key);
            if (character.FromSFSObject(characters.GetSFSObject(key)))
            {
                characterList.Add(character);
            }
        }

        Debug.Log("Max: " + maxCharacters);
        Debug.Log("Characters: " + characterList.Count);

    }
}

