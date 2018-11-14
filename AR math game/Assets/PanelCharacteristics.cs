using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelCharacteristics : MonoBehaviour {

    public Button CorrectAnswer;
    public GameObject MainInterface;

	// Use this for initialization
	void Start () {
        gameObject.SetActive(false);
        CorrectAnswer.onClick.AddListener(PickedCorrect);
    }
	
    void PickedCorrect()
    {
        MainInterface.SetActive(true);
        gameObject.SetActive(false);
    }

	// Update is called once per frame
	void Update () {
		
	}
}
