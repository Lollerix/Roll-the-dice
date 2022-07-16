using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class House : Building
{
    public bool famine = false;
    new string buildingName;

    // Start is called before the first frame update
    void Start()
    {
        utilityScript = utilsScriptObject.GetComponent<UtilsScript>();
        ItemCostClass item = utilityScript.findCost("House");
        lumberCost = item.lumberCost;
        coinCost = item.moneyCost;
        lumberCost = 30;
        coinCost = 80;
        maxWorkers = 4;
        workers = 0;
        buildingName = "House";
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
