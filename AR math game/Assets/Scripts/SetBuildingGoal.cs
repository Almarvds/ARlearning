using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetBuildingGoal : MonoBehaviour
{

    //panel variables
    public GameObject GoalSettingPanel;
    public Text PanelTitle;
    public Text PanelDescription;

    //exercise button turning green
    public Sprite button_On;
    public bool HasGoal;
    public GameObject ExerciseButton;

    //needed materials
    public Text WoodNeeded;
    public Text DesignsNeeded;
    public Text BricksNeeded;
    public Text PaintNeeded;

    //private Building variables
    public GameObject BuildingProgress;
    private String BuildingName;
    Building selectedBuilding = new Building();

    //sets the data on the goal setting panel to that of the clicked building.
    void BuildingClicked()
    {
        selectedBuilding.isBuilding(BuildingName);
        PanelTitle.text = selectedBuilding.Name;
        PanelDescription.text = selectedBuilding.description;
        BricksNeeded.text = "X" + selectedBuilding.Bricks;
        WoodNeeded.text = "X" + selectedBuilding.Wood;
        PaintNeeded.text = "X" + selectedBuilding.Paint;
        DesignsNeeded.text = "X" + selectedBuilding.Designs;
        GoalSettingPanel.SetActive(true);
    }

    void HidePanel()
    {
        GoalSettingPanel.SetActive(false);
    }

    //checks for clicked building
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                BuildingName = hit.transform.name;
                Debug.Log("clicked " + BuildingName);
                BuildingClicked();
            }
        }
    }

    public void SetGoal()
    {

        HasGoal = true;
        BuildingProgress.GetComponent<BuildingProgress>().BuildingSelected(selectedBuilding.Wood,selectedBuilding.Paint,selectedBuilding.Designs,selectedBuilding.Bricks);
        ChangeButton();
    }

    public void ChangeButton()
    {
        ExerciseButton.GetComponent<Image>().sprite = button_On;
    }

}
