using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelCharacteristics : MonoBehaviour {

    public Button CorrectAnswer;
    public GameObject MainInterface;
    public Button exit;
    public GameObject MaterialScore;
    int score;

    // Use this for initialization
    void Start () {
        gameObject.SetActive(false);
        CorrectAnswer.onClick.AddListener(PickedCorrect);
        exit.onClick.AddListener(clickedExit);
    }
	
    void clickedExit()
    {
        MainInterface.SetActive(true);
        gameObject.SetActive(false);
    }

    void PickedCorrect()
    {
        MainInterface.SetActive(true);
        gameObject.SetActive(false);
        GoalUpdater goalUpdater = MaterialScore.GetComponent<GoalUpdater>();
        goalUpdater.Materialgot++;
    }

	// Update is called once per frame
	void Update () {
		
	}
}
