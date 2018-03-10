using UnityEngine;

public enum AvalibleDirection
{
    North, East, South, West
}

public struct Direction
{
    private AvalibleDirection direction;
    public bool IsNorth { get { return direction == AvalibleDirection.North; } }
    public bool IsSouth { get { return direction == AvalibleDirection.South; } }
    public bool IsEast { get { return direction == AvalibleDirection.East; } }
    public bool IsWest { get { return direction == AvalibleDirection.West; } }

    public Direction(AvalibleDirection direction) { this.direction = direction; }

    public void ChangeToRandomPerpendicularDirection()
    {
        if (Random.Range(0, 2) == 0) ChangeToOppositeDirection();
        direction = direction + ((int)direction % 2 == 0 ? 1 : -1);
    }

    public void ChangeToOppositeDirection()
    {
        direction = (AvalibleDirection)(((int)direction + 2) % 4);
    }

    public static bool operator ==(Direction left, Direction right)
    {
        return left.direction == right.direction;
    }

    public static bool operator !=(Direction left, Direction right)
    {
        return left.direction == right.direction;
    }
}