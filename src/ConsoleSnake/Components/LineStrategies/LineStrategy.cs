using ConsoleSnake.Components.Contracts;

namespace ConsoleSnake.Components.LineStrategies
{
    /// <summary>
    /// The base strategy for the different kinds of lines
    /// </summary>
    public abstract class LineStrategy
    {
        public abstract Point GetPoint(int x, int y, char sym);
    }
}
