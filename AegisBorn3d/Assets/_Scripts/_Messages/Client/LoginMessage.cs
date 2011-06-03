using UnityEngine;
using System.Collections;
using Sfs2X;

public class LoginMessage : IClientMessage {
    public LoginMessage(SmartFox conn, bool encrypt)
        : base(conn, encrypt)
    {
    }

    private LoginMessage()
    {
    }
}
