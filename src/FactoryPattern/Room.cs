using System;

namespace FactoryPattern
{
    public class Room
    {
        private readonly Wall north;
        private readonly Wall east;
        private readonly Wall south;
        private readonly Wall west;

        public Room(int id, Wall north, Wall east, Wall south, Wall west)
        {
            Id = id;
            this.north = north;
            this.east = east;
            this.south = south;
            this.west = west;
        }

        public int Id { get; private set; }

        public void MoveNorth(Player player)
        {
            if (player == null) { throw new ArgumentNullException("player", "player is null."); }

            north.Move(player);
        }

        public void MoveEast(Player player)
        {
            if (player == null) { throw new ArgumentNullException("player", "player is null."); }

            east.Move(player);
        }

        public void MoveSouth(Player player)
        {
            if (player == null) { throw new ArgumentNullException("player", "player is null."); }

            south.Move(player);
        }

        public void MoveWest(Player player)
        {
            if (player == null) { throw new ArgumentNullException("player", "player is null."); }

            west.Move(player);
        }
    }
}
