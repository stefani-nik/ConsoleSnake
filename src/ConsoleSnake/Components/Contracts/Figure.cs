using System.Collections.Generic;

namespace ConsoleSnake.Components.Contracts
{
    /// <summary>
    /// Abstract class which determines what fields every figure should have
    /// </summary>

    public abstract class Figure
    {
        private List<Point> _pointsToDraw;

        public List<Point> PointsToDraw { get => _pointsToDraw; set => _pointsToDraw = value; }


        public void Draw()
        {
            this._pointsToDraw.ForEach(p => p.Draw());
        }
    }
}
