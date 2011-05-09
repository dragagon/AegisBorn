using UnityEngine;
using Sfs2X;

// Statics for holding the connection to the SFS server end
// Can then be queried from the entire game to get the connection

public class SmartFoxConnection : MonoBehaviour
{
    private static SmartFox smartFox;
    public static SmartFox Connection
    {
        get { return smartFox; }
        set { smartFox = value; }
    }

    public static bool IsInitialized
    {
        get { return (smartFox != null); }
    }
}