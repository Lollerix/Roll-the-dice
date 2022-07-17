using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public GameObject optionsObj;

    public int lumberCount = 0;
    public int foodCount = 0;
    public int workerCount = 0;
    public int workerEmployed = 0;
    public int coinCount = 0;
    private int foodReq = 2;
    [SerializeField] private int famineCounter = 0;
    private int famineTreshold = 5;
    float productionTime = 1.3f;
    float eatTime = 2.6f;
    float lastTimeActive;
    float lastEatTime;
    private bool productionActivated = false;
    private bool eating = false;

    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 60;
        lumberCount = 150;
        foodCount = 50;
        coinCount = 100;
        workerCount = 0;
        lastTimeActive = Time.time;
        lastEatTime = lastTimeActive;
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
            if (Time.time - lastEatTime >= eatTime)
            {
                lastEatTime = Time.time;
                calculateFood();
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
                if (foodCount <= 0)
                {
                    famineCounter++;
                    if (famineCounter > famineTreshold)
                    {
                        t.famine = true;
                        death(t);
                    }
                    if (foodCount < -30) foodCount = -30;
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
        GameObject[] array = GameObject.FindGameObjectsWithTag("Workplace");
        GameObject elem = array[Random.Range(0, array.Length)];
        Building w = elem.GetComponent<Building>();
        t.workers--;
        if (t.workers < 0) { t.workers = 0; }
        workerCount--;
        if (workerCount < 0) { workerCount = 0; }
        w.workers--;
        if (w.workers < 0) { w.workers = 0; }
        workerEmployed--;
        if (workerEmployed < 0) { workerEmployed = 0; }
    }

    public void openOptionPanel(Building building)
    {

        if (optionsObj.activeSelf) closeOptionPanel(optionsObj);
        AudioSource x = gameObject.GetComponent<AudioSource>();
        x.clip = building.buildingSound;
        if (x.isPlaying) x.Stop();
        x.Play();
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
    public bool getEatTime()
    {
        return eating;
    }

    public void loadScene(int i)
    {
        if (i == 0)
            UnityEngine.Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);

        SceneManager.LoadScene(i, LoadSceneMode.Single);
    }
}
