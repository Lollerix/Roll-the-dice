using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Building : MonoBehaviour
{
    public Tile displayImage;
    public WorkManager workManager;
    public GameManager mainManager;
    protected int lumberCost = 0;
    protected int coinCost = 0;
    protected int maxWorkers;
    public int workers;

    void Awake()
    {
        workManager = GameObject.Find("WorkManager").GetComponent<WorkManager>();
        mainManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    public virtual int Working()
    {
        return Random.Range((workManager.getBaseMax() * workers), (workManager.getDieMax() * workers));
    }
}
