using System;
using System.Collections.Generic;
using System.Linq;

namespace FactoryPattern
{
    public class SimpleMazeFactory : ICreateMazes
    {
        private const int IdSeed = 0;
        private readonly int length;

        public SimpleMazeFactory(int length)
        {
            if (length < 1) { throw new ArgumentOutOfRangeException("length", length, "length is less than one."); }

            this.length = length;
        }

        public IMovePlayer Create()
        {
            Dictionary<int, Room> rooms = Enumerable.Range(IdSeed, length)
                .Select(x => new Room(x))
                .ToDictionary(room => room.Id);

            for (int i = 0; i < length - 2; i++)
            {
                rooms[i].ConnectToEast(rooms[i + 1]);
                rooms[i + 1].ConnectToWest(rooms[i]);
            }

            rooms[length - 1].ExitToEast();

            return rooms[IdSeed];
        }
    }
}
