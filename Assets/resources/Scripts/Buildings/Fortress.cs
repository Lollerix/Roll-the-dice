using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fortress : Building
{
    void Start()
    {
        ItemCostClass item = UtilsScript.findCost("Fortress");
        lumberCost = item.lumberCost;
        coinCost = item.moneyCost;
        description = "This is a fortress." + System.Environment.NewLine + "Coming soon...";

    }


    // Update is called once per frame
    void Update()
    {

    }
}
