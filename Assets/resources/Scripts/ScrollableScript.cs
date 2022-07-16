using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScrollableScript : MonoBehaviour
{
    public List<Button> buttons;
    public GridController gridControllerScript;
    // Start is called before the first frame update
    RectTransform rectTransform;
    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        foreach (Button button in buttons)
        {
            Button btn = button.GetComponent<Button>();
            btn.onClick.AddListener(() => ButtonClicked(btn.name));
        }

        #if UNITY_EDITOR
        addButton("Smith");
        addButton("Farm");
        addButton("House");
        addButton("Lumber");

        #endif
    }

    void ButtonClicked(string name)
    {
        switch (name)
        {
            case "Smith":
                gridControllerScript.buildingObject = (GameObject)Resources.Load("Prefabs/Blacksmith", typeof(GameObject));
                break;

            case "Lumber":
                gridControllerScript.buildingObject = (GameObject)Resources.Load("Prefabs/LumberCamp", typeof(GameObject));
                break;

            case "Farm":
                gridControllerScript.buildingObject = (GameObject)Resources.Load("Prefabs/Farm", typeof(GameObject));
                break;

            case "House":
                gridControllerScript.buildingObject = (GameObject)Resources.Load("Prefabs/House", typeof(GameObject));
                break;

            case "Cult":
                gridControllerScript.buildingObject = (GameObject)Resources.Load("Prefabs/Cultists", typeof(GameObject));
                break;

            default:
                gridControllerScript.TestCall("Sono in default");
                break;
        }
    }


    //Aggiunge il pulsante corrispondente al nome inserito.
    //Esempio: Inserisci "Farm" viene aggiunto il pulsante della farm nel riquadro destro della UI
     void addButton(String name)
    {
        Button button;
        switch (name)
        {
            case "Smith":
                button = (Button)Resources.Load("Prefabs/Buttons/Smith", typeof(Button)); break;

            case "Lumber":
                button = (Button)Resources.Load("Prefabs/Buttons/Lumber", typeof(Button)); break;

            case "Farm":
                button = (Button)Resources.Load("Prefabs/Buttons/Farm", typeof(Button)); break;

            case "House":
                button = (Button)Resources.Load("Prefabs/Buttons/House", typeof(Button)); break;

            case "Cult":
                button = (Button)Resources.Load("Prefabs/Buttons/Cult", typeof(Button)); break;

            default:
                gridControllerScript.TestCall("Sono in default");
                Debug.LogError("Selezionato edificio non riconosciuto");
                button = (Button)Resources.Load("Prefabs/Buttons/House", typeof(Button)); 
                break;
        }

        Button instanciatedButton = Instantiate(button, new Vector3(0,0,0), new Quaternion(0,0,0,0));
        instanciatedButton.transform.SetParent(gameObject.transform, false);
        instanciatedButton.onClick.AddListener(() => ButtonClicked(button.name));
        buttons.Add(instanciatedButton);
        rectTransform.sizeDelta += new Vector2(0,50);
    }


}
