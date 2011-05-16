using UnityEngine;
using System.Collections;
using Sfs2X;
using Sfs2X.Core;
using Sfs2X.Logging;
using Sfs2X.Requests;
using Sfs2X.Entities.Data;
using Sfs2X.Util;

public class CharacterSelectGUI : ConnectionHandler {
	
	bool debugMessages = false;
	CharacterSelectHandler CharacterSelect;
    bool receivedCharacters = false;

	new void Awake()
    {
	        base.Awake();
		if(smartFox.IsConnected)
		{
			CharacterSelect = new CharacterSelectHandler();

	        // Register callback delegate
	        smartFox.AddEventListener(SFSEvent.CONNECTION_LOST, OnConnectionLost);
	        smartFox.AddEventListener(SFSEvent.LOGOUT, OnLogout);
			
	        smartFox.AddLogListener(LogLevel.DEBUG, OnDebugMessage);
				
			// Personal message handlers
            handlers.Add("characterlist", CharacterSelect.HandleMessage);
            CharacterSelect.afterMessageRecieved += AfterCharacterSelect;
			// We are ready to get the character list
			ISFSObject data = new SFSObject();
	
	        ExtensionRequest request = new ExtensionRequest("getCharacters", data);
	        smartFox.Send(request);

		}
		else
		{
			Application.LoadLevel("Lobby");
		}
    }

    void OnGUI()
    {
        if (receivedCharacters)
        {
            foreach (Character character in CharacterSelect.characterList)
            {

            }

            if (GUI.Button(new Rect(100, 165, 100, 25), "New Character") || (Event.current.type == EventType.keyDown && Event.current.character == '\n'))
            {
                UnregisterSFSSceneCallbacks();
                Application.LoadLevel("CharacterCreate");
            }
        }
        if (GUI.Button(new Rect(100, 195, 100, 25), "Back"))
        {
            UnregisterSFSSceneCallbacks();
            smartFox.Disconnect();
            Application.LoadLevel("Lobby");
        }
    }
	
	#region Connection Callbacks
	public void OnConnectionLost(BaseEvent evt)
    {
		// Display popup, when user hits ok, return to lobby.
        //loginErrorMessage = "Connection lost / no connection to server";
		Application.LoadLevel("Lobby");
    }
	
	void OnLogout(BaseEvent evt)
    {
		Application.LoadLevel("Lobby");
    }
	
	public void OnDebugMessage(BaseEvent evt)
    {
        string message = (string)evt.Params["message"];
		if(debugMessages)
		{
			Debug.Log("**** DEBUG ****" + message);
		}
    }
	#endregion

    public void AfterCharacterSelect()
    {
        receivedCharacters = true;
    }
}
