using UnityEngine;

// TODO: Change name.
public struct TileVector
{
    public readonly Vector2Int position;
    public readonly Direction direction;

    public TileVector(Vector2Int position, Direction direction)
    {
        this.position = position;
        this.direction = direction;
    }
}