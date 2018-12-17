using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class RoleScript : MonoBehaviour {

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

    public void SetRoleToDesigner()
    {
        Characterbutton.GetComponent<Image>().sprite = Designer;
        CharacterText.GetComponent<Image>().sprite = DesignerText;
        Characterbutton2.GetComponent<Image>().sprite = Designer;
        CharacterText2.GetComponent<Image>().sprite = DesignerText;
        Characterbutton3.GetComponent<Image>().sprite = Designer;
        RoleName = "Designer";
    }

    public void SetRoleToPainter()
    {
        Characterbutton.GetComponent<Image>().sprite = Painter;
        CharacterText.GetComponent<Image>().sprite = PainterText;
        Characterbutton2.GetComponent<Image>().sprite = Painter;
        CharacterText2.GetComponent<Image>().sprite = PainterText;
        Characterbutton3.GetComponent<Image>().sprite = Painter;
        RoleName = "Painter";
    }

    public void SetRoleToBricklayer()
    {
        Characterbutton.GetComponent<Image>().sprite = Bricklayer;
        CharacterText.GetComponent<Image>().sprite = BricklayerText;
        Characterbutton2.GetComponent<Image>().sprite = Bricklayer;
        CharacterText2.GetComponent<Image>().sprite = BricklayerText;
        Characterbutton3.GetComponent<Image>().sprite = Bricklayer;
        RoleName = "Bricklayer";
    }

    public void SetRoleToCarpenter()
    {
        Characterbutton.GetComponent<Image>().sprite = Carpenter;
        CharacterText.GetComponent<Image>().sprite = CarpenterText;
        Characterbutton2.GetComponent<Image>().sprite = Carpenter;
        CharacterText2.GetComponent<Image>().sprite = CarpenterText;
        Characterbutton3.GetComponent<Image>().sprite = Carpenter;
        RoleName = "Carpenter";
    }
}
