using System;
using UnityEngine;

public class TileMatrixController : MonoBehaviour
{
    public static TileMatrixController instance;

    private const int Width = 7, Height = 9;

    private TileController[][] _tiles =
    {
        new TileController[9], new TileController[9], new TileController[9], new TileController[9],
        new TileController[9], new TileController[9], new TileController[9]
    };

    // Start is called before the first frame update
    private void Start()
    {
        instance = this;
        var tiles = GameObject.FindObjectsOfType<TileController>();


        for (var i = 0; i < Width; i++)
        {
            for (var j = 0; j < Height; j++)
            {
                _tiles[i][j] = Array.Find(tiles, obj => obj.xCoordinate.Equals(i) && obj.yCoordinate.Equals(j));
            }
        }
    }

    public void TriggerTileClick(int xCoordinate, int yCoordinate)
    {
        var currentTrap = TrapSelector.instance.SelectedTrap;
        var steps = new[] {currentTrap.Orientation() ? 1 : 0, currentTrap.Orientation() ? 0 : 1};
        var remainingTilesToActivate = (currentTrap.Size() - 1) / 2;
        for (var i = 0; i <= remainingTilesToActivate; i++)
        {
            try
            {
                _tiles[xCoordinate + i * steps[0]][yCoordinate + i * steps[1]].SetTrap(currentTrap);
            }
            catch{}
            try
            {
                _tiles[xCoordinate - i * steps[0]][yCoordinate - i * steps[1]].SetTrap(currentTrap);
            }
            catch{}
        }
    }
}