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
        productionTime = 500;
    }


    // Update is called once per frame
    void Update()
    {
        if (workers > 0)
        {
            if (Time.time - lastTimeActive >= productionTime)
            {
                lastTimeActive = Time.time;
                int lumber = Working();
                mainManager.lumberCount += lumber;
            }
        }
    }

}
