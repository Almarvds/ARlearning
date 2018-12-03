using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class DisableGUI : NetworkBehaviour {

    public GameObject NetworkGUIHUD;

    private void OnStartServer(Action guiOff)
    {
        throw new NotImplementedException();
    }

    void GuiOff()
    {
        NetworkGUIHUD.SetActive(false);
    }
}
