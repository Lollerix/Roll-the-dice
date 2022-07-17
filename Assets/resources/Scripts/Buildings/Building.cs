using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Building : MonoBehaviour
{
    public Tile displayImage;
    public WorkManager workManager;
    public GameManager mainManager;
    public int lumberCost = 0;
    public int coinCost = 0;
    public int maxWorkers;
    public int workers;
    public string buildingName;
    public AudioClip buildingSound;
    bool mouseOver = false;
    Vector3 mousePos;

    private GameObject utilsScriptObject;
    public UtilsScript utilityScript;

    void Awake()
    {

        utilsScriptObject = GameObject.Find("UtilityScript");
        utilityScript = utilsScriptObject.GetComponent<UtilsScript>();
        workManager = GameObject.Find("WorkManager").GetComponent<WorkManager>();
        mainManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    public virtual int Working()
    {
        return Random.Range((workManager.getBaseMax() * workers),
         (workManager.getDieMax() * workers) + workManager.getBaseMax());
    }
    private void OnMouseOver()
    {
        mouseOver = true;
        mousePos = Input.mousePosition;
    }

    private void OnMouseExit()
    {
        mouseOver = false;
    }

    private void OnGUI()
    {

        if (mouseOver && Input.GetMouseButtonDown(1))
        {
            mainManager.openOptionPanel(this);
        }
    }
}
