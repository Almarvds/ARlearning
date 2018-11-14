using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClickDesigner : MonoBehaviour {

    public GameObject materials;
    public Button btn;
    MaterialRole reference;

    // Use this for initialization
    void Start()
    {
        btn.onClick.AddListener(ButtonClick);
    }

    void ButtonClick()
    {
        Debug.Log("Painter clicked: current number" + materials.GetComponent<MaterialRole>().Occupation);
        reference = materials.GetComponent<MaterialRole>();
        reference.OccupationSet(3);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
