using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dock : Building
{
    void Start()
    {
    ItemCostClass item = utilityScript.findCost("Dock");
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
                int coin = Working();
                mainManager.coinCount += coin;
            }
        }
    }
}
