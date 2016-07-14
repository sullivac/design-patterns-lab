using System;

namespace FactoryPattern
{
    public class Room : IMovePlayer
    {
        private Wall north;
        private Wall east;
        private Wall south;
        private Wall west;

        public Room(int id)
        {
            Id = id;

            north = new SolidWall();
            east = new SolidWall();
            south = new SolidWall();
            west = new SolidWall();
        }

        public int Id { get; private set; }

        public Wall North
        {
            get { return north; }
        }

        public Wall East
        {
            get { return east; }
        }

        public Wall South
        {
            get { return south; }
        }

        public Wall West
        {
            get { return west; }
        }

        public void ConnectToNorth(Room other)
        {
            if (other == null) { throw new ArgumentNullException("other", "other is null."); }

            north = new OpenWall(other);
        }

        public void ConnectToEast(Room other)
        {
            if (other == null) { throw new ArgumentNullException("other", "other is null."); }

            east = new OpenWall(other);
        }

        public void ConnectToSouth(Room other)
        {
            if (other == null) { throw new ArgumentNullException("other", "other is null."); }

            south = new OpenWall(other);
        }

        public void ConnectToWest(Room other)
        {
            if (other == null) { throw new ArgumentNullException("other", "other is null."); }

            west = new OpenWall(other);
        }

        public void ExitToNorth()
        {
            north = new Exit();
        }

        public void ExitToEast()
        {
            east = new Exit();
        }

        public void ExitToSouth()
        {
            south = new Exit();
        }

        public void ExitToWest()
        {
            west = new Exit();
        }
    }
}
