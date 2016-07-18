namespace AdapterPattern
{
    public class MainPresenter
    {
        private readonly IDrawShape shapeDrawService;

        public MainPresenter(IDrawShape shapeDrawService)
        {
            this.shapeDrawService = shapeDrawService;
        }

        public void DrawShapes()
        {
            shapeDrawService.Draw(new Circle
            {
                Color = ShapeColor.Red,
                X = 100,
                Y = 50,
                Radius = 30
            });
            shapeDrawService.Draw(new Circle
            {
                Color = ShapeColor.Green,
                X = 150,
                Y = 250,
                Radius = 10
            });
            shapeDrawService.Draw(new Rectangle
            {
                Color = ShapeColor.Blue,
                Width = 100,
                Height = 275,
                Top = 25,
                Left = 200
            });
        }
    }
}
