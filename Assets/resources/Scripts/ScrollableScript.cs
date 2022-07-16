using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScrollableScript : MonoBehaviour
{
    public Button[] buttons;
    public GridController gridControllerScript;
    // Start is called before the first frame update
    void Start()
    {
        foreach (Button button in buttons)
        {
            Button btn = button.GetComponent<Button>();
            btn.onClick.AddListener(() => ButtonClicked(btn.tag));
        }
    }

    void ButtonClicked(string tag)
    {
        GameObject buildingObj;
        switch (tag)
        {
            case "Smith":
                buildingObj = (GameObject)Resources.Load("Prefabs/Blacksmith", typeof(GameObject));
                gridControllerScript.buildingTile = buildingObj.GetComponent<Blacksmith>();
                break;

            case "Lumber":
                buildingObj = (GameObject)Resources.Load("Prefabs/LumberCamp", typeof(GameObject));
                gridControllerScript.buildingTile = buildingObj.GetComponent<LumberCamp>();
                break;

            case "Farm":
                buildingObj = (GameObject)Resources.Load("Prefabs/Farm", typeof(GameObject));
                gridControllerScript.buildingTile = buildingObj.GetComponent<Farm>();
                break;

            case "House":
                buildingObj = (GameObject)Resources.Load("Prefabs/House", typeof(GameObject));
                gridControllerScript.buildingTile = buildingObj.GetComponent<House>();
                break;

            case "Cult":
                buildingObj = (GameObject)Resources.Load("Prefabs/Cultists", typeof(GameObject));
                gridControllerScript.buildingTile = buildingObj.GetComponent<Cultists>();
                break;

            default:
                gridControllerScript.TestCall("Sono in default");
                break;
        }
    }


}
