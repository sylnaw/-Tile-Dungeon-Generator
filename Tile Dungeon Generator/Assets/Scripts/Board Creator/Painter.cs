using System;
using UnityEngine;
using UnityEngine.Tilemaps;

[Serializable]
public class Painter
{
    public TileBase tile;
    private const int wallTile = 1;

    public void DrawRectangleRoom(Vector2Int startPosition, Vector2Int endPosition, Tilemap tilemap)
    {
        if (tile != null)
        {
            for (int i = startPosition.x - wallTile; i <= endPosition.x + wallTile; i++)
            {
                for (int j = startPosition.y - wallTile; j <= endPosition.y + wallTile; j++)
                {
                    tilemap.SetTile(new Vector3Int(i, j, 0), tile);
                }
            }
        }
    }
}
