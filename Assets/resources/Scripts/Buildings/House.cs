using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class House : Building
{
    public bool famine = false;
    void Start()
    {
        maxWorkers = 4;
        workers = 0;
        ItemCostClass item = UtilsScript.findCost("House");
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
                mainManager.coinCount += workers;
            }
        }
        if (mainManager.getProduction() && workers < maxWorkers && !famine)
        {
            workers++;
            mainManager.workerCount++;
        }

    }
}
