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
        switch (tag)
        {
            case "Smith":
                gridControllerScript.TestCall("Sono in Smith");
                gridControllerScript.buildingTile = (Building) Resources.Load("Prefabs/Blacksmith", typeof(GameObject));
                break;

            case "Farm":
                gridControllerScript.TestCall("Sono in Farm");
                gridControllerScript.buildingTile = (Building) Resources.Load("Prefabs/Farm", typeof(GameObject));
                break;

            default:
                gridControllerScript.TestCall("Sono in default");
                break;
        }
    }

  
}