using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProgressData : MonoBehaviour {

    //public GameObject CharacterPanel;
    public GameObject CharacterButton;
    public GameObject returnButton;
    public Animator animator;

    public void ShowPanel()
    {
        animator.SetBool("isOpen", true);
        //CharacterPanel.SetActive(true);
        CharacterButton.SetActive(false);
        returnButton.SetActive(true);
    }

    public void HidePanel()
    {
        animator.SetBool("isOpen", false);
        //CharacterPanel.SetActive(false);
        CharacterButton.SetActive(true);
        returnButton.SetActive(false);
    }

}
