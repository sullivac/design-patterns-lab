namespace AdapterPattern
{
    public interface IDrawShape
    {
        void Draw(Circle circle);

        void Draw(Rectangle rectangle);
    }
}
