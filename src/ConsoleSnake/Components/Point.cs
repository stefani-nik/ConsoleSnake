using ConsoleSnake.Engine;

namespace ConsoleSnake.Components
{
    public class Point
    {
        private int _x;
        private int _y;
        private char _symbol;

        public int X { get => _x; set => _x = value; }
        public int Y { get => _y; set => _y = value; }
        public char Symbol { get => _symbol; set => _symbol = value; }

        public Point(int x, int y, char symbol)
        {
            this.X = x;
            this.Y = y;
            this.Symbol = symbol;
        }

        public bool IsHit(Point p)
        {
            return p.X == this.X && p.Y == this.Y;
        }

        public void Draw()
        {
            ConsoleWriter.WritePoint(this.X, this.Y, this.Symbol);
        }

        public void Clear()
        {
            this.Symbol = ' ';
            Draw();
        }

    }
}
