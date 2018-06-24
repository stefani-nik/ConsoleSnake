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

            Snake snake = Snake.Instance;
            snake.DrawFigure();

            Walls walls = Walls.Instance;
            walls.DrawWalls();

            FoodCreator foodCreator = new FoodCreator(80, 25, Constants.FoodSymbol);
            Point food = foodCreator.CreateFood();
            food.Draw();

            while (true)
            {
                if (snake.IsHitTail())//|| walls.IsHit(snake))
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
