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
    private int dieBase;
    private int dieMax;
    private int maxWorkers;
    private int workers;

    public void Start()
    {
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
        WorkManager wm = GameObject.Find("WorkManager").GetComponent<WorkManager>();
        dieBase = wm.getBaseMax();
        dieMax = wm.getDieMax();
#if UNITY_EDITOR
        workers = 1;
        maxWorkers = 5;
        workerTxt.text = workers.ToString();
        maxWorkerTxt.text = maxWorkers.ToString();
        for (int i = 0; i < workers; i++)
        {
            dice[i].Restart();
        }
        minRangeTxt.text = (workers * dieBase).ToString();
        maxRangeTxt.text = (workers * dieMax).ToString();
#endif
    }
    public void Initialize(Building building)
    {
        workers = building.workers;
        maxWorkers = building.maxWorkers;
        workerTxt.text = workers.ToString();
        for (int i = 0; i < workers; i++)
        {
            dice[i].Restart();
        }
        minRangeTxt.text = (workers * dieBase).ToString();
        maxRangeTxt.text = (workers * dieMax).ToString();
        titleTxt.text = building.buildingName;
    }
    public void Awake()
    {

    }

    public void IncreaseWorkers()
    {
        if (gm.workerEmployed == gm.workerCount) { return; } //Error message
        if (workers + 1 > maxWorkers) { return; } //Error message
        workers++;
        workerTxt.text = workers.ToString();
        dice[workers - 1].Restart();
        minRangeTxt.text = (workers * dieBase).ToString();
        maxRangeTxt.text = (workers * dieMax).ToString();
    }
    public void DecreaseWorkers()
    {
        if (workers - 1 < 0) return;
        workers--;
        dice[workers].Stop();
        workerTxt.text = workers.ToString();
        minRangeTxt.text = (workers * dieBase).ToString();
        maxRangeTxt.text = (workers * dieMax).ToString();

    }
}
