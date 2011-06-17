using System;
using ExitGames.Client.Photon;

public interface IGameListener
{
    bool IsDebugLogEnabled { get; }

    void LogDebug(Game game, string message);

    void LogError(Game game, string message);

    void LogError(Game game, Exception exception);

    void LogInfo(Game game, string message);

    void OnConnect(Game game);

    void OnDisconnect(Game game, StatusCode returnCode);

}
