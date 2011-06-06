using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sfs2X;

class CreateCharacterMessage : IClientMessage
{

    public CreateCharacterMessage(SmartFox conn, bool encrypt, string characterName, string sex, string characterClass)
        : base(conn, encrypt)
    {
        packetName = "createCharacter";
        PutString(data, "characterName", characterName);
        PutString(data, "sex", sex);
        PutString(data, "characterClass", characterClass);
    }

    private CreateCharacterMessage()
    {
    }
}
