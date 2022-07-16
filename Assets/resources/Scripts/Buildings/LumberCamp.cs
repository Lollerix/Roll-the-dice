using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LumberCamp : Building
{
    // Start is called before the first frame update
    void Start()
    {
        lumberCost = 10;
        coinCost = 10;
        maxWorkers = 2;
        workers = 0;
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
