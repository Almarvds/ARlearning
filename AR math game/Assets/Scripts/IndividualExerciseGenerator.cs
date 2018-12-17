using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IndividualExerciseGenerator : MonoBehaviour {

    public bool HasGoal;
    public Sprite button_On;
    public GameObject ExerciseButton;
    public GameObject ExerciseScreen;

    public Text exercise;
    public GameObject Answer1button;
    public GameObject Answer2button;
    public GameObject Answer3button;
    public GameObject Answer4button;

    private int correctAnswerNumber;
    public Sprite yesButton;
    public Sprite noButton;


    public void Start()
    {
        Answer1button.GetComponent<Button>().onClick.AddListener(() => EvaluateAnswer(0,Answer1button));
        Answer2button.GetComponent<Button>().onClick.AddListener(() => EvaluateAnswer(1, Answer1button));
        Answer3button.GetComponent<Button>().onClick.AddListener(() => EvaluateAnswer(2, Answer1button));
        Answer4button.GetComponent<Button>().onClick.AddListener(() => EvaluateAnswer(3, Answer1button));
    }

    public void SetGoal()
    {
        HasGoal = true;
        ChangeButton();
    }

    public void ChangeButton()
    {
        ExerciseButton.GetComponent<Image>().sprite = button_On;
    }

    public void ShowExerciseScreen()
    {
        if (HasGoal)
        {
            GenerateNewExercise();
            ExerciseScreen.SetActive(true);
        }
    }

    public void HideExerciseScreen()
    {
        ExerciseScreen.SetActive(false);
    }

    public void GenerateNewExercise()
    {
        int variableA= Random.Range(0,40);
        int variableB = Random.Range(0, 40);
        int correctAnswer = variableA + variableB;
        int[] wrongAnswer = new int[3];
        string[] answertext = new string[4];
        wrongAnswer[0] = Random.Range(-10, -5) + correctAnswer;
        wrongAnswer[1] = Random.Range(-5, 5) + correctAnswer;
        while (wrongAnswer[1]==correctAnswer)
        {
            wrongAnswer[1] = Random.Range(-5, 5) + correctAnswer;
        }
        wrongAnswer[2] = Random.Range(5, 10) + correctAnswer;

        int correctIndex = Random.Range(0, 4);
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
        Answer1button.GetComponent<Text>().text = answertext[0];
        Answer2button.GetComponent<Text>().text = answertext[1];
        Answer3button.GetComponent<Text>().text = answertext[2];
        Answer4button.GetComponent<Text>().text = answertext[3];

        exercise.text = "what is the answer to: " + variableA + " + " + variableB + "?";
    }

    public void EvaluateAnswer(int i,GameObject button)
    {
        if (i == correctAnswerNumber)
        {
           rightAnswer(button);
        } else
        {
            wrongAnswer(button);
        }
    }

    public void rightAnswer(GameObject button)
    {
        button.GetComponent<Image>().sprite = yesButton;
    }

    public void wrongAnswer(GameObject button)
    {
        button.GetComponent<Image>().sprite = noButton;
    }

}


