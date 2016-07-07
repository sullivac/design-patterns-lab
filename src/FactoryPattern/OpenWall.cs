using System;
namespace FactoryPattern
{
    public class OpenWall : Wall
    {
        public OpenWall(int id, Room roomOne, Room roomTwo)
            : base(id)
        {
            RoomOne = roomOne;
            RoomTwo = roomTwo;
        }

        public Room RoomOne { get; private set; }

        public Room RoomTwo { get; private set; }

        public override void Move(Player player)
        {
            if (player == null) { throw new ArgumentNullException("player", "player is null."); }

            player.MoveBetween(RoomOne, RoomTwo);
        }
    }
}
