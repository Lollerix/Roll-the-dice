using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UIElements;

public class TestingScript : MonoBehaviour
{
    private Grid grid;
    [SerializeField] private Tilemap worldMap;
    [SerializeField] private Tilemap interactive;
    [SerializeField] private Tile hoverTile;
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


    }

    Vector3Int GetMousePosition()
    {
        Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        return grid.WorldToCell(mouseWorldPos);
    }
}
