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
        productionTime = 1.3f;
        lastTimeActive = Time.time;
    }


    // Update is called once per frame
    void Update()
    {
        if (workers > 0)
        {
            if (Time.time - lastTimeActive >= productionTime)
            {
                Debug.Log("Activate");
                lastTimeActive = Time.time;
                int food = Working();
                Debug.Log(food);
                mainManager.foodCount += food;
            }
        }
    }
}
