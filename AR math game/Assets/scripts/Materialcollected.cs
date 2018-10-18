using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Materialcollected : MonoBehaviour {

    public Button btn;
    public Text MaterialScore;
    public int Scoring;
    public int MaterialsNeeded;

    // Use this for initialization
    void Start () {
        btn.onClick.AddListener(ButtonClick);
        MaterialScore.text = Scoring + "/" + MaterialsNeeded;
    }
	
    void ButtonClick()
    {
        Debug.Log("button clicked");
        Scoring++;
        MaterialScore.text = Scoring + "/" + MaterialsNeeded;
    }
	// Update is called once per frame
	void Update () {
		
	}
}
