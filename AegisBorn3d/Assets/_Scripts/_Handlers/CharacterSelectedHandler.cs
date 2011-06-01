using System;
using Sfs2X.Entities.Data;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSelectedHandler : IMessageHandler
{
	
    public override void OnHandleMessage(ISFSObject data)
    {
        Debug.Log("Character selected successfully, entering the game");
    }
}

