using UnityEngine;
using System.Collections;
using Sfs2X;
using Sfs2X.Entities.Data;

public class LoginMessage : SendableObject {
    public LoginMessage(SmartFox conn, bool encrypt, string username, string password)
        : base(conn, encrypt)
    {
        packetName = "login";

        SFSObject tr = new SFSObject();

        PutString(tr, "user", username);
        PutString(tr, "password", password);

        data.PutSFSObject("login", tr);
    }

    private LoginMessage()
    {
    }
}
