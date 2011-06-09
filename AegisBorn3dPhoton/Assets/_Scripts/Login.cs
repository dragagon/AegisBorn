using UnityEngine;
using System.Collections;
using System;
using ExitGames.Client.Photon;

public class Login : MonoBehaviour
{

    Game engine;

    // Use this for initialization
    void Start()
    {
        Application.runInBackground = true;
        engine = new Game();


    }

    // Update is called once per frame
    void Update()
    {
        try
        {
            this.engine.Update();
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
            this.engine.Disconnect();
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
            PhotonPeer peer = new PhotonPeer(this.engine, false);

            engine.Initialize(peer, "localhost:5055", "AegisBorn");
        }
        GUI.Label(new Rect(100, 100, 300, 300), engine.status);
    }
}
