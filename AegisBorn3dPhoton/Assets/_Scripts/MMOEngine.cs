using System;
using ExitGames.Client.Photon;
using UnityEngine;

public class MMOEngine : MonoBehaviour, IGameListener
{
    private static Game _engine;

    public static Game Engine
    {
        get { return _engine; }   
    }

    // Use this for initialization
    void Start()
    {
        Application.runInBackground = true;
        _engine = new Game(this);
        DontDestroyOnLoad(this);
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
