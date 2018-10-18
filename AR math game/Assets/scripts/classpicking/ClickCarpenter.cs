using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClickCarpenter : MonoBehaviour {

    public GameObject materials;
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
        reference.OccupationSet(2);
    }

    // Update is called once per frame
    void Update () {
		
	}
}
