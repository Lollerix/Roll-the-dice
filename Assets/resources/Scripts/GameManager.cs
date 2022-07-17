using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public Texture2D cursorTexture;
    public CursorMode cursorMode = CursorMode.Auto;
    public Vector2 hotSpot = Vector2.zero;
    public GameObject optionsObj;

    public int lumberCount = 0;
    public int foodCount = 0;
    public int workerCount = 0;
    public int workerEmployed = 0;
    public int coinCount = 0;
    private int foodReq = 2;
    [SerializeField] private int famineCounter = 0;
    private int famineTreshold = 50;
    float productionTime = 1.3f;
    float lastTimeActive;
    private bool productionActivated = false;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.SetCursor(cursorTexture, hotSpot, cursorMode);
        lumberCount = 150;
        foodCount = 800;
        coinCount = 100;
        workerCount = 0;
        lastTimeActive = Time.time;
    }

    void Update()
    {
        if (workerCount <= 0)
        {
            //Lose sequence
        }
        if (Time.time - lastTimeActive >= productionTime)
        {
            lastTimeActive = Time.time;
            productionActivated = true;
            calculateFood();
            if (lumberCount > 999)
            {
                lumberCount = 999;
            }
            if (foodCount > 999)
            {
                foodCount = 999;
            }
            if (coinCount > 999)
            {
                coinCount = 999;
            }
        }
        else
        {
            productionActivated = false;
        }
    }

    private void calculateFood()
    {
        GameObject[] array = GameObject.FindGameObjectsWithTag("House");
        if (array.Length != 0)
        {
            foreach (GameObject x in array)
            {
                House t = x.GetComponent<House>();
                foodCount -= (t.workers * foodReq);
                if (foodCount < 0)
                {
                    famineCounter++;
                    if (famineCounter > famineTreshold)
                    {
                        t.famine = true;
                        death(t);
                    }
                }
                else
                {
                    t.famine = false;
                    famineCounter--;
                    if (famineCounter < workerCount * -10)
                        famineCounter = workerCount * -10;
                }
            }

        }
    }
    private void death(House t)
    {
        t.workers--;
        workerCount--;
        workerEmployed--;
        GameObject[] array = GameObject.FindGameObjectsWithTag("Workplace");
        GameObject elem = array[Random.Range(0, array.Length)];
        Building w = elem.GetComponent<Building>();
        w.workers--;
        if (workerCount < 0) workerCount = 0;
        if (t.workers < 0) t.workers = 0;
    }

    public void openOptionPanel(Building building)
    {

        if (optionsObj.activeSelf) closeOptionPanel(optionsObj);
        PanelManager options = optionsObj.GetComponent<PanelManager>();
        options.Initialize(building);
        optionsObj.SetActive(true);

    }
    public void closeOptionPanel(GameObject optionsObj)
    {
        optionsObj.SetActive(false);
    }

    public bool getProduction()
    {
        return productionActivated;
    }
}
