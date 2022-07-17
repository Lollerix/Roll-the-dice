using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LumberCamp : Building
{
    void Start()
    {
        maxWorkers = 3;
        workers = 0;
        ItemCostClass item = UtilsScript.findCost("Lumber Camp");
        lumberCost = item.lumberCost;
        coinCost = item.moneyCost;
        description = item.description;

    }


    // Update is called once per frame
    void Update()
    {
        if (workers > 0)
        {
            if (mainManager.getProduction())
            {
                int lumber = Working();
                mainManager.lumberCount += lumber;

                if (mainManager.lumberCount > 999)
                {
                    mainManager.lumberCount = 999;
                }
            }
        }
    }

}
