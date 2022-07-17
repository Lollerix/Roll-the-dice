using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InfoPanel : MonoBehaviour
{
    private List<TextMeshProUGUI> list = new List<TextMeshProUGUI>();
    private GameObject gameManagerObject;
    private GameManager gameManager;
    private void AddDescendantsWithTag(Transform parent, string tag)
    {
        foreach (Transform child in parent)
        {
            if (child.gameObject.tag == tag)
            {
                list.Add(child.gameObject.GetComponent<TextMeshProUGUI>());
            }
        }
    }

    void Start()
    {
        AddDescendantsWithTag(transform, "Text");
        gameManagerObject = GameObject.Find("GameManager");
        gameManager = gameManagerObject.GetComponent<GameManager>();
    }

    void Update()
    {
        list[0].SetText(gameManager.lumberCount.ToString());
        list[1].SetText(gameManager.coinCount.ToString());
        list[2].SetText(gameManager.workerEmployed.ToString());
        list[3].SetText(gameManager.workerCount.ToString());
        list[4].SetText(gameManager.foodCount.ToString());
    }
}
