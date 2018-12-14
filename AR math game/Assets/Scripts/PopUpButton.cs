using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopUpButton : MonoBehaviour {

    public GameObject _button;
    Button button;
	
	void Start () {
        GetComponent<Button>().onClick.AddListener(Dissapear);
    }

    public void Dissapear()
    {
        _button.SetActive(false);
    }
	

}
