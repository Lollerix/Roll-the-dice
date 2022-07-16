using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainManager : MonoBehaviour
{
    public int lumberCount = 0;
    public int foodCount = 0;
    public int workerCount = 0;
    public int coinCount = 0;
    float productionTime = 1.3f;
    float lastTimeActive;
    private bool productionActivated = false;
    // Start is called before the first frame update
    void Start()
    {
        lumberCount = 50;
        foodCount = 100;
        coinCount = 100;
        workerCount = 3;
        lastTimeActive = Time.time;
    }

    void Update()
    {
        if (Time.time - lastTimeActive >= productionTime)
        {
            lastTimeActive = Time.time;
            productionActivated = true;
        }
        else
        {
            productionActivated = false;
        }
    }

    public bool getProduction()
    {
        return productionActivated;
    }

}
