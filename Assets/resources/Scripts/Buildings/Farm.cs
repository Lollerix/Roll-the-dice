using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Farm : Building
{
    void Start()
    {
        maxWorkers = 2;
        workers = 0;
        ItemCostClass item = UtilsScript.findCost("Farm");
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
                int food = Working();
                mainManager.foodCount += food;
                if (mainManager.foodCount > 999)
                {
                    mainManager.foodCount = 999;
                }
            }
        }
    }
}
