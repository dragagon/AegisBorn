using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sfs2X;

class GetCharactersMessage : SendableObject
{
    public GetCharactersMessage(SmartFox conn, bool encrypt)
        : base(conn, encrypt)
    {
        packetName = "getCharacters";
    }

    private GetCharactersMessage()
    {
    }
}
