using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class House : Building
{
    private int foodReq = 2;
    private bool famine = false;
    private int famineCounter = 0;
    void Start()
    {
        lumberCost = 30;
        coinCost = 80;
        maxWorkers = 4;
        workers = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (workers > 0 && mainManager.getProduction())
        {
            mainManager.foodCount -= (workers * foodReq);
            if (mainManager.foodCount < 0)
            {
                famineCounter++;
                if (famineCounter > 10)
                {
                    workers -= 1;
                    mainManager.workerCount--;
                    if (mainManager.workerCount < 0) mainManager.workerCount = 0;
                    if (workers < 0) workers = 0;
                }
            }
            else
            {
                famineCounter--;
                if (famineCounter < 0) famineCounter = 0;
            }
        }
        if (mainManager.getProduction() && workers < maxWorkers)
        {
            workers++;
            mainManager.workerCount++;
        }
    }
}
