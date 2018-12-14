using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackButtonMapScript : MonoBehaviour {

    public GameObject CurrentScreen;
    public GameObject LastScreen;
    public Button button;

    void Start()
    {
        button.onClick.AddListener(BackClicked);
    }

    void BackClicked()
    {
        LastScreen.SetActive(true);
        CurrentScreen.SetActive(false);
    }
}
