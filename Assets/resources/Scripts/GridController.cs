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
    public Building buildingTile = null;


    private Vector3Int previousMousePos = new Vector3Int();

    // Start is called before the first frame update
    void Start()
    {
        grid = gameObject.GetComponent<Grid>();
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
        buildingTile = buildingObject.GetComponent<Building>();
    }

    // Update is called once per frame
    void Update()
    {
        // Mouse over -> highlight tile
        Vector3Int mousePos = GetMousePosition();
        if (!mousePos.Equals(previousMousePos))
        {
            //mousePos = new Vector3Int(mousePos.x, mousePos.y, 1);
            interactive.SetTile(previousMousePos, null); // Remove old hoverTile
            interactive.SetTile(mousePos, hoverTile);
            previousMousePos = mousePos;
        }

        // Left mouse click -> add path tile
        if (Input.GetMouseButton(0) && !IsOverUI())
        {
            if (buildings.GetTile(mousePos) == null || !buildings.GetTile(mousePos).Equals(buildingTile.displayImage))
            {
                Debug.Log(mousePos);
                Debug.Log(grid.CellToLocal(mousePos));
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
        if (buildingTile.lumberCost <= gm.lumberCount && buildingTile.coinCost <= gm.coinCount)
        {
            Debug.Log(buildingTile.lumberCost);
            gm.lumberCount -= buildingTile.lumberCost; gm.coinCount -= buildingTile.coinCost;
            buildings.SetTile(grid.WorldToCell(mousePos), buildingTile.displayImage);
            GameObject obj = Instantiate(buildingObject, mousePos + new Vector3(0.08f, 0.08f, -1), transform.rotation);
        }
    }
    public void TestCall(string v)
    {
        Debug.Log(v);
    }
}