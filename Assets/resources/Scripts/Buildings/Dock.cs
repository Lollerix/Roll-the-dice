using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dock : Building
{
    // Start is called before the first frame update
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

    }
}
