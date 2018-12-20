using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class BuildingProgress : NetworkBehaviour {

    public GameObject Role;
    public Text YourScore;
    public GameObject characterPanelMaterial;
    public GameObject BuildingProgressOther;

    //mats
    public Sprite Wood;
    public Sprite Bricks;
    public Sprite Paint;
    public Sprite Designs;

    [SyncVar]
    public int NeededBricks;
    public int NeededWood;
    public int NeededDesigns;
    public int NeededPaint;    
    public int NumberBricks;
    public int NumberWood;
    public int NumberDesigns;
    public int NumberPaint;


    public void Start()
    {
        YourScore.text = "";
    }

    public void UpdateScore(int MaterialGot, int MaterialNeeded)
    {
        YourScore.text = MaterialGot + "/" + MaterialNeeded;
    }

    public void UpdateOtherPlayerScore(int PartnerMaterialGot, int PartnerMaterialNeeded)
    {
        BuildingProgressOther.GetComponent<Text>().text = PartnerMaterialGot + "/" + PartnerMaterialNeeded;
    }

    public void IncreaseMaterial()
    {
        if (Role.GetComponent<RoleScript>().RoleName.Equals("Designer"))
        {
            CmdIncreaseMaterial(NumberDesigns, NeededDesigns);
            //NumberDesigns++;
            //UpdateScore(NumberDesigns, NeededDesigns);
        }

        if (Role.GetComponent<RoleScript>().RoleName.Equals("Painter"))
        {
            CmdIncreaseMaterial(NumberPaint, NeededPaint);
            //NumberPaint++;
            //UpdateScore(NumberPaint, NeededPaint);
        }

        if (Role.GetComponent<RoleScript>().RoleName.Equals("Bricklayer"))
        {
            CmdIncreaseMaterial(NumberBricks, NeededBricks);
            //NumberWood++;
            //UpdateScore(NumberBricks, NeededBricks);
        }

        if (Role.GetComponent<RoleScript>().RoleName.Equals("Carpenter"))
        {
            CmdIncreaseMaterial(NumberWood, NeededWood);
            //NumberWood++;
            //UpdateScore(NumberWood, NeededWood);
        }
    }

    public String ReturnMaterial()
    {
        if (Role.GetComponent<RoleScript>().RoleName.Equals("Designer"))
        {
            return "drawings";
        }

        if (Role.GetComponent<RoleScript>().RoleName.Equals("Painter"))
        {
            return "buckets of paint";
        }

        if (Role.GetComponent<RoleScript>().RoleName.Equals("Bricklayer"))
        {
            return "bricks";
        }

        if (Role.GetComponent<RoleScript>().RoleName.Equals("Carpenter"))
        {
            return "wooden planks";
        }

        else return "";
    }

    public void BuildingSelected(int wood, int paint, int designs, int bricks)
    {
        NeededDesigns = designs;
        NeededPaint = paint;
        NeededBricks = bricks;
        NeededWood = wood;

        if (Role.GetComponent<RoleScript>().RoleName.Equals("Designer"))
        {
            UpdateScore(NumberDesigns, NeededDesigns);
        }

        if (Role.GetComponent<RoleScript>().RoleName.Equals("Painter"))
        {
            UpdateScore(NumberPaint, NeededPaint);
        }

        if (Role.GetComponent<RoleScript>().RoleName.Equals("Bricklayer"))
        {
            UpdateScore(NumberBricks, NeededBricks);
        }

        if (Role.GetComponent<RoleScript>().RoleName.Equals("Carpenter"))
        {
            UpdateScore(NumberWood, NeededWood);
        }

        SetPartnerMaterials();

    }

    void SetPartnerMaterials()
    {
        if (GameObject.Find("Local").GetComponent<RoleUpdater>().DesignerConnected &&
            Role.GetComponent<RoleScript>().RoleName != "Designer")
        {
            characterPanelMaterial.GetComponent<Image>().sprite = Designs;
            UpdateOtherPlayerScore(NumberDesigns, NeededDesigns);
        }

        if (GameObject.Find("Local").GetComponent<RoleUpdater>().CarpenterConnected &&
            Role.GetComponent<RoleScript>().RoleName != "Carpenter")
        {
            characterPanelMaterial.GetComponent<Image>().sprite = Wood;
            UpdateOtherPlayerScore(NumberWood, NeededWood);
        }

        if (GameObject.Find("Local").GetComponent<RoleUpdater>().PainterConnected &&
            Role.GetComponent<RoleScript>().RoleName != "Painter")
        {
            characterPanelMaterial.GetComponent<Image>().sprite = Paint;
            UpdateOtherPlayerScore(NumberPaint, NeededPaint);
        }

        if (GameObject.Find("Local").GetComponent<RoleUpdater>().BricklayerConnected &&
            Role.GetComponent<RoleScript>().RoleName != "Bricklayer")
        {
            characterPanelMaterial.GetComponent<Image>().sprite = Bricks;
            UpdateOtherPlayerScore(NumberBricks, NeededBricks);

        }

        BuildingProgressOther.SetActive(true);
        characterPanelMaterial.SetActive(true);
    }

    [Command]
    void CmdIncreaseMaterial(int MaterialGot, int MaterialNeeded)
    {
        MaterialGot++;
        UpdateScore(MaterialGot, MaterialNeeded);
        RpcUpdateRoles(MaterialGot, MaterialNeeded);
    }

    [ClientRpc]
    void RpcUpdateRoles(int MaterialGot, int MaterialNeeded)
    {
        MaterialGot++;
        UpdateScore(MaterialGot, MaterialNeeded);
    }

}
