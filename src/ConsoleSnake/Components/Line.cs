using ConsoleSnake.Components.Contracts;
using ConsoleSnake.Components.LineStrategies;
using System;
using System.Collections.Generic;

namespace ConsoleSnake.Components
{
    public class Line : Figure
    {
        /// <summary>
        /// Holds a collection with all line strategies
        /// </summary>
        private Dictionary<string, LineStrategy> lineStrategies = new Dictionary<string, LineStrategy>()
        {
            { "horizontal", new HorizontalLineStrategy() },
            { "vertical" , new  VerticalLineStrategy() }
        };

        /// <summary>
        /// Creates the line depending on the given strategy
        /// </summary>      
        public Line(int startX, int endX, int y, char symbol, string lineStrategy)
        {
            this.PointsToDraw = new List<Point>();

            for (int x = startX; x <= endX; x++)
            {
                try
                {
                    Point p = lineStrategies[lineStrategy].GetPoint(x, y, symbol);
                    PointsToDraw.Add(p);
                }
                catch
                {
                    throw new NullReferenceException("The line strategy is not recognized");
                }
            }
        }
    }
}
