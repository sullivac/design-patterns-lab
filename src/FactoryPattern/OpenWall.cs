using System;

namespace FactoryPattern
{
    public class OpenWall : Wall
    {
        private readonly IMovePlayer destination;

        public OpenWall(IMovePlayer destination)
        {
            if (destination == null) { throw new ArgumentNullException("destination", "destination is null."); }

            this.destination = destination;
        }

        protected override void MoveInternal(IMovable movable)
        {
            movable.MoveTo(destination);
        }
    }
}
