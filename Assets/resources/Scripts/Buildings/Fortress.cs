using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fortress : Building
{
     public GameObject utilsScriptObject;
    private UtilsScript utilityScript;
 
    // Start is called before the first frame update
    void Start()
    {
    utilityScript = utilsScriptObject.GetComponent<UtilsScript>();
    ItemCostClass item = utilityScript.findCost("Fortress");
    lumberCost = item.lumberCost;
    coinCost = item.moneyCost;
    }
    

    // Update is called once per frame
    void Update()
    {

    }
}
