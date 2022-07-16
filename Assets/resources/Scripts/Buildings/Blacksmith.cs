using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blacksmith : Building
{
    private bool manned = false;
    new int lumberCost = 80;
    new int coinCost = 80;
    new int maxWorkers = 1;
    new int workers = 0;
    new string name = "Blacksmith";
    // Start is called before the first frame update
    void Start()
    {

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
