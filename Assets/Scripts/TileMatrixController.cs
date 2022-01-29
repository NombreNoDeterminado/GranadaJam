using System;
using UnityEngine;

public class TileMatrixController : MonoBehaviour
{
    public static TileMatrixController Instance;

    private const int Width = 5, Height = 5;

    private TileController[][] _tiles =
    {
        new TileController[5], new TileController[5], new TileController[5], new TileController[5],
        new TileController[5]
    };

    // Start is called before the first frame update
    private void Start()
    {
        Instance = this;
        var tiles = GameObject.FindObjectsOfType<TileController>();


        for (var i = 0; i < Width; i++)
        {
            for (var j = 0; j < Height; j++)
            {
                _tiles[i][j] = Array.Find(tiles, obj => obj.xCoordinate.Equals(i) && obj.yCoordinate.Equals(j));
            }
        }
    }

    public void TriggerTileClick(string tileName)
    {
        var currentTrap = TrapSelector.Instance.SelectedTrap;
        var coordinates = tileName.Substring(4);
    }
}