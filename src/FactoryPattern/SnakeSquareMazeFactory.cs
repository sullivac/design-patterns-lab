using System;
using System.Collections.Generic;
using System.Linq;

namespace FactoryPattern
{
    public class SnakeSquareMazeFactory : ICreateMazes
    {
        private const int IdSeed = 0;

        private readonly int length;

        public SnakeSquareMazeFactory(int length)
        {
            if (length < 2) { throw new ArgumentOutOfRangeException("length", length, "length is less than two."); }

            this.length = length;
        }

        private bool IsLengthEven
        {
            get { return length % 2 == 0; }
        }

        private int TerminalId
        {
            get { return IsLengthEven ? length * (length - 1) : length * length - 1; }
        }

        public IMovePlayer Create()
        {
            Dictionary<int, Room> rooms = Enumerable.Range(IdSeed, length * length)
                .Select(x => new Room(x))
                .ToDictionary(room => room.Id);

            IEnumerable<int> roomIdsWithEastRoom = rooms.Keys.Where(IdHasEastRoom);
            foreach (int roomId in roomIdsWithEastRoom)
            {
                rooms[roomId].ConnectToEast(rooms[roomId + 1]);
                rooms[roomId + 1].ConnectToWest(rooms[roomId]);
            }

            IEnumerable<int> roomIdsWithSouthRoom = rooms.Keys.Where(IdHasSouthRoom);
            foreach (int roomId in roomIdsWithSouthRoom)
            {
                rooms[roomId].ConnectToSouth(rooms[roomId + length]);
                rooms[roomId + length].ConnectToNorth(rooms[roomId]);
            }

            if (IsLengthEven)
            {
                rooms[TerminalId].ExitToWest();
            }
            else
            {
                rooms[TerminalId].ExitToEast();
            }

            return rooms[IdSeed];
        }

        private bool IdHasEastRoom(int id)
        {
            return id % length != length - 1;
        }

        private bool IdHasSouthRoom(int id)
        {
            if (id == 0 || id == TerminalId || id / length == length - 1) { return false; }

            return id % length == length - 1 && id / length % 2 == 0
                || id % length == 0 && id / length % 2 == 1;
        }
    }
}
