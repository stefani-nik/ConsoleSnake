using ConsoleSnake.Components;
using System;

namespace ConsoleSnake.Helpers
{
    public class InputHandler
    {
        Snake snake = Snake.Instance;

        public void KeyPressed(ConsoleKey key)
        {

            if (key == ConsoleKey.LeftArrow && snake.NextMove != snake.MoveLeft)
            {
                snake.NextMove = snake.MoveLeft;
            }
            else if (key == ConsoleKey.RightArrow && snake.NextMove != snake.MoveRight)
            {
                snake.NextMove = snake.MoveRight;
            }
            else if (key == ConsoleKey.DownArrow && snake.NextMove != snake.MoveDown)
            {
                snake.NextMove = snake.MoveDown;
            }
            else if (key == ConsoleKey.UpArrow && snake.NextMove != snake.MoveUp)
            {
                snake.NextMove = snake.MoveUp;
            } 
        }
    }
}
