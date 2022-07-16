using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public Texture2D cursorTexture;
    public CursorMode cursorMode = CursorMode.Auto;
    public Vector2 hotSpot = Vector2.zero;

    public int lumberCount = 0;
    public int foodCount = 0;
    public int workerCount = 0;
    public int workerEmployed = 0;
    public int coinCount = 0;
    private int foodReq = 2;
    [SerializeField] private int famineCounter = 0;
    float productionTime = 1.3f;
    float lastTimeActive;
    private bool productionActivated = false;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.SetCursor(cursorTexture, hotSpot, cursorMode);
        lumberCount = 50;
        foodCount = 100;
        coinCount = 100;
        workerCount = 3;
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
                    if (famineCounter > 10)
                    {
                        t.famine = true;
                        t.workers--;
                        workerCount--;
                        if (workerCount < 0) workerCount = 0;
                        if (t.workers < 0) t.workers = 0;
                    }
                }
                else
                {
                    t.famine = false;
                    famineCounter--;
                }
            }

        }
    }

    public bool getProduction()
    {
        return productionActivated;
    }
}
