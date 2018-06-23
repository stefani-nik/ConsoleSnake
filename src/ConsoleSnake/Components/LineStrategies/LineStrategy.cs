using ConsoleSnake.Components.Contracts;

namespace ConsoleSnake.Components.LineStrategies
{
    public abstract class LineStrategy
    {
        public abstract Point GetPoint(int x, int y, char sym);
    }
}
