using ConsoleSnake.Components;
using ConsoleSnake.Components.Contracts;
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

            InputHandler inputHandler = new InputHandler();

            Snake snake = Snake.Instance;
            snake.DrawFigure();

            Walls walls = Walls.Instance;
            walls.DrawWalls();

            Point food = FoodCreator.CreateFood();
            food.Draw();

            while (true)
            {
                if (snake.IsHitTail() || walls.IsHit(snake.Head))
                {
                    break;
                }

                if (snake.Eat(food))
                {
                    food = FoodCreator.CreateFood();
                    food.Draw();
                }
                else
                {
                    snake.Move();
                }

                Thread.Sleep(100);

                if (Console.KeyAvailable)
                {
                    inputHandler.GetKeyDirection(Console.ReadKey().Key);
                }
            }

            ConsoleWriter.WriteGameOver();
        }
    }
}
