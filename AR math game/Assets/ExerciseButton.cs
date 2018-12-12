using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExerciseButton : MonoBehaviour {

    public Sprite Exercise_on;
    public GameObject button;

	void TargetSelected () {
        button.GetComponent<Image>().sprite = Exercise_on;
    }
}
