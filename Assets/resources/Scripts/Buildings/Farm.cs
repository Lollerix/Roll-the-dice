using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Farm : Building
{
  public GameObject utilsScriptObject;
    private UtilsScript utilityScript;
 
    // Start is called before the first frame update
    void Start()
    {
    utilityScript = utilsScriptObject.GetComponent<UtilsScript>();
    ItemCostClass item = utilityScript.findCost("Farm");
    lumberCost = item.lumberCost;
    coinCost = item.moneyCost;
    }


    // Update is called once per frame
    void Update()
    {
        if (workers > 0)
        {
            if (mainManager.getProduction())
            {
                int food = Working();
                Debug.Log(food);
                mainManager.foodCount += food;
            }
        }
    }
}
