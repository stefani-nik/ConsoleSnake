using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace ConsoleSnake.Components.Contracts
{
    public abstract class Figure
    {
        private List<Point> pointsToDraw;

        internal List<Point> PointsToDraw { get => pointsToDraw; set => pointsToDraw = value; }


        protected void DrawFigure()
        {
            foreach(Point p in this.pointsToDraw)
            {
                p.Draw();
            }
        }
    }
}
