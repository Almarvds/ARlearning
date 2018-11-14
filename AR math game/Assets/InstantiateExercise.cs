using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InstantiateExercise : MonoBehaviour
{
    public GameObject Canvas;
    public GameObject Question;
    public Button Button;
    public Text exercise;
    public Text RightAnswer;
    public Text WrongAnswer;
    
    // Use this for initialization
    void Start()
    {
        Button.onClick.AddListener(ButtonClicked);
    }

    void ButtonClicked()
    {
        int a = UnityEngine.Random.Range(1, 10);
        int b = UnityEngine.Random.Range(1, 10);
        String exerciseText = a + " + " + b;
        exercise.text = exerciseText;   
        RightAnswer.text = (a+b).ToString();
        WrongAnswer.text = (a + b + UnityEngine.Random.Range(-5, 5)).ToString();
        Canvas.SetActive(false);
        Question.gameObject.SetActive(true);

    }

    // Update is called once per frame
    void Update()
    {
           
    }
}
