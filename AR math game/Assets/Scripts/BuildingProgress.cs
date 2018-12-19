using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuildingProgress : MonoBehaviour {

    public GameObject Role;
    public Text YourScore;
    public int NumberBricks;
    public int NumberWood;
    public int NumberDesigns;
    public int NumberPaint;

    public int NeededBricks;
    public int NeededWood;
    public int NeededDesigns;
    public int NeededPaint;

    public void Start()
    {
        YourScore.text = "";
    }

    public void UpdateScore(int MaterialGot, int MaterialNeeded)
    {
        YourScore.text = MaterialGot + "/" + MaterialNeeded;
    }

    public void IncreaseMaterial()
    {
        if (Role.GetComponent<RoleScript>().RoleName.Equals("Designer"))
        {
            NumberDesigns++;
            UpdateScore(NumberDesigns, NeededDesigns);
        }

        if (Role.GetComponent<RoleScript>().RoleName.Equals("Painter"))
        {
            NumberPaint++;
            UpdateScore(NumberPaint, NeededPaint);
        }

        if (Role.GetComponent<RoleScript>().RoleName.Equals("Bricklayer"))
        {
            NumberWood++;
            UpdateScore(NumberBricks, NeededBricks);
        }

        if (Role.GetComponent<RoleScript>().RoleName.Equals("Carpenter"))
        {
            NumberWood++;
            UpdateScore(NumberWood, NeededWood);
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
    }
}
