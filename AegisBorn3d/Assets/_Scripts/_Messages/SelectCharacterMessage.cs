using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sfs2X;

class SelectCharacterMessage : SendableObject
{
    public SelectCharacterMessage(SmartFox conn, bool encrypt, long characterId)
        : base(conn, encrypt)
    {
        packetName = "selectCharacter";
        PutLong(data, "characterID", characterId);
    }

    private SelectCharacterMessage()
    {
    }
}
