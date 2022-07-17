using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UIElements;
using UnityEngine.EventSystems;
using System;

public class GridController : MonoBehaviour
{
    private Grid grid;
    [SerializeField] private Tilemap map = null;
    [SerializeField] private Tilemap buildings = null;
    [SerializeField] private Tilemap interactive = null;
    [SerializeField] private Tile hoverTile = null;
    private GameManager gm;
    public GameObject buildingObject = null;
    [HideInInspector] public Building buildingTile = null;
    public Tile openTerrain;

    [SerializeField] private bool isBuildingActive = false;

    private Vector3Int previousMousePos = new Vector3Int();

    // Start is called before the first frame update
    void Start()
    {

        grid = gameObject.GetComponent<Grid>();
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        // Mouse over -> highlight tile
        Vector3Int mousePos = GetMousePosition();
        if (!mousePos.Equals(previousMousePos))
        {
            interactive.SetTile(previousMousePos, null); // Remove old hoverTile
            interactive.SetTile(mousePos, hoverTile);
            previousMousePos = mousePos;
        }

        // Left mouse click -> add path tile
        if (Input.GetMouseButtonDown(0) && !IsOverUI() && isBuildingActive)
        {
            if (buildings.GetTile(mousePos) == null && map.GetTile(mousePos).Equals(openTerrain))
            {
                Build(grid.CellToLocal(mousePos));
            }
        }

    }

    private bool IsOverUI()
    {
        return EventSystem.current.IsPointerOverGameObject();
    }

    Vector3Int GetMousePosition()
    {
        Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        return grid.WorldToCell(mouseWorldPos);
    }

    private void Build(Vector3 mousePos)
    {
        if (gm == null)
        {
            gm = GameObject.Find("GameManager").GetComponent<GameManager>();
        }
        int lumberCost = UtilsScript.findCost(buildingTile.buildingName).lumberCost;
        int moneyCost = UtilsScript.findCost(buildingTile.buildingName).moneyCost;
        Debug.Log("Costi letti " + buildingTile.buildingName + ": " + lumberCost + " " + moneyCost);
        if (lumberCost <= gm.lumberCount && moneyCost <= gm.coinCount)
        {
            gm.lumberCount -= lumberCost;
            gm.coinCount -= moneyCost;
            buildings.SetTile(grid.WorldToCell(mousePos), buildingTile.displayImage);
            GameObject obj = Instantiate(buildingObject, mousePos + new Vector3(0.08f, 0.08f, -1), transform.rotation);
        }
    }
    public void TestCall(string v)
    {
        Debug.Log(v);
    }

    public void transformInTile()
    {
        buildingTile = buildingObject.GetComponent<Building>();
    }

    public void IsBuildingActive(bool boolean)
    {
        isBuildingActive = boolean;
        if (boolean == false)
        {
            buildingTile = null;
        }
    }
}