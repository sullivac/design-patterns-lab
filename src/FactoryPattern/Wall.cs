using System;

namespace FactoryPattern
{
    public abstract class Wall
    {
        public void Move(IMovable movable)
        {
            if (movable == null) { throw new ArgumentNullException("movable", "movable is null."); }

            MoveInternal(movable);
        }

        protected abstract void MoveInternal(IMovable movable);
    }
}
