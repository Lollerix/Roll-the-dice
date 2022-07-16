using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainManager : MonoBehaviour
{
    public int lumberCount = 0;
    public int workerCount = 0;
    public int coinCount = 0;
    // Start is called before the first frame update
    void Start()
    {
        lumberCount = 50;
        coinCount = 100;
        workerCount = 3;
    }

}
