using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class RoleScript : NetworkBehaviour {

    public string RoleName;
    public Image Characterbutton;
    public Image Characterbutton2;
    public Image Characterbutton3;
    public Image CharacterText2;
    public Image CharacterText;

    public Sprite Designer;
    public Sprite Painter;
    public Sprite Bricklayer;
    public Sprite Carpenter;

    public Sprite DesignerText;
    public Sprite PainterText;
    public Sprite BricklayerText;
    public Sprite CarpenterText;

    [SyncVar]
    public bool DesignerConnected;
    public bool PainterConnected;
    public bool CarpenterConnected;
    public bool BricklayerConnected;

    public void SetRoleToDesigner()
    {
        Characterbutton.GetComponent<Image>().sprite = Designer;
        CharacterText.GetComponent<Image>().sprite = DesignerText;
        Characterbutton2.GetComponent<Image>().sprite = Designer;
        CharacterText2.GetComponent<Image>().sprite = DesignerText;
        Characterbutton3.GetComponent<Image>().sprite = Designer;
        RoleName = "Designer";
        SendRole(RoleName);
        if (isServer)
        {
            DesignerConnected = true;
        }
    }

    public void SetRoleToPainter()
    {
        Characterbutton.GetComponent<Image>().sprite = Painter;
        CharacterText.GetComponent<Image>().sprite = PainterText;
        Characterbutton2.GetComponent<Image>().sprite = Painter;
        CharacterText2.GetComponent<Image>().sprite = PainterText;
        Characterbutton3.GetComponent<Image>().sprite = Painter;
        RoleName = "Painter";
        SendRole(RoleName);
        if (isServer)
        {
            PainterConnected = true;
        }
    }

    public void SetRoleToBricklayer()
    {
        Characterbutton.GetComponent<Image>().sprite = Bricklayer;
        CharacterText.GetComponent<Image>().sprite = BricklayerText;
        Characterbutton2.GetComponent<Image>().sprite = Bricklayer;
        CharacterText2.GetComponent<Image>().sprite = BricklayerText;
        Characterbutton3.GetComponent<Image>().sprite = Bricklayer;
        RoleName = "Bricklayer";
        SendRole(RoleName);

        if (isServer)
        {
            BricklayerConnected = true;
        }
    }

    public void SetRoleToCarpenter()
    {
        Characterbutton.GetComponent<Image>().sprite = Carpenter;
        CharacterText.GetComponent<Image>().sprite = CarpenterText;
        Characterbutton2.GetComponent<Image>().sprite = Carpenter;
        CharacterText2.GetComponent<Image>().sprite = CarpenterText;
        Characterbutton3.GetComponent<Image>().sprite = Carpenter;
        RoleName = "Carpenter";
        SendRole(RoleName);

        if (isServer)
        {
            CarpenterConnected = true;
        }
    }

    public void SendRole(string RoleName)
    {
        if (!isServer)
        {
            Debug.Log("Sending Command");
            CmdSendRole(RoleName);
        }
    }

    [Command]
    void CmdSendRole(string RoleName)
    {
            RpcUpdateRoles(RoleName);

        Debug.Log("Updating Roles on ");
        if (RoleName == "Designer")
        {
            DesignerConnected = true;
        }
        if (RoleName == "Painter")
        {
            PainterConnected = true;
        }
        if (RoleName == "Carpenter")
        {
            CarpenterConnected = true;
        }
        if (RoleName == "Bricklayer")
        {
            BricklayerConnected = true;
        }
    }

    [ClientRpc]
    void RpcUpdateRoles(string ClientRole)
    {
        Debug.Log("Updating Roles");
        if(ClientRole == "Designer"){
            DesignerConnected = true;
        }
        if (ClientRole == "Painter")
        {
            PainterConnected = true;
        }
        if (ClientRole == "Carpenter")
        {
            CarpenterConnected = true;
        }
        if (ClientRole == "Bricklayer")
        {
            BricklayerConnected = true;
        }
    }

}
