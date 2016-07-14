using System;
using System.ComponentModel;

namespace FactoryPattern
{
    public class Player : IMovable
    {
        private IMovePlayer current;
        private Action onCurrentChanged;
        private Action onDone;
        private Action onWait;

        public Player(IMovePlayer start)
        {
            current = start;
            onCurrentChanged = () => { };
            onDone = () => { };
            onWait = () => { };
        }

        public int CurrentPosition
        {
            get { return current.Id; }
        }

        public Action OnCurrentChanged
        {
            set
            {
                if (value == null) { throw new ArgumentNullException("value", "value is null."); }

                onCurrentChanged = value;
            }
        }

        public Action OnDone
        {
            set
            {
                if (value == null) { throw new ArgumentNullException("value", "value is null."); }

                onDone = value;
            }
        }

        public Action OnWait
        {
            set
            {
                if (value == null) { throw new ArgumentNullException("value", "value is null."); }

                onWait = value;
            }
        }

        public void MoveNorth()
        {
            current.North.Move(this);
        }

        public void MoveEast()
        {
            current.East.Move(this);
        }

        public void MoveSouth()
        {
            current.South.Move(this);
        }

        public void MoveWest()
        {
            current.West.Move(this);
        }

        void IMovable.Done()
        {
            onDone();
        }

        void IMovable.MoveTo(IMovePlayer room)
        {
            if (room == null) { throw new ArgumentNullException("room", "room is null."); }

            current = room;

            onCurrentChanged();
        }

        void IMovable.Wait()
        {
            onWait();
        }
    }
}
