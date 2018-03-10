using UnityEngine;
using UnityEngine.Tilemaps;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "Board Tile", menuName = "Board Creator/Tiles/Without Partition Walls", order = 1)]
public class FloorTileWithoutPartitionWalls : TileBase
{
    public RulePattern[] patterns = new RulePattern[13];

    public FloorTileWithoutPartitionWalls()
    {
        SetRules();
    }

    void SetRules()
    {
        patterns[0] = new OutsideTopLeftTile();
        patterns[1] = new TopTile();
        patterns[2] = new OutsideTopRightTile();
        patterns[3] = new LeftTile();
        patterns[4] = new MiddleTile();
        patterns[5] = new RightTile();
        patterns[6] = new OutsideDownLeftTile();
        patterns[7] = new DownTile();
        patterns[8] = new OutsideDownRightTile();
        patterns[9] = new InsideTopLeftTile();
        patterns[10] = new InsideTopRightTile();
        patterns[11] = new InsideDownLeftTile();
        patterns[12] = new InsideDownRightTile();
    }

    void OnEnable()
    {
        foreach(RulePattern pattern in patterns)
        if (pattern.sprite == null) Debug.LogWarning("One of tile patterns attached to the tile without partition walls hasn't got sprite.");
    }

    public override void GetTileData(Vector3Int position, ITilemap tileMap, ref TileData tileData)
    {
        tileData.sprite = SetSprite(position, tileMap);
    }

    Sprite SetSprite(Vector3Int position, ITilemap tileMap)
    {
        bool[,] neighbours = GetNeighbours(position, tileMap);
        foreach (RulePattern pattern in patterns)
        {
            if (pattern.CheckRule(neighbours))
            {
                return pattern.sprite;
            }
        }
        return null;
    }

    bool[,] GetNeighbours(Vector3Int position, ITilemap tileMap)
    {
        bool[,] neighbours = new bool[3, 3];
        for (int x = -1; x <= 1; x++)
        {
            for (int y = -1; y <= 1; y++)
                neighbours[x + 1, y + 1] = tileMap.GetTile(position + new Vector3Int(x, y, 0)) != null ? true : false;
        }
        return neighbours;
    }

    public override void RefreshTile(Vector3Int location, ITilemap tileMap)
    {
        for (int y = -1; y <= 1; y++)
        {
            for (int x = -1; x <= 1; x++)
                base.RefreshTile(location + new Vector3Int(x, y, 0), tileMap);
        }
    }
}
