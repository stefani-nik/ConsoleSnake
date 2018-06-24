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

        private Snake()
        {
            this.PointsToDraw = new List<Point>();

            for (int i = 0; i < Constants.SnakeInitialLength; i++)
            {
                Point p = new Point(Constants.SnakeStartPointX, Constants.SnakeStartPointY, Constants.SnakeSymbol);
                p.Move(i, _direction);
                PointsToDraw.Add(p);
            }
        }

        internal void Move()
        {
            Point tail = PointsToDraw[0];
            PointsToDraw.Remove(tail);
            Point head = GetNextPoint();
            PointsToDraw.Add(head);

            tail.Clear();
            head.Draw();
        }

        public Point GetNextPoint()
        {
            Point head = PointsToDraw[PointsToDraw.Count - 1];
            Point nextPoint = new Point(head);
            nextPoint.Move(1, _direction);
            return nextPoint;
        }

        internal bool IsHitTail()
        {
            var head = PointsToDraw[PointsToDraw.Count - 1];

            for (int i = 0; i < PointsToDraw.Count - 2; i++)
            {
                if (head.IsHit(PointsToDraw[i]))
                {
                    return true;
                }
            }
            return false;
        }

        public void HandleKey(ConsoleKey key)
        {
            if (key == ConsoleKey.LeftArrow)
            {
                this._direction = Direction.LEFT;
            }
            else if (key == ConsoleKey.RightArrow)
            {
                this._direction = Direction.RIGHT;
            }
            else if (key == ConsoleKey.DownArrow)
            {
                this._direction = Direction.DOWN;
            }
            else if (key == ConsoleKey.UpArrow)
            {
                this._direction = Direction.UP;
            }
        }

        internal bool Eat(Point food)
        {
            Point head = GetNextPoint();
            if (head.IsHit(food))
            {
                food.sym = head.sym;
                PointsToDraw.Add(food);
                return true;
            }
            else
                return false;
        }
    }
}
