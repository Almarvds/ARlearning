using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetGoal : MonoBehaviour {

    public Button btn;
    public GameObject building;
    public GameObject goalText;
    public GameObject goalScript;
    Goal GoalToSet;
    public Text Wood;
    public Text Paint;
    public Text Designs;
    Text _goal;

    

    // Use this for initialization
    void Start () {
        btn.onClick.AddListener(ButtonClick);
    }
	
    void ButtonClick()
    {
        int wood = Int32.Parse(Wood.text);
        int paint = Int32.Parse(Paint.text);
        int designs = Int32.Parse(Designs.text);

        Debug.Log("you want to build: " + building.name);
        _goal = goalText.GetComponent<Text>();
        _goal.text = building.name;
        GoalToSet = goalScript.GetComponent<Goal>();
        GoalToSet.newGoal(wood,paint,designs);
    }

	// Update is called once per frame
	void Update () {
		
	}
}
