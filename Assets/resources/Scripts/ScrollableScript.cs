using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScrollableScript : MonoBehaviour
{
    public List<Button> buttons;
    private GridController gridControllerScript;
    RectTransform rectTransform;
    private int lumberCost;
    private int moneyCost;

    private GameObject utilsScriptObject;
    private UtilsScript utilityScript;
    void Start()
    {
        gridControllerScript = GameObject.Find("Grid").GetComponent<GridController>();
        utilsScriptObject = GameObject.Find("UtilityScript");
        utilityScript = utilsScriptObject.GetComponent<UtilsScript>();

        rectTransform = GetComponent<RectTransform>();
        foreach (Button button in buttons)
        {
            Button btn = button.GetComponent<Button>();
            btn.onClick.AddListener(() => ButtonClicked(btn.name));
        }
        addButton("Blacksmith");
        addButton("Farm");
        addButton("House");
        addButton("Lumber Camp");
        addButton("Dice Temple");



    }

    void ButtonClicked(string name)
    {
        switch (name)
        {
            case "Blacksmith":
                gridControllerScript.buildingObject = (GameObject)Resources.Load("Prefabs/Blacksmith", typeof(GameObject));
                break;

            case "Lumber Camp":
                gridControllerScript.buildingObject = (GameObject)Resources.Load("Prefabs/LumberCamp", typeof(GameObject));
                break;

            case "Farm":
                gridControllerScript.buildingObject = (GameObject)Resources.Load("Prefabs/Farm", typeof(GameObject));
                break;

            case "House":
                gridControllerScript.buildingObject = (GameObject)Resources.Load("Prefabs/House", typeof(GameObject));
                break;

            case "Dice Temple":
                gridControllerScript.buildingObject = (GameObject)Resources.Load("Prefabs/Cultists", typeof(GameObject));
                break;

            default:
                gridControllerScript.TestCall("Sono in default");
                break;
        }
        gridControllerScript.transformInTile();
    }

    //Aggiunge il pulsante corrispondente al nome inserito.
    //Esempio: Inserisci "Farm" viene aggiunto il pulsante della farm nel riquadro destro della UI
    void addButton(String name)
    {
        Button button;
        switch (name)
        {
            case "Blacksmith":
                button = (Button)Resources.Load("Prefabs/Buttons/Blacksmith", typeof(Button)); break;

            case "Lumber Camp":
                button = (Button)Resources.Load("Prefabs/Buttons/Lumber Camp", typeof(Button)); break;

            case "Farm":
                button = (Button)Resources.Load("Prefabs/Buttons/Farm", typeof(Button)); break;
            case "House":
                button = (Button)Resources.Load("Prefabs/Buttons/House", typeof(Button)); break;

            case "Dice Temple":
                button = (Button)Resources.Load("Prefabs/Buttons/Dice Temple", typeof(Button)); break;

            default:
                gridControllerScript.TestCall("Sono in default");
                Debug.LogError("Selezionato edificio non riconosciuto");
                button = (Button)Resources.Load("Prefabs/Buttons/House", typeof(Button));
                break;
        }

        ItemCostClass itemCostClass = UtilsScript.findCost(name);
        lumberCost = itemCostClass.lumberCost;
        moneyCost = itemCostClass.moneyCost;

        Button instanciatedButton = Instantiate(button, new Vector3(0, 0, 0), new Quaternion(0, 0, 0, 0));
        instanciatedButton.transform.SetParent(gameObject.transform, false);
        instanciatedButton.onClick.AddListener(() => ButtonClicked(button.name));
        buttons.Add(instanciatedButton);

        rectTransform.sizeDelta += new Vector2(0, 50);
        rectTransform.position -= new Vector3(0, 25);



        Transform costElement = instanciatedButton.transform.GetChild(0);
        costElement.GetChild(0).GetComponent<TextMeshProUGUI>().text = lumberCost.ToString();
        costElement.GetChild(2).GetComponent<TextMeshProUGUI>().text = moneyCost.ToString();

    }

    public void returnToBaseOption()
    {
        this.transform.parent.transform.parent.gameObject.SetActive(false);
    }

}
