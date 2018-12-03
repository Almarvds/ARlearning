using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadGame : MonoBehaviour {

    public Button StartButton;

	// Use this for initialization
	void Start () {
		StartButton.onClick.AddListener(LoadMenu);
	}
	
    void LoadMenu(){
        SceneManager.UnloadScene("main_menu");
        SceneManager.LoadScene("ARscene");
    }

	// Update is called once per frame
	void Update () {
		
	}
}
