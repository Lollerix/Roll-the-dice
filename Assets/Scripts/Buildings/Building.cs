using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Building : MonoBehaviour
{
    public Tile displayImage;
    public WorkManager workManager;
    public MainManager mainManager;
    protected int lumberCost = 0;
    protected int coinCost = 0;
    protected int maxWorkers;
    public int workers;

    protected float lastTimeActive;
    protected float productionTime;

    void Awake()
    {
        workManager = GameObject.Find("WorkManager").GetComponent<WorkManager>();
        mainManager = GameObject.Find("MainManager").GetComponent<MainManager>();
    }

    public virtual int Working()
    {
        return Random.Range((workManager.getBaseMax() * workers), (workManager.getDieMax() * workers));
    }
}
