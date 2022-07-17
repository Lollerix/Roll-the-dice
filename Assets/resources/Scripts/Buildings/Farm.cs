using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Farm : Building
{
    void Start()
    {
        maxWorkers = 2;
        workers = 0;
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
