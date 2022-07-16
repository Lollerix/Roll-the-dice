using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dock : Building
{
    new string buildingName = "Docks";
    // Start is called before the first frame update
    void Start()
    {
        lumberCost = 100;
        coinCost = 100;
        maxWorkers = 5;
        workers = 0;

    }

    // Update is called once per frame
    void Update()
    {
        if (workers > 0)
        {
            if (mainManager.getProduction())
            {
                int coin = Working();
                mainManager.coinCount += coin;
            }
        }
    }
}
