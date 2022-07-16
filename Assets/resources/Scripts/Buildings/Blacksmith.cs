using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blacksmith : Building
{
    private bool manned = false;
    
    void Start()
    {
    ItemCostClass item = utilityScript.findCost("Blacksmith");
    lumberCost = item.lumberCost;
    coinCost = item.moneyCost;
    }

    // Update is called once per frame
    void Update()
    {
        if (workers > 0 && !manned)
        {
            manned = true;
            workManager.IncreaseBase(1);
            Debug.Log(workManager.getBaseMax());
        }
        if (workers == 0 && manned)
        {
            manned = false;
            workManager.IncreaseBase(-1);
            Debug.Log(workManager.getBaseMax());
        }
    }

    void OnDestroy()
    {

    }
}
