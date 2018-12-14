using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MapSelectScript : MonoBehaviour {

    public GameObject MapScreen;
    public GameObject GroupScreen;
    public Button button;

    void Start()
    {
        button.onClick.AddListener(StartClicked);
    }

    void StartClicked()
    {
        GroupScreen.SetActive(true);
        MapScreen.SetActive(false);
    }
}
