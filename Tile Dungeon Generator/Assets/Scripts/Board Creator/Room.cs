using UnityEngine;
using UnityEngine.Tilemaps;

public class Room
{
    public bool HaveUnusedDirections { get { return !unusedDirections.IsEmpty; } }
    public RoomType Type { get { return roomPattern.GetRoomType(); } }
    public readonly Direction direction;
    public readonly Vector2Int startPosition, endPosition;
    private RoomPattern roomPattern;
    private DirectionsContainer unusedDirections;

    public Room(TileVector vector, RoomPattern roomPattern)
    {
        this.roomPattern = roomPattern;
        direction = vector.direction;
        int width = roomPattern.GetRoomWidth(vector.direction);
        int height = roomPattern.GetRoomHeight(vector.direction);
        startPosition = GetPositionWithLowestCoordinates(vector, width, height);
        endPosition = GetPositionWithHighestCoordinates(width, height);
        unusedDirections = roomPattern.GetDirectionsContainer(vector.direction);
    }

    public TileVector GetVectorForNewRoomAndRemoveDirection(RoomType typeOfNewRoom)
    {
        Direction directionOfnewRoom = unusedDirections.GetAndRemoveRandomDirection();
        return roomPattern.GetVectorForStartingNewRoom(directionOfnewRoom, this, typeOfNewRoom);
    }

    public void Draw(Tilemap tilemap) { roomPattern.Draw(this, tilemap); }

    Vector2Int GetPositionWithLowestCoordinates(TileVector vector, int width, int height)
    {
        Vector2Int positionModyfication;
        if (vector.direction.IsNorth)
            positionModyfication = new Vector2Int(Random.Range(-width, 1), 0);
        else if (vector.direction.IsSouth)
            positionModyfication = new Vector2Int(Random.Range(-width, 1), -height);
        else if (vector.direction.IsEast)
            positionModyfication = new Vector2Int(0, Random.Range(-height, 1));
        else
            positionModyfication = new Vector2Int(-width, Random.Range(-height, 1));
        return vector.position + positionModyfication;
    }

    Vector2Int GetPositionWithHighestCoordinates(int width, int height)
    {
        return startPosition + new Vector2Int(width, height);
    }
}