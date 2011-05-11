using UnityEngine;
using System.Collections;
using Sfs2X.Core;
using Sfs2X.Requests;
using Sfs2X.Entities.Data;
using Sfs2X.Logging;

public class CharacterCreateGUI : ConnectionHandler
{
    bool debugMessages = false;
    string characterName = "";
    string sex = "";
    string characterClass = "";

    CharacterCreateHandler CharacterCreate;
    new void Awake()
    {
        base.Awake();
        if (smartFox.IsConnected)
        {
            CharacterCreate = new CharacterCreateHandler();

            // Register callback delegate
            smartFox.AddEventListener(SFSEvent.CONNECTION_LOST, OnConnectionLost);
            smartFox.AddEventListener(SFSEvent.LOGOUT, OnLogout);

            smartFox.AddLogListener(LogLevel.DEBUG, OnDebugMessage);

            // Personal message handlers
            handlers.Add("characterlist", CharacterCreate.HandleMessage);
            // We are ready to get the character list
        }
        else
        {
            Application.LoadLevel("Lobby");
        }
    }

    void OnGUI()
    {

        GUI.Label(new Rect(120, 116, 100, 100), "Name: ");
        characterName = GUI.TextField(new Rect(200, 116, 200, 20), characterName, 25);

        GUI.Box(new Rect(10, 10, 100, 300), "Classes");

        if (GUI.Button(new Rect(20, 50, 80, 50), "Fighter"))
        {
            characterClass = "Fighter";
        }
        if (GUI.Button(new Rect(20, 110, 80, 50), "Mage"))
        {
            characterClass = "Mage";
        }
        if (GUI.Button(new Rect(20, 170, 80, 50), "Rogue"))
        {
            characterClass = "Rogue";
        }
        if (GUI.Button(new Rect(20, 230, 80, 50), "Cleric"))
        {
            characterClass = "Cleric";
        }

        if (GUI.Button(new Rect(150, 170, 80, 50), "Male"))
        {
            sex = "M";
        }
        if (GUI.Button(new Rect(240, 170, 80, 50), "Female"))
        {
            sex = "F";
        }

        if (GUI.Button(new Rect(200, 265, 100, 25), "Create") || (Event.current.type == EventType.keyDown && Event.current.character == '\n'))
        {
            if (!string.IsNullOrEmpty(characterName) && !string.IsNullOrEmpty(sex) && !string.IsNullOrEmpty(characterClass))
            {
                ISFSObject data = new SFSObject();
                data.PutUtfString("characterName", characterName);
                data.PutUtfString("sex", sex);
                data.PutUtfString("characterClass", characterClass);
                ExtensionRequest request = new ExtensionRequest("createCharacter", data);
                smartFox.Send(request);
            }
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
        if (debugMessages)
        {
            Debug.Log("**** DEBUG ****" + message);
        }
    }
    #endregion

}
