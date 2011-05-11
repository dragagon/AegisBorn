using UnityEngine;
using System.Collections;

public class CharacterCreateHandler : IMessageHandler
{
    public override void OnHandleMessage(Sfs2X.Entities.Data.ISFSObject data)
    {
        Debug.Log("Character created successfully, going back to character select");
    }

}
