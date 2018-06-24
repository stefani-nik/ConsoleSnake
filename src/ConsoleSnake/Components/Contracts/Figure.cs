using System.Collections.Generic;

namespace ConsoleSnake.Components.Contracts
{
    public abstract class Figure
    {
        private List<Point> _pointsToDraw;

        internal List<Point> PointsToDraw { get => _pointsToDraw; set => _pointsToDraw = value; }


        internal void DrawFigure()
        {
            this._pointsToDraw.ForEach(p => p.Draw());
        }
    }
}
