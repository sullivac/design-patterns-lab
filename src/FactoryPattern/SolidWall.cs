using System;
namespace FactoryPattern
{
    public class SolidWall : Wall
    {
        public SolidWall(int id)
            : base(id)
        {
        }

        public override void Move(Player player)
        {
            if (player == null) { throw new ArgumentNullException("player", "player is null."); }

            player.Wait();
        }
    }
}
