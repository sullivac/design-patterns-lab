namespace FactoryPattern
{
    public class Exit : Wall
    {
        protected override void MoveInternal(IMovable movable)
        {
            movable.Done();
        }
    }
}
