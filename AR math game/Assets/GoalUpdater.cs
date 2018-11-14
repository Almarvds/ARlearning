using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GoalUpdater : MonoBehaviour {

    int MaterialNeeded=0;
    int Materialgot=0;
    public GameObject goalScript;
    public GameObject MaterialRole;
    MaterialRole Role;
    public Text MaterialScore;
    Goal SetGoal;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        Role = MaterialRole.GetComponent<MaterialRole>();
        SetGoal = goalScript.GetComponent<Goal>();
        if (Role.Occupation == 1)
        {
            MaterialNeeded = SetGoal.neededWood;
        }
        else if (Role.Occupation == 2)
        {
            MaterialNeeded = SetGoal.neededPaint;
        }
        else
        {
            MaterialNeeded = SetGoal.neededDesigns;
        }
        

        MaterialScore.text = Materialgot + "/" + MaterialNeeded;
	}
}
