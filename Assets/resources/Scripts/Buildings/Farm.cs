using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Farm : Building
{
    void Start()
    {
        lumberCost = 20;
        coinCost = 60;
        maxWorkers = 4;
        workers = 0;
    }


    // Update is called once per frame
    void Update()
    {
        if (workers > 0)
        {
            if (mainManager.getProduction())
            {
                int food = Working();
                Debug.Log(food);
                mainManager.foodCount += food;
            }
        }
    }
}
