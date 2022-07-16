using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cultists : Building
{
    private bool manned = false;
    new string buildingName = "Cultist quarter";

    // Start is called before the first frame update
    void Start()
    {
        utilityScript = utilsScriptObject.GetComponent<UtilsScript>();
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
            Debug.Log(workManager.getDieMax());
        }
        if (workers == 0 && manned)
        {
            manned = false;
            workManager.IncreaseDie(-1);
            Debug.Log(workManager.getDieMax());
        }
    }
}
