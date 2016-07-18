using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace AdapterPattern
{
    public class Win32ShapeDrawService : IDrawShape
    {
        private readonly Graphics graphics;

        public Win32ShapeDrawService(Graphics graphics)
        {
            this.graphics = graphics;
        }

        public void Draw(Circle circle)
        {
            graphics.FillEllipse(new SolidBrush(GetColor(circle.Color)), circle.X, circle.Y, circle.Radius * 2, circle.Radius * 2);
        }

        public void Draw(Rectangle rectangle)
        {
            graphics.FillRectangle(new SolidBrush(GetColor(rectangle.Color)), rectangle.Left, rectangle.Top, rectangle.Width, rectangle.Height);
        }

        private Color GetColor(ShapeColor color)
        {
            switch (color)
            {
                case ShapeColor.Red:
                    return Color.Red;
                case ShapeColor.Blue:
                    return Color.Blue;
                case ShapeColor.Green:
                    return Color.Green;
                default:
                    throw new ArgumentException(string.Format("Unknown ShapeColor: {0}.", color), "color");
            }
        }
    }
}
