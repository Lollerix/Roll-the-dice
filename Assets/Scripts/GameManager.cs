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
    public int coinCount = 0;
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
