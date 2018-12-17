using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoleScript : MonoBehaviour {

    public string RoleName;
    public Image Characterbutton;
    public Image Characterbutton2;
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
        RoleName = "Designer";
    }

    public void SetRoleToPainter()
    {
        Characterbutton.GetComponent<Image>().sprite = Painter;
        CharacterText.GetComponent<Image>().sprite = PainterText;
        Characterbutton2.GetComponent<Image>().sprite = Designer;
        CharacterText2.GetComponent<Image>().sprite = DesignerText;
        RoleName = "Painter";
    }

    public void SetRoleToBricklayer()
    {
        Characterbutton.GetComponent<Image>().sprite = Bricklayer;
        CharacterText.GetComponent<Image>().sprite = BricklayerText;
        Characterbutton2.GetComponent<Image>().sprite = Designer;
        CharacterText2.GetComponent<Image>().sprite = DesignerText;
        RoleName = "Bricklayer";
    }

    public void SetRoleToCarpenter()
    {
        Characterbutton.GetComponent<Image>().sprite = Carpenter;
        CharacterText.GetComponent<Image>().sprite = CarpenterText;
        Characterbutton2.GetComponent<Image>().sprite = Designer;
        CharacterText2.GetComponent<Image>().sprite = DesignerText;
        RoleName = "Carpenter";
    }
}
