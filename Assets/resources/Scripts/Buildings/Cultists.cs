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
        maxWorkers = 1;
        workers = 0;
        ItemCostClass item = UtilsScript.findCost("Dice Temple");
        lumberCost = item.lumberCost;
        coinCost = item.moneyCost;
        description = item.description;

    }

    // Update is called once per frame
    void Update()
    {
        if (workers > 0 && !manned)
        {
            manned = true;
            workManager.IncreaseDie(2);
            Debug.Log("Die increased by " + workManager.getDieMax());
        }
        if (workers == 0 && manned)
        {
            manned = false;
            workManager.IncreaseDie(-2);
            Debug.Log(workManager.getDieMax());
        }
    }
}
