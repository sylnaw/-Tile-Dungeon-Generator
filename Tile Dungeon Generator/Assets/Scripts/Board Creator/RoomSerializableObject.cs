using UnityEngine;
using UnityEngine.Tilemaps;

public abstract class RoomPattern : ScriptableObject
{
    public new string name = "";
    public Painter painter = new Painter();
    public IntRange amount = new IntRange(15, 20);

    public bool PainterHaveTile { get { return painter.tile != null; } }

    public abstract RoomType GetRoomType();
    public abstract DirectionsContainer GetDirectionsContainer(Direction direction);
    public abstract int GetRoomWidth(Direction direction);
    public abstract int GetRoomHeight(Direction direction);
    public abstract TileVector GetVectorForNewRoom(Direction direcionOfNewRoom, Room room, RoomType typeOfNewRoom);
    public abstract void Draw(Room room, Tilemap tilemap);
}
