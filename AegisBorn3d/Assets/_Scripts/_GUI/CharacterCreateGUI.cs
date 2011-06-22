using UnityEngine;
using System.Collections;
using Sfs2X.Core;
using Sfs2X.Requests;
using Sfs2X.Entities.Data;
using Sfs2X.Logging;

public class CharacterCreateGUI : ConnectionHandler
{
    bool showErrorDialog = false;
    string characterName = "";
    string sex = "";
    string characterClass = "";

    CharacterCreateHandler CharacterCreate;
    ErrorHandler errorHandler;

    new void Awake()
    {
        base.Awake();
        if (smartFox.IsConnected)
        {
            CharacterCreate = new CharacterCreateHandler();
            errorHandler = new ErrorHandler();
            // Register callback delegate
            smartFox.AddEventListener(SFSEvent.CONNECTION_LOST, OnConnectionLost);
            smartFox.AddEventListener(SFSEvent.LOGOUT, OnLogout);

            smartFox.AddLogListener(LogLevel.DEBUG, OnDebugMessage);

            // Personal message handlers
            handlers.Add("characterCreated", CharacterCreate);
            handlers.Add("error", errorHandler);
 
            CharacterCreate.afterMessageRecieved += AfterCharacterCreated;
            errorHandler.afterMessageRecieved += AfterErrorReceived;
            // We are ready to get the character list
        }
        else
        {
            Application.LoadLevel("Lobby");
        }
    }

    public void AfterErrorReceived()
    {
        // get the error message and set the error "dialog" to appear with the message.
        showErrorDialog = true;
    }

    public void AfterCharacterCreated()
    {
        UnregisterSFSSceneCallbacks();
        Application.LoadLevel("CharacterSelect");
    }

    void OnGUI()
    {

        if (showErrorDialog)
        {

        }

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
                new CreateCharacterMessage(smartFox, false, characterName, sex, characterClass).Send();
            }
        }
    }


}
