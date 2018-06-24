using ConsoleSnake.Components;
using ConsoleSnake.Helpers;
using System;
using System.Threading;

namespace ConsoleSnake.Engine
{
    public static class Game
    {
        public static void Play()
        {
            try
            {
                ConsoleWriter.ConfigureConsole();
            }
            catch
            {
                throw new Exception("Unable to configure the console window with the given parameters");
            }
       

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
                    try
                    {
                        snake.Move();
                    }
                    catch (IndexOutOfRangeException)
                    {
                        throw new IndexOutOfRangeException("Tried to reach illegal coordinates");
                    }
                }

                Thread.Sleep(100);

                if (Console.KeyAvailable)
                {
                    inputHandler.KeyPressed(Console.ReadKey().Key);
                }
            }

            ConsoleWriter.WriteGameOver();
        }
    }
}
