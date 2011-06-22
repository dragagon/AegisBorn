using UnityEngine;
using System.Collections;
using Sfs2X;
using Sfs2X.Core;
using Sfs2X.Logging;
using Sfs2X.Requests;
using Sfs2X.Entities.Data;
using Sfs2X.Util;

public class LobbyGUI : ConnectionHandler
{
    public string serverIP = "127.0.0.1";
    public int serverPort = 9933;
    public string gameZone = "AegisBorn";

    private string username = "";
    private string password = "";
    private string loginErrorMessage = "";
	private string lastModMessage = "";
     
    ServerPublicKeyHandler serverPublicKeyHandler;
    private LoginSuccessHandler loginSuccessHandler;

    /************
     * Unity callback methods
     ************/

    new void Awake()
    {
        base.Awake();

        serverPublicKeyHandler = new ServerPublicKeyHandler();
        loginSuccessHandler = new LoginSuccessHandler();

        // Register callback delegate
        smartFox.AddEventListener(SFSEvent.CONNECTION, OnConnection);
        smartFox.AddEventListener(SFSEvent.CONNECTION_LOST, OnConnectionLost);
        smartFox.AddEventListener(SFSEvent.LOGIN, OnLogin);
        smartFox.AddEventListener(SFSEvent.LOGIN_ERROR, OnLoginError);
        smartFox.AddEventListener(SFSEvent.LOGOUT, OnLogout);
		smartFox.AddEventListener(SFSEvent.MODERATOR_MESSAGE, OnMod);
		
        smartFox.AddLogListener(LogLevel.DEBUG, OnDebugMessage);

        serverPublicKeyHandler.afterMessageRecieved += Login_AfterServerPKRecieved;
        loginSuccessHandler.afterMessageRecieved += OnLoginSuccess;

        handlers.Add("publickey", serverPublicKeyHandler);
        handlers.Add("loginsuccess", loginSuccessHandler);


    }

    void OnGUI()
    {

        //GUI.skin = gSkin;

        //GUI.Label(new Rect(2, -2, 680, 70), "");

            // Login

            GUI.Label(new Rect(10, 116, 100, 100), "Userame: ");
            username = GUI.TextField(new Rect(100, 116, 200, 20), username, 25);
            GUI.Label(new Rect(10, 141, 100, 100), "Password: ");
            password = GUI.PasswordField(new Rect(100, 141, 200, 20), password, '*', 25);
		
			GUI.Label(new Rect(10, 225, 400, 100), lastModMessage);
            GUI.Label(new Rect(10, 255, 400, 100), loginErrorMessage);

            if (GUI.Button(new Rect(100, 165, 100, 25), "Login") || (Event.current.type == EventType.keyDown && Event.current.character == '\n'))
            {
				lastModMessage = "";
                smartFox.Connect(serverIP, serverPort);
            }
            if (GUI.Button(new Rect(100, 195, 100, 25), "Logout"))
            {
                smartFox.Disconnect();
            }
    }

    /************
     * Callbacks from the SFS API
     ************/

    public void OnConnection(BaseEvent evt)
    {
        bool success = (bool)evt.Params["success"];
        string error = (string)evt.Params["error"];

        if (success)
        {
			loginErrorMessage = "";
			if(debug)
			{
				Debug.Log("Connected");
			}
            SmartFoxConnection.Connection = smartFox;
            smartFox.Send(new LoginRequest(username, "", gameZone));
            smartFox.Send(new JoinRoomRequest("General"));
        }
        else
        {
            loginErrorMessage = error;
        }
    }

    public override void OnConnectionLost(BaseEvent evt)
    {
        loginErrorMessage = "Connection lost / no connection to server";
    }

    public void OnLoginError(BaseEvent evt)
    {
        Debug.Log("Login error: " + (string)evt.Params["errorMessage"]);
    }

    public override void OnLogout(BaseEvent evt)
    {
        Debug.Log("OnLogout");
    }

    public void OnLogin(BaseEvent evt)
    {
        if (evt.Params.ContainsKey("success") && !(bool)evt.Params["success"])
        {
            // Login failed - lets display the error message sent to us
            loginErrorMessage = (string)evt.Params["errorMessage"];
            Debug.Log("Login error: " + loginErrorMessage);
        }
        else
        {
            // Successful login
            new PublicKeyMessage(smartFox, provider).Send();
        }
    }

    public void Login_AfterServerPKRecieved()
    {
		Debug.Log("sending login");
        new LoginMessage(smartFox, true, username, password).Send();
    }
	
	void OnMod(BaseEvent evt)
    {
		if(evt.Params.ContainsKey("message"))
		{
			lastModMessage = (string)evt.Params["message"];
		}
    }
	
	void OnLoginSuccess()
	{
		UnregisterSFSSceneCallbacks();
		Application.LoadLevel("CharacterSelect");
		Destroy(this);
	}

}
