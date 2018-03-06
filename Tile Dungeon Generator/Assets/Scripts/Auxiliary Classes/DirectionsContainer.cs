using System.Collections.Generic;
using UnityEngine;

public class DirectionsContainer
{
    private List<Direction> directions = new List<Direction>();
    public bool IsEmpty { get { return directions.Count <= 0; } }

    public Direction GetAndRemoveRandomDirection()
    {
        if (directions.Count > 0)
        {
            Direction direction = directions[Random.Range(0, directions.Count)];
            directions.Remove(direction);
            return direction;
        }
        else throw new System.Exception("An attempt to take a random direction from empty container.");
    }

    public void SetDirection(Direction direction)
    {
        directions.Clear();
        directions.Add(direction);
    }

    public void SetAllDirectionsWithout(Direction direction)
    {
        directions.Clear();
        AddAllDirections();
        directions.Remove(direction);
    }

    void AddAllDirections()
    {
        directions.Add(new Direction(AvalibleDirection.North));
        directions.Add(new Direction(AvalibleDirection.South));
        directions.Add(new Direction(AvalibleDirection.East));
        directions.Add(new Direction(AvalibleDirection.West));
    }
}
