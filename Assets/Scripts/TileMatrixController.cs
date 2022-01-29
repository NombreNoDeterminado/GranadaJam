using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileMatrixController : MonoBehaviour
{
    public static TileMatrixController Instance;

    private const int Width = 5, Height = 5;

    private GameObject[][] _tiles = new[]
        {new GameObject[5], new GameObject[5], new GameObject[5], new GameObject[5], new GameObject[5]};

    // Start is called before the first frame update
    private void Start()
    {
        Instance = this;

        var tiles = GameObject.FindGameObjectsWithTag("Tile");
        for (var i = 0; i < Width; i++)
        {
            for (var j = 0; j < Height; j++)
            {
                _tiles[i][j] = Array.Find(tiles, obj => obj.name == $"Grid{i}{j}");
            }
        }
        
        Debug.Log(_tiles);
    }

    public void TriggerTileClick(string tileName)
    {
        Debug.Log($"{tileName}");
    }
}