using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartButtonScript : MonoBehaviour {

    public GameObject MapScreen;
    public GameObject StartScreen;
    public Button button;

	void Start () {
        button.onClick.AddListener(StartClicked);
	}
	
    void StartClicked()
    {
        StartScreen.SetActive(false);
        MapScreen.SetActive(true);
    }
}
