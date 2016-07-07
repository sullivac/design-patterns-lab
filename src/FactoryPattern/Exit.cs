using System;

namespace FactoryPattern
{
    public class Exit : Wall
    {
        public Exit(int id)
            : base(id)
        {
        }

        public override void Move(Player player)
        {
            if (player == null) { throw new ArgumentNullException("player", "player is null."); }

            player.Done();
        }
    }
}
