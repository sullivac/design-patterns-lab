namespace FactoryPattern
{
    public interface IMovable
    {
        void Done();
        void MoveTo(IMovePlayer room);
        void Wait();
    }
}
