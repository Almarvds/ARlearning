using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class Player : NetworkBehaviour {

    public Text seeThis;

    [SyncVar]

    //xpublic Text seeThis2;

    private string role;

    void Update()
    {



        if (isClient) {
            Debug.Log("is a client");
        }

            if (hasAuthority)
            {
                Debug.Log("has authority");
            }

        if (isServer)
        {
            Debug.Log("you are on the server");
        }
    }


}
