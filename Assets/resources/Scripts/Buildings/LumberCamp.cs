using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LumberCamp : Building
{
    void Start()
    {
        maxWorkers = 3;
        workers = 0;
        ItemCostClass item = utilityScript.findCost("Lumber");
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
                int lumber = Working();
                Debug.Log(lumber);
                mainManager.lumberCount += lumber;
            }
        }
    }

}
