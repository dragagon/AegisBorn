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
	CharacterListHandler CharacterList;
    CharacterSelectedHandler CharacterSelected;

    bool receivedCharacters = false;
    ErrorHandler errorHandler;

	new void Awake()
    {
	        base.Awake();
		if(smartFox.IsConnected)
		{
			CharacterList = new CharacterListHandler();
            CharacterSelected = new CharacterSelectedHandler();
            errorHandler = new ErrorHandler();

	        // Register callback delegate
	        smartFox.AddEventListener(SFSEvent.CONNECTION_LOST, OnConnectionLost);
	        smartFox.AddEventListener(SFSEvent.LOGOUT, OnLogout);
			
	        smartFox.AddLogListener(LogLevel.DEBUG, OnDebugMessage);
				
			// Personal message handlers
            handlers.Add("characterlist", CharacterList.HandleMessage);
            handlers.Add("characterSelected", CharacterSelected.HandleMessage);
            handlers.Add("error", errorHandler.HandleMessage);

            CharacterList.afterMessageRecieved += AfterCharacterList;
            CharacterSelected.afterMessageRecieved += AfterCharacterSelected;
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
            GUI.Box(new Rect(300, 10, 100, 300), "Classes");

            int yPos = 50;

            foreach (Character character in CharacterList.characterList)
            {

                if (GUI.Button(new Rect(310, yPos, 80, 50), character.Name))
                {
                    ISFSObject data = new SFSObject();
                    data.PutLong("characterID", character.ID);
                    Debug.Log("Logging in as character ID: " + character.ID);
                    ExtensionRequest request = new ExtensionRequest("selectCharacter", data);
                    smartFox.Send(request);
                }

                yPos += 60;
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

    public void AfterCharacterList()
    {
        receivedCharacters = true;
    }

    public void AfterCharacterSelected()
    {
        Debug.Log("going to main game");
        UnregisterSFSSceneCallbacks();
        Application.LoadLevel("Game");
    }
}
