using System.Collections;
using UnityEngine;
using ExitGames.Client.Photon;
using AegisBornCommon;

public class Login : MonoBehaviour
{
    private Game _engine;

    void Start()
    {
        _engine = MMOEngine.Engine;
    }

    private string _username = "";
    private string _password = "";
    private bool _loginSent = false;

    void OnGUI()
    {

        GUI.Label(new Rect(10, 116, 100, 100), "Userame: ");
        _username = GUI.TextField(new Rect(100, 116, 200, 20), _username, 25);
        GUI.Label(new Rect(10, 141, 100, 100), "Password: ");
        _password = GUI.PasswordField(new Rect(100, 141, 200, 20), _password, '*', 25);

        GUI.Label(new Rect(10, 225, 400, 100), _engine.State.ToString());

        if (GUI.Button(new Rect(100, 165, 100, 25), "Login") || (Event.current.type == EventType.keyDown && Event.current.character == '\n'))
        {
            var peer = new PhotonPeer(_engine, false);

            _engine.Initialize(peer, "localhost:5055", "AegisBorn");
        }
        if (GUI.Button(new Rect(100, 195, 100, 25), "Logout"))
        {
            _engine.SetDisconnected(0);
            _loginSent = false;
        }
    }

    void FixedUpdate()
    {
        if(_engine.State == GameState.Connected && !_loginSent)
        {
            LoginOperations.Login(_engine, _username, _password);
            _loginSent = true;
        }
    }
}
