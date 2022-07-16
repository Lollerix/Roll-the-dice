using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cultists : Building
{
    private bool manned = false;
    void Start()
    {
        lumberCost = 300;
        coinCost = 500;
        maxWorkers = 1;
        workers = 0;
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
