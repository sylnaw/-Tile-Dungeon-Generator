using UnityEngine;
using UnityEngine.Tilemaps;

[CreateAssetMenu(fileName = "New Chamber", menuName = "Board Creator/Chambers/Rectangular Chamber", order = 1)]
public class RectangularChamber : RoomPattern
{
    public IntRange width = new IntRange(3, 10);
    public IntRange height = new IntRange(3, 10);

    public override RoomType GetRoomType() { return RoomType.Chamber; }

    public override DirectionsContainer GetDirectionsContainer(Direction direction)
    {
        direction.ChangeToOppositeDirection();
        DirectionsContainer directions = new DirectionsContainer();
        directions.SetAllDirectionsWithout(direction);
        return directions;
    }

    public override int GetRoomWidth(Direction direction) { return width.Random; }
    public override int GetRoomHeight(Direction direction) { return height.Random; }

    public override TileVector GetVectorForStartingNewRoom(Direction direcionOfNewRoom, Room chamber, RoomType typeOfNewRoom)
    {
        return new TileVector(GetVectorPosition(direcionOfNewRoom, chamber), direcionOfNewRoom);
    }

    Vector2Int GetVectorPosition(Direction direction, Room chamber)
    {
        if (direction.IsNorth || direction.IsSouth)
        {
            int randomX = Random.Range(chamber.startPosition.x, chamber.endPosition.x + 1);
            if (direction.IsNorth) return new Vector2Int(randomX, chamber.endPosition.y);
            else return new Vector2Int(randomX, chamber.startPosition.y);
        }
        else
        {
            int randomY = Random.Range(chamber.startPosition.y, chamber.endPosition.y + 1);
            if (direction.IsEast) return new Vector2Int(chamber.endPosition.x + 1, randomY);
            else return new Vector2Int(chamber.startPosition.x, randomY);
        }
    }

    public override void Draw(Room chamber, Tilemap tilemap)
    {
        painter.DrawRectangleRoom(chamber.startPosition, chamber.endPosition, tilemap);
    }
}