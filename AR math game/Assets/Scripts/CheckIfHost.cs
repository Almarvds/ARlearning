using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class CheckIfHost : NetworkBehaviour {

    [SyncVar]
    public int nConnected;
 
    void increaseConnected()
    {
        nConnected++;
    }

    int readConnected()
    {
        return nConnected;
    }



}
