namespace FactoryPattern
{
    public interface IMovePlayer
    {
        int Id { get; }

        Wall North { get; }
        Wall East { get; }
        Wall South { get; }
        Wall West { get; }
    }
}
