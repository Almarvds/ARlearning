using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChooseRole : MonoBehaviour {

    public GameObject RolePanel;
    public GameObject MainInterface;
    public Button RoleButton;

	// Use this for initialization
	void Start () {
        RolePanel.SetActive(false);
        RoleButton.onClick.AddListener(RoleButtonClicked);
    }
	
    void RoleButtonClicked()
    {
        MainInterface.SetActive(false);
        RolePanel.SetActive(true);
    }

	// Update is called once per frame
	void Update () {
		
	}
}
