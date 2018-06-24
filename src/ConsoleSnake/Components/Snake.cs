using ConsoleSnake.Components.Contracts;
using ConsoleSnake.Helpers;
using System;
using System.Collections.Generic;

namespace ConsoleSnake.Components
{

    public sealed class Snake : Figure
    {

        public delegate void Movement();


        private static readonly Lazy<Snake> instance =
                        new Lazy<Snake>(() => new Snake());

        public static Snake Instance { get => instance.Value; }

        public Point Head { get; set; } = new Point(Constants.SnakeStartPointX, Constants.SnakeStartPointY, Constants.SnakeSymbol);

        public Point Tail { get => this.PointsToDraw[0]; private set {} }

        public Movement NextMove { get; set; }

        private Snake()
        {
            this.PointsToDraw = new List<Point>();
            this.NextMove = new Movement(MoveRight);

            for (int i = 0; i < Constants.SnakeInitialLength; i++)
            {
                Point newPoint = new Point(this.Head.X, this.Head.Y, this.Head.Symbol);
                this.PointsToDraw.Add(newPoint);
                this.NextMove.Invoke();  
            }  
        }

        public void Move()
        {
            this.Tail.Clear();
            this.PointsToDraw.Remove(this.Tail);

            Point newPoint = new Point(this.Head.X, this.Head.Y, this.Head.Symbol);
            this.PointsToDraw.Add(newPoint);

            this.Head.Draw();
            this.NextMove.Invoke();

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

        public bool IsHitFood(Point food)
        {

            if (this.Head.IsHit(food))
            {
                Point newPoint = new Point(this.Head.X, this.Head.Y, this.Head.Symbol);
                this.PointsToDraw.Add(newPoint);

                this.NextMove.Invoke();
                return true;
            }

            return false;
             
        }

        public void MoveUp()
        {
            this.Head.Y--;
        }

        public void MoveDown()
        {
            this.Head.Y++;
        }

        public void MoveLeft()
        {
            this.Head.X--;
        }

        public void MoveRight()
        {
            this.Head.X++;
        }
    }
}
