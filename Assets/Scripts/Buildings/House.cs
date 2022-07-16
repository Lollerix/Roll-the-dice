using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class House : Building
{
    private int foodReq = 2;
    private int famineCounter = 0;
    public bool famine = false;
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
        if (mainManager.getProduction() && workers < maxWorkers && !famine)
        {
            workers++;
            mainManager.workerCount++;
        }
    }
}
