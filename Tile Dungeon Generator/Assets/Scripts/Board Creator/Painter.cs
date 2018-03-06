using System;
using UnityEngine;
using UnityEngine.Tilemaps;

[Serializable]
public class Painter
{
    public TileBase tile;

    public void DrawRectangleRoom(Vector2Int startPosition, Vector2Int endPosition, Tilemap tilemap)
    {
        if (tile != null)
        {
            for (int i = startPosition.x; i <= endPosition.x; i++)
            {
                for (int j = startPosition.y; j <= endPosition.y; j++)
                {
                    tilemap.SetTile(new Vector3Int(i, j, 0), tile);
                }
            }
        }
    }
}
