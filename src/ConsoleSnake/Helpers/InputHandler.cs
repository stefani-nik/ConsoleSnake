using ConsoleSnake.Components;
using ConsoleSnake.Enums;
using System;

namespace ConsoleSnake.Helpers
{
    public class InputHandler
    {
        Snake snake = Snake.Instance;

        public void GetKeyDirection(ConsoleKey key)
        {

            if (key == ConsoleKey.LeftArrow)
            {
                snake.Direction = Direction.LEFT;
            }
            else if (key == ConsoleKey.RightArrow)
            {
                snake.Direction = Direction.RIGHT;
            }
            else if (key == ConsoleKey.DownArrow)
            {
                snake.Direction  = Direction.DOWN;
            }
            else if (key == ConsoleKey.UpArrow)
            {
                snake.Direction = Direction.UP;
            } 
        }
    }
}
