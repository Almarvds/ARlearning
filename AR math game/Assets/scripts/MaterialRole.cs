﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MaterialRole : MonoBehaviour {

    public int Occupation;
    Image materialImage;
    public Sprite Woodcutting; 
    public Sprite Painting; 
    public Sprite Designing; 

    // Use this for initialization
    void Start () {
        materialImage = GetComponent<Image>();
    }
	
    public void OccupationSet(int a)
    {
        Occupation = a;
    }
	// Update is called once per frame
	void Update () {

        if (Occupation ==1) {
            materialImage.sprite = Woodcutting;
        } else if (Occupation == 2)
        {
            materialImage.sprite = Painting;
        } else {
            materialImage.sprite = Designing;
        }
	}
}
