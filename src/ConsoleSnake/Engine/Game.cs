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
            snake.Draw();

            Walls walls = Walls.Instance;
            walls.Draw();

            Point food = FoodCreator.CreateFood();
            food.Draw();

            int score = 0;
            ConsoleWriter.WriteScore(score);

            while (true)
            {
                if (snake.IsHitTail() || walls.IsHit(snake.Head))
                {
                    break;
                }

                if (snake.IsHitFood(food))
                {
                    food = FoodCreator.CreateFood();
                    food.Draw();

                    score += 10;
                    ConsoleWriter.WriteScore(score);
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
