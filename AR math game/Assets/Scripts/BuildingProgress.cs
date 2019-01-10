using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class BuildingProgress : NetworkBehaviour {

    //mats
    public Sprite Wood;
    public Sprite Bricks;
    public Sprite Paint;
    public Sprite Designs;

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
        GameObject.Find("ARcamera/UI/CharacterPanel/You/YourScore").GetComponent<Text>().text = "";
    }

    public void UpdateScore(int MaterialGot, int MaterialNeeded)
    {
        GameObject.Find("ARcamera/UI/CharacterPanel/You/YourScore").GetComponent<Text>().text = MaterialGot + "/" + MaterialNeeded;
    }

    public void UpdateOtherPlayerScore(int PartnerMaterialGot, int PartnerMaterialNeeded)
    {
        GameObject.Find("ARcamera/UI/CharacterPanel/Teammate/PartnerProgress").GetComponent<Text>().text = PartnerMaterialGot + "/" + PartnerMaterialNeeded;
    }

    public void IncreaseMaterial()
    {
        if (GameObject.Find("Role").GetComponent<RoleScript>().RoleName.Equals("Designer"))
        {
            IncreaseMaterial(NumberDesigns, NeededDesigns);
            NumberDesigns++;
            Debug.Log("Number of designs"+ NumberDesigns);
            //UpdateScore(NumberDesigns, NeededDesigns);
        }

        if (GameObject.Find("Role").GetComponent<RoleScript>().RoleName.Equals("Painter"))
        {
            IncreaseMaterial(NumberPaint, NeededPaint);
            NumberPaint++;
            //UpdateScore(NumberPaint, NeededPaint);
        }

        if (GameObject.Find("Role").GetComponent<RoleScript>().RoleName.Equals("Bricklayer"))
        {
            IncreaseMaterial(NumberBricks, NeededBricks);
            NumberWood++;
            //UpdateScore(NumberBricks, NeededBricks);
        }

        if (GameObject.Find("Role").GetComponent<RoleScript>().RoleName.Equals("Carpenter"))
        {
            IncreaseMaterial(NumberWood, NeededWood);
            NumberWood++;
            //UpdateScore(NumberWood, NeededWood);
        }
    }

    public String ReturnMaterial()
    {
        if (GameObject.Find("Role").GetComponent<RoleScript>().RoleName.Equals("Designer"))
        {
            return "drawings";
        }

        if (GameObject.Find("Role").GetComponent<RoleScript>().RoleName.Equals("Painter"))
        {
            return "buckets of paint";
        }

        if (GameObject.Find("Role").GetComponent<RoleScript>().RoleName.Equals("Bricklayer"))
        {
            return "bricks";
        }

        if (GameObject.Find("Role").GetComponent<RoleScript>().RoleName.Equals("Carpenter"))
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

        if (GameObject.Find("Role").GetComponent<RoleScript>().RoleName.Equals("Designer"))
        {
            UpdateScore(NumberDesigns, NeededDesigns);
        }

        if (GameObject.Find("Role").GetComponent<RoleScript>().RoleName.Equals("Painter"))
        {
            UpdateScore(NumberPaint, NeededPaint);
        }

        if (GameObject.Find("Role").GetComponent<RoleScript>().RoleName.Equals("Bricklayer"))
        {
            UpdateScore(NumberBricks, NeededBricks);
        }

        if (GameObject.Find("Role").GetComponent<RoleScript>().RoleName.Equals("Carpenter"))
        {
            UpdateScore(NumberWood, NeededWood);
        }

        SetPartnerMaterials();

    }

    void SetPartnerMaterials()
    {
        if (GameObject.Find("Local").GetComponent<RoleUpdater>().DesignerConnected &&
            GameObject.Find("Role").GetComponent<RoleScript>().RoleName != "Designer")
        {
            GameObject.Find("ARcamera/UI/CharacterPanel/Teammate/PartnerRole").GetComponent<Image>().sprite = Designs;
            UpdateOtherPlayerScore(NumberDesigns, NeededDesigns);
        }

        if (GameObject.Find("Local").GetComponent<RoleUpdater>().CarpenterConnected &&
            GameObject.Find("Role").GetComponent<RoleScript>().RoleName != "Carpenter")
        {
            GameObject.Find("ARcamera/UI/CharacterPanel/Teammate/PartnerRole").GetComponent<Image>().sprite = Wood;
            UpdateOtherPlayerScore(NumberWood, NeededWood);
        }

        if (GameObject.Find("Local").GetComponent<RoleUpdater>().PainterConnected &&
            GameObject.Find("Role").GetComponent<RoleScript>().RoleName != "Painter")
        {
            GameObject.Find("ARcamera/UI/CharacterPanel/Teammate/PartnerRole").GetComponent<Image>().sprite = Paint;
            UpdateOtherPlayerScore(NumberPaint, NeededPaint);
        }

        if (GameObject.Find("Local").GetComponent<RoleUpdater>().BricklayerConnected &&
            GameObject.Find("Role").GetComponent<RoleScript>().RoleName != "Bricklayer")
        {
            GameObject.Find("ARcamera/UI/CharacterPanel/Teammate/PartnerRole").GetComponent<Image>().sprite = Bricks;
            UpdateOtherPlayerScore(NumberBricks, NeededBricks);

        }

        GameObject.Find("ARcamera/UI/CharacterPanel/Teammate/PartnerProgress").SetActive(true);
        GameObject.Find("ARcamera/UI/CharacterPanel/Teammate/PartnerRole").SetActive(true);
    }

    
    void IncreaseMaterial(int MaterialGot, int MaterialNeeded)
    {
        if (!isServer)
        {
            Debug.Log("not server");
            CmdIncreaseMaterial(MaterialGot, MaterialNeeded);
        }
        else
        {
            Debug.Log("server");
            Debug.Log(MaterialGot + " , " +MaterialNeeded);
            GameObject.Find("Local").GetComponent<BuildingProgress>().IncreaseMat(MaterialGot, MaterialNeeded);
            Debug.Log("Local mats increased");
            RpcUpdateRoles2(MaterialGot,MaterialNeeded);
        }
    }

    [Command]
    void CmdIncreaseMaterial(int MaterialGot, int MaterialNeeded)
    {
        Debug.Log("Command called");
        MaterialGot++;
        RpcUpdateRoles(MaterialGot, MaterialNeeded);
        GameObject.Find("Local").GetComponent<BuildingProgress>().UpdateOtherPlayerScore(MaterialGot, MaterialNeeded);
    }

    [ClientRpc]
    void RpcUpdateRoles(int MaterialGot, int MaterialNeeded)
    {
        if (!isServer)
        {
            GameObject.Find("Local").GetComponent<BuildingProgress>().UpdateScore(MaterialGot, MaterialNeeded);
            //if (GameObject.Find("Role").GetComponent<RoleScript>().RoleName.Equals("Designer"))
            //{
            //    NumberDesigns++;
            //}

            //if (GameObject.Find("Role").GetComponent<RoleScript>().RoleName.Equals("Painter"))
            //{
            //    NumberPaint++;
            //}

            //if (GameObject.Find("Role").GetComponent<RoleScript>().RoleName.Equals("Bricklayer"))
            //{
            //    NumberWood++;
            //}

            //if (GameObject.Find("Role").GetComponent<RoleScript>().RoleName.Equals("Carpenter"))
            //{
            //    NumberWood++;
            //}
        }
    }

    [ClientRpc]
    void RpcUpdateRoles2(int MaterialGot, int MaterialNeeded)
    {
        if (!isServer)
        {
            ++MaterialGot;
            GameObject.Find("Local").GetComponent<BuildingProgress>().UpdateOtherPlayerScore(MaterialGot, MaterialNeeded);
        }
    }

    public void IncreaseMat(int MaterialGot, int MaterialNeeded)
    {
        MaterialGot++;
        Debug.Log(MaterialGot + " , " + MaterialNeeded);
        UpdateScore(MaterialGot, MaterialNeeded);
    }

}
