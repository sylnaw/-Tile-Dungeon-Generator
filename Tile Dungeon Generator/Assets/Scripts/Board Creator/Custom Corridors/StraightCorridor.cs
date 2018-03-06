using UnityEngine;
using UnityEngine.Tilemaps;

[CreateAssetMenu(fileName = "New Corridor", menuName = "Board Creator/Corridors/Straight Corridor", order = 1)]
public class StraightCorridor : RoomPattern
{
    public IntRange lenght = new IntRange(3, 10);

    public override RoomType GetRoomType() { return RoomType.Corridor; }

    public override DirectionsContainer GetDirectionsContainer(Direction direction)
    {
        DirectionsContainer directions = new DirectionsContainer();
        directions.SetDirection(direction);
        return directions;
    }

    public override int GetRoomHeight(Direction direction)
    {
        return direction.IsNorth || direction.IsSouth ? lenght.Random : 0;
    }

    public override int GetRoomWidth(Direction direction)
    {
        return direction.IsEast || direction.IsWest ? lenght.Random : 0;
    }

    public override TileVector GetVectorForNewRoom(Direction direcionOfNewRoom, Room corridor, RoomType typeOfNewRoom)
    {
        if (typeOfNewRoom == RoomType.Corridor)
            direcionOfNewRoom.ChangeToRandomPerpendicularDirection();
        return new TileVector(GetVectorPosition(corridor), direcionOfNewRoom);
    }

    Vector2Int GetVectorPosition(Room corridor)
    {
        if (corridor.direction.IsNorth || corridor.direction.IsEast)
            return corridor.endPosition;
        else
            return corridor.startPosition;
    }

    public override void Draw(Room corridor, Tilemap tilemap)
    {
        painter.DrawRectangleRoom(corridor.startPosition, corridor.endPosition, tilemap);
    }
}