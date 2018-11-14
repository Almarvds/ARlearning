using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour {

    public int neededWood;
    public int neededPaint;
    public int neededDesigns;

	// Use this for initialization
	void Start () {
		
	}
	
    public void newGoal(int wood, int paint, int designs)
    {
        neededDesigns = designs;
        neededPaint = paint;
        neededWood = wood;
    }

	// Update is called once per frame
	void Update () {
		
	}
}
