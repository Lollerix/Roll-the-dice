using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UIElements;

public class GridController : MonoBehaviour
{
    private Grid grid;
    [SerializeField] private Tilemap worldMap;
    [SerializeField] private Tilemap buildings;
    [SerializeField] private Tilemap interactive;
    [SerializeField] private Tile hoverTile;
    [SerializeField] private Tile buildTile;
    private Vector3 previousMousePos;
    // Start is called before the first frame update
    void Start()
    {
        grid = gameObject.GetComponent<Grid>();

    }
    void Update()
    {
        // Mouse over -> highlight tile
        Vector3Int mousePos = GetMousePosition();
        if (!mousePos.Equals(previousMousePos))
        {
            interactive.SetTile(new Vector3Int((int)previousMousePos.x, (int)previousMousePos.y,
            (int)previousMousePos.z), null); // Remove old hoverTile
            interactive.SetTile(mousePos, hoverTile);
            previousMousePos = mousePos;
        }

        // Left mouse click -> add path tile
        if (Input.GetMouseButton(0))
        {
            buildings.SetTile(mousePos, buildTile);
        }

        // Right mouse click -> remove path tile
        if (Input.GetMouseButton(1))
        {
            buildings.SetTile(mousePos, null);
        }

    }



    Vector3Int GetMousePosition()
    {
        Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        return grid.WorldToCell(mouseWorldPos);
    }
}
