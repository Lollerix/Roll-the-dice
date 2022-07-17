using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PanelManager : MonoBehaviour
{
    public GameObject optionPanel;
    public ImageAnimation[] dice;
    public TMP_Text titleTxt;
    public TMP_Text workerTxt;
    public TMP_Text maxWorkerTxt;
    public TMP_Text minRangeTxt;
    public TMP_Text maxRangeTxt;
    private GameManager gm;
    private WorkManager wm;
    private int dieBase;
    private int dieMax;
    private int maxWorkers;
    private int workers;
    private Building building;

    public void Start()
    {
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
        wm = GameObject.Find("WorkManager").GetComponent<WorkManager>();
        dieBase = wm.getBaseMax();
        dieMax = wm.getDieMax();
    }
    public void Initialize(Building building)
    {
        this.building = building;
        workers = building.workers;
        maxWorkers = building.maxWorkers;
        workerTxt.text = workers.ToString();
        for (int i = 0; i < workers; i++)
        {
            dice[i].Restart();
        }
        if (wm == null)
        {
            wm = GameObject.Find("WorkManager").GetComponent<WorkManager>();
        }
        dieBase = wm.getBaseMax();
        dieMax = wm.getDieMax();
        minRangeTxt.text = (workers * dieBase).ToString();
        maxRangeTxt.text = (workers * dieMax).ToString();
        titleTxt.text = building.buildingName;
        Debug.Log(dieBase + " " + dieMax);
    }
    public void Update()
    {
        if (this.building != null && this.building.buildingName.Equals("House"))
        {
            workers = building.workers;
            maxWorkers = building.maxWorkers;
            workerTxt.text = workers.ToString();
            int i = 0;
            for (; i < workers; i++)
            {
                if (!dice[i].play)
                    dice[i].Restart();
            }
            for (; i < maxWorkers; i++)
            {
                if (dice[i].play)
                    dice[i].Stop();
            }

        }
        if (wm == null)
        {
            wm = GameObject.Find("WorkManager").GetComponent<WorkManager>();
        }
        dieBase = wm.getBaseMax() * workers;
        dieMax = wm.getDieMax() * workers;

        minRangeTxt.text = (dieBase).ToString();
        maxRangeTxt.text = (dieMax + dieBase).ToString();
    }

    public void IncreaseWorkers()
    {
        if (gm.workerEmployed == gm.workerCount) { return; } //Error message
        if (workers + 1 > maxWorkers) { return; } //Error message
        workers++;
        building.workers++;
        workerTxt.text = workers.ToString();
        dice[workers - 1].Restart();
        minRangeTxt.text = (workers * dieBase).ToString();
        maxRangeTxt.text = (workers * dieMax).ToString();
    }
    public void DecreaseWorkers()
    {
        if (workers - 1 < 0) return;
        workers--;
        building.workers--;
        dice[workers].Stop();
        workerTxt.text = workers.ToString();
        minRangeTxt.text = (workers * dieBase).ToString();
        maxRangeTxt.text = (workers * dieMax).ToString();

    }
}
