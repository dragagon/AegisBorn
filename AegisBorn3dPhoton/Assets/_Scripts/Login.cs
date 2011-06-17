using System.Collections;
using UnityEngine;
using System;
using ExitGames.Client.Photon;
using AegisBornCommon;

public class Login : MonoBehaviour, IGameListener
{

    Game _engine;

    // Use this for initialization
    void Start()
    {
        Application.runInBackground = true;
        _engine = new Game(this);


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
                _engine.SendOp((OperationCode)100, new Hashtable(), false, 0);
            }
        GUI.Label(new Rect(100, 100, 300, 300), _engine.);
    }

    #region Inherited Interfaces

    #region IGameListener
    public bool IsDebugLogEnabled
    {
        get { return true; }
    }

    public void LogDebug(Game game, string message)
    {
        Debug.Log(message);
    }

    public void LogError(Game game, string message)
    {
        Debug.Log(message);
    }

    public void LogError(Game game, Exception exception)
    {
        Debug.Log(exception.ToString());
    }

    public void LogInfo(Game game, string message)
    {
        Debug.Log(message);
    }

    public void OnConnect(Game game)
    {
        Debug.Log("connected");
    }

    public void OnDisconnect(Game game, StatusCode returnCode)
    {
        Debug.Log("disconnected");
    }

    #endregion

    #endregion
}
