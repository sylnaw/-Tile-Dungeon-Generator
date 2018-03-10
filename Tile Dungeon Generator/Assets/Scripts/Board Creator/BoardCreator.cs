using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Tilemaps;

public enum RoomType
{
    Chamber, Corridor
}

public class BoardCreator : MonoBehaviour
{
    public Tilemap board;
    public RoomPattern[] roomPatterns;

    private int amountOfAllRooms = 0;
    private List<Creator> creators = new List<Creator>();
    private List<Room> avalibleRooms = new List<Room>();
    private Room[] rooms;

    void Start()
    {
        if (CheckIfRoomPatternsArentEmpty() && board != null)
        {
            CreateCreators(roomPatterns, creators);
            CreateRooms();
            DrawRooms();
        }
        else
            if (board == null) Debug.LogWarning("There is no tilemap attached to the Board Creator.");
    }

    bool CheckIfRoomPatternsArentEmpty()
    {
        if (roomPatterns.Count() <= 0)
        {
            Debug.LogWarning("There are no room patterns attached to the Board Creator.");
            return true;
        }
        else
        {
            foreach (RoomPattern pattern in roomPatterns)
                if (pattern == null)
                {
                    Debug.LogWarning("One of room patterns attached to the Board Creator is empty.");
                    return false;
                }
        }
        return true;
    }
    void CreateCreators(RoomPattern[] roomPatterns, List<Creator> creators)
    {
        foreach (RoomPattern roomPattern in roomPatterns)
            creators.Add(new Creator(roomPattern));
        amountOfAllRooms += creators.Sum(i => i.AmountOfRooms);
    }

    void CreateRooms()
    {
        rooms = new Room[amountOfAllRooms];
        CreateFirstRoom();
        for (int amountOfRooms = 1; amountOfRooms < amountOfAllRooms; amountOfRooms++)
            CreateRoom(amountOfRooms);
    }

    void CreateFirstRoom()
    {
        TileVector vector = new TileVector(new Vector2Int(0, 0), new Direction(AvalibleDirection.North));
        CreateRoomFromCreator(0, GetCreatorForNewRoom(), vector);
    }

    void CreateRoom(int numberOfRoom)
    {
        Creator creator = GetCreatorForNewRoom();
        CreateRoomFromCreator(numberOfRoom, creator, GetVectorForNewRoom(creator.Type));
    }

    Creator GetCreatorForNewRoom()
    {
        if (creators.Count > 0)
        {
            Creator creator = creators[Random.Range(0, creators.Count)];
            creator.RemoveRoomFromAmountOfRooms();
            if (creator.IsEmpty) creators.Remove(creator);
            return creator;
        }
        else throw new System.Exception("There are no creators left.");
    }

    void CreateRoomFromCreator(int numberOfRoom, Creator creator, TileVector vector)
    {
        if (numberOfRoom < amountOfAllRooms)
        {
            Room room = creator.GetRoom(vector);
            rooms[numberOfRoom] = room;
            avalibleRooms.Add(room);
        }
        else throw new System.Exception("Created more rooms than amountOfAllRooms.");
    }

    TileVector GetVectorForNewRoom(RoomType roomType)
    {
        if (avalibleRooms.Count > 0)
        {
            Room room = avalibleRooms[Random.Range(0, avalibleRooms.Count)];
            TileVector vector = room.GetVectorForNewRoomAndRemoveDirection(roomType);
            if (!room.HaveUnusedDirections) avalibleRooms.Remove(room);
            return vector;
        }
        else throw new System.Exception("There are no avalibleRooms left.");
    }

    void DrawRooms()
    {
        DrawRoomsOfType(RoomType.Corridor);
        DrawRoomsOfType(RoomType.Chamber);
    }

    void DrawRoomsOfType(RoomType roomType)
    {
        Room[] roomsToDraw = rooms.Select(n => n).Where(s => (s != null) && s.Type == roomType).ToArray();
        foreach (Room room in roomsToDraw)
            room.Draw(board);
    }

    private class Creator
    {
        public int AmountOfRooms { get; private set; }
        public RoomType Type { get { return roomPattern.GetRoomType(); } }
        public bool IsEmpty { get { return AmountOfRooms <= 0; } }
        private RoomPattern roomPattern;

        public Creator(RoomPattern roomPattern)
        {
            this.roomPattern = roomPattern;
            AmountOfRooms = roomPattern.amount.Random;
            if (!roomPattern.PainterHaveTile) Debug.LogWarning("There is no tile attached to the " + roomPattern.name + ".");
        }

        public Room GetRoom(TileVector vector)
        {
            return new Room(vector, roomPattern);
        }

        public void RemoveRoomFromAmountOfRooms()
        {
            if (AmountOfRooms > 0)
                AmountOfRooms--;
            else throw new System.Exception("More than AmountOfRooms rooms was taken from creator.");
        }
    }
}