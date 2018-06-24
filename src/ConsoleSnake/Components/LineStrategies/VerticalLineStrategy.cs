using ConsoleSnake.Components.Contracts;
using ConsoleSnake.Components.LineStrategies;

namespace ConsoleSnake.Components
{
    public class VerticalLineStrategy : LineStrategy
    {
        /// <summary>
        /// Represents the way of getting a point from a vertical line 
        /// </summary>
        public override Point GetPoint(int x, int y, char symbol)
        {
            return new Point(y, x, symbol);
        }
    }
}
