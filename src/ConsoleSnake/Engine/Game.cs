

using ConsoleSnake.Components;
using ConsoleSnake.Components.Contracts;
using ConsoleSnake.Enums;
using ConsoleSnake.Helpers;
using System;
using System.Threading;

namespace ConsoleSnake.Engine
{
    public static class Game
    {
        public static void Play()
        {
            ConsoleWriter.ConfigureConsole();

            Line upLine = new Line(0, Constants.ConsoleWidth - 2, 0, '-', "horizontal");
            Line downLine = new Line(0, Constants.ConsoleWidth - 2, Constants.ConsoleHeight - 1, '-', "horizontal");
            Line leftLine = new Line(0, Constants.ConsoleHeight - 1, 0 , '|', "vertical");
            Line rightLine = new Line(0, Constants.ConsoleHeight - 1, Constants.ConsoleWidth - 2, '|', "vertical");

            upLine.DrawFigure();
            downLine.DrawFigure();
            leftLine.DrawFigure();
            rightLine.DrawFigure();


            Point startPoint = new Point(Constants.SnakeStartPointX, Constants.SnakeStartPointY, Constants.SnakeSymbol);
            Snake snake = new Snake(startPoint, 5, Direction.RIGHT);
            snake.DrawFigure();

            FoodCreator foodCreator = new FoodCreator(80, 25, Constants.FoodSymbol);
            Point food = foodCreator.CreateFood();
            food.Draw();

            while (true)
            {
                if (snake.IsHitTail())  //walls.IsHit(snake) || 
                {

                    break;
                }

                if (snake.Eat(food))
                {
                    food = foodCreator.CreateFood();
                    food.Draw();
                }
                else
                {
                    snake.Move();
                }

                Thread.Sleep(100);

                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo key = Console.ReadKey();
                    snake.HandleKey(key.Key);
                }
            }

            ConsoleWriter.WriteGameOver();
        }
    }
}
