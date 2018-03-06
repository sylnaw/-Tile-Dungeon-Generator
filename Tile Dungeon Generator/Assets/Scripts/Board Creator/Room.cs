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
        endPosition = GetPositionWithHighestCoordinates(vector, width, height);
        unusedDirections = roomPattern.GetDirectionsContainer(vector.direction);
    }

    public TileVector GetVectorForNewRoomAndRemoveDirection(RoomType typeOfNewRoom)
    {
        Direction directionOfnewRoom = unusedDirections.GetAndRemoveRandomDirection();
        return roomPattern.GetVectorForNewRoom(directionOfnewRoom, this, typeOfNewRoom);
    }

    public void Draw(Tilemap tilemap) { roomPattern.Draw(this, tilemap); }

    Vector2Int GetPositionWithLowestCoordinates(TileVector vector, int width, int height)
    {
        if (vector.direction.IsNorth)
            return new Vector2Int(GetRandomCoordinateInRange(vector.position.x, width), vector.position.y);
        else if (vector.direction.IsSouth)
            return new Vector2Int(GetRandomCoordinateInRange(vector.position.x, width), vector.position.y - height);
        else if (vector.direction.IsEast)
            return new Vector2Int(vector.position.x, GetRandomCoordinateInRange(vector.position.y, height));
        else
            return new Vector2Int(vector.position.x - width, GetRandomCoordinateInRange(vector.position.y, height));
    }

    int GetRandomCoordinateInRange(int startCoordinate, int range)
    {
        return Random.Range(startCoordinate - range, startCoordinate + 1);
    }

    Vector2Int GetPositionWithHighestCoordinates(TileVector vector, int width, int height)
    {
        return new Vector2Int(startPosition.x + width, startPosition.y + height);
    }
}