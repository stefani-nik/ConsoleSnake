using ConsoleSnake.Components.LineStrategies;
using System.Collections.Generic;

namespace ConsoleSnake.Components.Contracts
{
    public class Line : Figure
    {
        private Dictionary<string, LineStrategy> lineStrategies = new Dictionary<string, LineStrategy>()
        {
            { "horizontal", new HorizontalLineStrategy() },
            { "vertical" , new  VerticalLineStrategy() }
        };

        public Line(int startX, int endX, int y, char symbol, string lineStrategy)
        {
            this.PointsToDraw = new List<Point>();

            for (int x = startX; x <= endX; x++)
            {
                Point p = lineStrategies[lineStrategy].GetPoint(x, y, symbol);
                PointsToDraw.Add(p);
            }
        }
    }
}
