using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fortress : Building
{
    void Start()
    {
    ItemCostClass item = utilityScript.findCost("Fortress");
    lumberCost = item.lumberCost;
    coinCost = item.moneyCost;
    }
    

    // Update is called once per frame
    void Update()
    {

    }
}
