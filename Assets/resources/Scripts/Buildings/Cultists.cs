using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cultists : Building
{
    private bool manned = false;
    new string buildingName = "Cultist temple";

    // Start is called before the first frame update
    void Start()
    {
        maxWorkers = 5;
        workers = 0;
        ItemCostClass item = utilityScript.findCost("Cult");
        lumberCost = item.lumberCost;
        coinCost = item.moneyCost;
    }

    // Update is called once per frame
    void Update()
    {
        if (workers > 0 && !manned)
        {
            manned = true;
            workManager.IncreaseDie(1);
            Debug.Log("Die increased by " + workManager.getDieMax());
        }
        if (workers == 0 && manned)
        {
            manned = false;
            workManager.IncreaseDie(-1);
            Debug.Log(workManager.getDieMax());
        }
    }
}
