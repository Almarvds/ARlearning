using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClickCarpenter : MonoBehaviour {

    public GameObject MainInterface;
    public GameObject materials;
    public GameObject RolePanel;
    public Button btn;
    MaterialRole reference;

    // Use this for initialization
    void Start () {
        btn.onClick.AddListener(ButtonClick);
    }

    void ButtonClick()
    {
        Debug.Log("Carpenter clicked: current number" + materials.GetComponent<MaterialRole>().Occupation);
        reference = materials.GetComponent<MaterialRole>();
        reference.OccupationSet(1);
        RolePanel.SetActive(false);
        MainInterface.SetActive(true);
    }

    // Update is called once per frame
    void Update () {
		
	}
}
