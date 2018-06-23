using ConsoleSnake.Components.Contracts;
using ConsoleSnake.Enums;
using System;
using System.Collections.Generic;

namespace ConsoleSnake.Components
{
    class Snake : Figure
    {
        Direction direction;

        public Snake(Point tail, int lenght, Direction _direction)
        {
            direction = _direction;
            PointsToDraw = new List<Point>();
            for (int i = 0; i < lenght; i++)
            {
                Point p = new Point(tail);
                p.Move(i, direction);
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
            nextPoint.Move(1, direction);
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
                direction = Direction.LEFT;
            }
            else if (key == ConsoleKey.RightArrow)
            {
                direction = Direction.RIGHT;
            }
            else if (key == ConsoleKey.DownArrow)
            {
                direction = Direction.DOWN;
            }
            else if (key == ConsoleKey.UpArrow)
            {
                direction = Direction.UP;
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
