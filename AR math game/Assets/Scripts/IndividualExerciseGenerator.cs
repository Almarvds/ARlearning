using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IndividualExerciseGenerator : MonoBehaviour {

    public GameObject ExerciseScreen;

    public Text exercise;
    public GameObject NextButton;
    public GameObject Answer1button;
    public GameObject Answer2button;
    public GameObject Answer3button;
    public GameObject Answer4button;
    public Text Answer1Text;
    public Text Answer2Text;
    public Text Answer3Text;
    public Text Answer4Text;
    public GameObject SetBuildingGoal;

    private int correctAnswerNumber;
    public Sprite yesButton;
    public Sprite noButton;
    public Sprite yellowButton;
    private bool NoAnswerClicked;

    public void Start()
    {
        Answer1button.GetComponent<Button>().onClick.AddListener(() => EvaluateAnswer(0, Answer1button));
        Answer2button.GetComponent<Button>().onClick.AddListener(() => EvaluateAnswer(1, Answer2button));
        Answer3button.GetComponent<Button>().onClick.AddListener(() => EvaluateAnswer(2, Answer3button));
        Answer4button.GetComponent<Button>().onClick.AddListener(() => EvaluateAnswer(3, Answer4button));
    }

    public void ShowExerciseScreen()
    {
        if (SetBuildingGoal.GetComponent<SetBuildingGoal>().HasGoal == true)
        {
            ExerciseScreen.SetActive(true);
            GenerateNewExercise();        
        }
    }

    public void HideExerciseScreen()
    {
        ExerciseScreen.SetActive(false);
    }

    public void GenerateNewExercise()
    {
        String material = GameObject.Find("Local").GetComponent<BuildingProgress>().ReturnMaterial();
        NoAnswerClicked = true;
        int variableA= UnityEngine.Random.Range(0,40);
        int variableB = UnityEngine.Random.Range(0, 40);
        int correctAnswer = variableA + variableB;
        int[] wrongAnswer = new int[3];
        string[] answertext = new string[4];
        wrongAnswer[0] = UnityEngine.Random.Range(-10, -5) + correctAnswer;
        wrongAnswer[1] = UnityEngine.Random.Range(-5, 5) + correctAnswer;
        while (wrongAnswer[1]==correctAnswer)
        {
            wrongAnswer[1] = UnityEngine.Random.Range(-5, 5) + correctAnswer;
        }
        wrongAnswer[2] = UnityEngine.Random.Range(5, 10) + correctAnswer;

        int correctIndex = UnityEngine.Random.Range(0, 4);
        if (correctIndex == 4) correctIndex = 3;
        correctAnswerNumber = correctIndex;
        answertext[correctIndex] = correctAnswer.ToString();
        int i = 0;
        int j = 0;
        while (i<4)
        {
            if (correctIndex != i)
            {
                answertext[i] = wrongAnswer[j].ToString();
                i++;
                j++;
            } else
            {
                i++;
            }
        }

        Answer1Text.text = answertext[0];
        Answer2Text.text = answertext[1];
        Answer3Text.text = answertext[2];
        Answer4Text.text = answertext[3];

        exercise.text = "If you need " + variableA + " "+ material + " + " + variableB + " " + material + ", how many " +material + " would you need in total?";
    }

    public void EvaluateAnswer(int i,GameObject button)
    {
        if (i == correctAnswerNumber && NoAnswerClicked)
        {
           rightAnswer(button);
        } else
        {
            wrongAnswer(button);
        }
    }

    public void rightAnswer(GameObject button)
    {
        NoAnswerClicked = false;
        button.GetComponent<Image>().sprite = yesButton;
        NextButton.SetActive(true);
        GameObject.Find("Local").GetComponent<BuildingProgress>().IncreaseMaterial();
    }

    public void wrongAnswer(GameObject button)
    {
        NoAnswerClicked = false;
        button.GetComponent<Image>().sprite = noButton;
        NextButton.SetActive(true);
    }

    public void ResetButtonColor()
    {
        Answer1button.GetComponent<Image>().sprite = yellowButton;
        Answer2button.GetComponent<Image>().sprite = yellowButton;
        Answer3button.GetComponent<Image>().sprite = yellowButton;
        Answer4button.GetComponent<Image>().sprite = yellowButton;
    }

 
}


