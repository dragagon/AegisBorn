using UnityEngine;
using System;
using ExitGames.Client.Photon;

public class Login : MonoBehaviour
{

    Game _engine;

    // Use this for initialization
    void Start()
    {
        Application.runInBackground = true;
        _engine = new Game();


    }

    // Update is called once per frame
    void Update()
    {
        try
        {
            _engine.Update();
        }
        catch (Exception e)
        {
            Debug.Log(e);
        }
    }

    /// <summary>
    /// The on application quit.
    /// </summary>
    public void OnApplicationQuit()
    {
        try
        {
            _engine.Disconnect();
        }
        catch (Exception e)
        {
            Debug.Log(e);
        }
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
                _engine.SendOp();
            }
        GUI.Label(new Rect(100, 100, 300, 300), _engine.Status);
    }
}
