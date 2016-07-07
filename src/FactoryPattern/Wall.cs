using System;
namespace FactoryPattern
{
    public abstract class Wall
    {
        protected Wall(int id)
        {
            Id = id;
        }

        public int Id { get; private set; }

        public abstract void Move(Player player);
    }
}
