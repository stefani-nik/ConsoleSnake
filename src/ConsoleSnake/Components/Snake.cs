using ConsoleSnake.Components.Contracts;
using ConsoleSnake.Helpers;
using System;
using System.Collections.Generic;

namespace ConsoleSnake.Components
{
    /// <summary>
    /// A singleton class which represents the Snake component
    /// </summary>
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
        /// <summary>
        /// Method responsible for moving the head of the snake to the next point 
        /// depending on the direction and removing the tail of the snake
        /// </summary>
        public void Move()
        {
            this.Tail.Clear();
            this.PointsToDraw.Remove(this.Tail);

            Point newPoint = new Point(this.Head.X, this.Head.Y, this.Head.Symbol);
            this.PointsToDraw.Add(newPoint);

            try
            {
                this.Head.Draw();
            }
            catch (IndexOutOfRangeException)
            {
                throw new IndexOutOfRangeException("Trying to write on position out of the console.");
            }
           
            this.NextMove.Invoke();

        }
        /// <summary>
        /// Checks if the head of the snake had hit any of the other points of the snake 
        /// </summary>
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

        /// <summary>
        /// Checks if the head of the snake had hit the current food point
        /// </summary>
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

        #region MovementMethods

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

        #endregion
    }
}
