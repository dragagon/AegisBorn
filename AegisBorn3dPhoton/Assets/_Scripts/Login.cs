using System.Collections;
using UnityEngine;
using ExitGames.Client.Photon;
using AegisBornCommon;

public class Login : MonoBehaviour
{
    private Game _engine;

    public void Start()
    {
        _engine = MMOEngine.Engine;
    }

    public void OnGUI()
    {
        if (GUI.Button(new Rect(100, 60, 100, 30), "Connect"))
        {
            var peer = new PhotonPeer(_engine, false);

            _engine.Initialize(peer, "localhost:5055", "AegisBorn");
        }
        if (GUI.Button(new Rect(200, 60, 100, 30), "Send Operation"))
        {
            _engine.SendOp((OperationCode)100, new Hashtable(), false, 0);
        }
        GUI.Label(new Rect(100, 100, 300, 300), _engine.State.ToString());
    }
}
