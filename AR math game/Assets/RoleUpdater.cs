using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class RoleUpdater : NetworkBehaviour {

    [SyncVar]
    public bool DesignerConnected;
    public bool PainterConnected;
    public bool CarpenterConnected;
    public bool BricklayerConnected;

    public override void OnStartLocalPlayer()
    {
        base.OnStartLocalPlayer();
        gameObject.name = "Local";
    }

    public void SendRole(string RoleName)
    {
        Debug.Log("we made it");
        if (!isServer)
        {
            Debug.Log("Sending Command");
            CmdSendRole(RoleName);
        } else
        {
            LinkToRole(RoleName);
            RpcUpdateRoles(RoleName);
        }
    }

    [Command]
    void CmdSendRole(string RoleName)
    {
        Debug.Log("Updating Roles on host side");
        LinkToRole(RoleName);
        RpcUpdateRoles(RoleName);
    }

    [ClientRpc]
    void RpcUpdateRoles(string ClientRole)
    {
        Debug.Log("Updating Roles");
        LinkToRole(ClientRole);
    }

    void LinkToRole(string ClientRole)
    {
        if (ClientRole == "Designer")
        {
            GameObject.Find("Local").GetComponent<RoleUpdater>().DesignerConnected = true;
            GameObject.Find("Player(Clone)").GetComponent<RoleUpdater>().DesignerConnected=true;
        }
        if (ClientRole == "Painter")
        {
            GameObject.Find("Local").GetComponent<RoleUpdater>().PainterConnected = true;
            GameObject.Find("Player(Clone)").GetComponent<RoleUpdater>().PainterConnected = true;
        }
        if (ClientRole == "Carpenter")
        {
            GameObject.Find("Local").GetComponent<RoleUpdater>().CarpenterConnected = true;
            GameObject.Find("Player(Clone)").GetComponent<RoleUpdater>().CarpenterConnected = true;
        }
        if (ClientRole == "Bricklayer")
        {
            GameObject.Find("Local").GetComponent<RoleUpdater>().BricklayerConnected = true;
            GameObject.Find("Player(Clone)").GetComponent<RoleUpdater>().BricklayerConnected = true;
        }
    }
}
