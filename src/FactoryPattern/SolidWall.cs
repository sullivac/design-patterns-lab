namespace FactoryPattern
{
    public class SolidWall : Wall
    {
        protected override void MoveInternal(IMovable movable)
        {
            movable.Wait();
        }
    }
}
