using System.Collections;
using AegisBornCommon;

public static class LoginOperations
{
    public static void Login(Game game, string username, string password)
    {
        var vartable = new Hashtable
                           {
                               {(byte) ParameterCode.UserName, username},
                               {(byte) ParameterCode.Password, password}
                           };

        game.SendOp(OperationCode.Login, vartable, true, 0, true);
    }
}
