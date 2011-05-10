using UnityEngine;
using System.Collections;
using Sfs2X.Core;
using Sfs2X.Requests;
using Sfs2X.Entities.Data;
using Sfs2X.Logging;

public class CharacterCreateGUI : ConnectionHandler
{
    bool debugMessages = false;

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
        if (false)
        {
            ISFSObject data = new SFSObject();
            ExtensionRequest request = new ExtensionRequest("getCharacters", data);
            smartFox.Send(request);
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
