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
    [HideInInspector] public Building buildingTile = null;


    private Vector3Int previousMousePos = new Vector3Int();

    // Start is called before the first frame update
    void Start()
    {
        grid = gameObject.GetComponent<Grid>();
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
        if (Input.GetMouseButton(0) && !IsOverUI())
        {
            if (buildings.GetTile(mousePos) == null || !buildings.GetTile(mousePos).Equals(buildingTile.displayImage))
            {
                buildings.SetTile(mousePos, buildingTile.displayImage);
                Vector3 a = mousePos;
                Instantiate(buildingTile, a, transform.rotation);
            }
        }

        // Right mouse click -> remove path tile
        if (Input.GetMouseButton(1))
        {
            buildings.SetTile(mousePos, null);
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

    public void TestCall(string v)
    {
        Debug.Log(v);
    }
}