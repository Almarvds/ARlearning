using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoleSelect : MonoBehaviour {

    public Button button;
    public GameObject _RoleSelect;
    public GameObject _MainInterface;

    void Start () {
        GetComponent<Button>().onClick.AddListener(SelectRole);
    }
	
    private void SelectRole()
    {
        NextScreen();
    }

    public void NextScreen()
    {
        _RoleSelect.SetActive(false);
        _MainInterface.SetActive(true);
    }
}
