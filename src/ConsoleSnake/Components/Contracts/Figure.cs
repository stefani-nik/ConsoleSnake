using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace ConsoleSnake.Components.Contracts
{
    public abstract class Figure
    {
        protected List<Point> pointsToDraw;

        protected void DrawFigure()
        {
            foreach(Point p in pointsToDraw)
            {
                p.Draw();
            }
        }
    }
}
