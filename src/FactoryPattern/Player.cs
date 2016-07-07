using System;
using System.ComponentModel;

namespace FactoryPattern
{
    public class Player
    {
        private Room current;
        private readonly Action<Room> onCurrentRoomChanged;
        private readonly Action onDone;
        private readonly Action onWait;
        
        public Player(Action<Room> onCurrentRoomChanged, Action onWait, Action onDone)
        {
            this.onCurrentRoomChanged = onCurrentRoomChanged;
            this.onWait = onWait;
            this.onDone = onDone;
        }

        public Room Current
        {
            get { return current; }
            set
            {
                if (value == null) { throw new ArgumentNullException("value", "value is null."); }

                current = value;

                onCurrentRoomChanged(value);
            }
        }

        public void Done()
        {
            onDone();
        }

        public void MoveNorth()
        {
            Current.MoveNorth(this);
        }

        public void MoveEast()
        {
            Current.MoveEast(this);
        }

        public void MoveSouth()
        {
            Current.MoveSouth(this);
        }

        public void MoveWest()
        {
            Current.MoveWest(this);
        }

        public void MoveBetween(Room one, Room two)
        {
            if (Current == one)
            {
                Current = two;
            }
            else if (Current == two)
            {
                Current = one;
            }
            else
            {
                throw new InvalidOperationException("Player is not located in either room one or two.");
            }
        }

        public void Wait()
        {
            onWait();
        }
    }
}
