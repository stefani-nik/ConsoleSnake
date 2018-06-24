using ConsoleSnake.Components.Contracts;
using ConsoleSnake.Enums;
using ConsoleSnake.Helpers;
using System;
using System.Collections.Generic;

namespace ConsoleSnake.Components
{
    public sealed class Snake : Figure
    {
        private Direction _direction = Direction.RIGHT;

        private static readonly Lazy<Snake> instance =
                        new Lazy<Snake>(() => new Snake());

        public static Snake Instance { get => instance.Value; }

        public Point Head { get; set; } = new Point(Constants.SnakeStartPointX, Constants.SnakeStartPointY, Constants.SnakeSymbol);

        public Point Tail { get => this.PointsToDraw[0]; private set { } }

        public Direction Direction { get => this._direction; set => this._direction = value; }

        private Snake()
        {
            this.PointsToDraw = new List<Point>();

            for (int i = 0; i < Constants.SnakeInitialLength; i++)
            {
                PointsToDraw.Add(new Point(this.Head));
                this.Head.Move(1, _direction);            
            }
        }

        internal void Move()
        {
            this.Tail.Clear();
            this.PointsToDraw.Remove(this.Tail);
            this.PointsToDraw.Add(new Point(this.Head));
            this.Head.Draw();
            this.Head.Move(1, _direction);
        }

        public bool IsHitTail()
        { 
            for (int i = 0; i < PointsToDraw.Count - 2; i++)
            {
                if (this.Head.IsHit(PointsToDraw[i]))
                {
                    return true;
                }
            }
            return false;
        }

        internal bool Eat(Point food)
        {

            if (this.Head.IsHit(food))
            {
                PointsToDraw.Add(new Point(this.Head));
                this.Head.Move(1, _direction);
                return true;
            }
            else
                return false;
        }
    }
}
