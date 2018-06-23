using ConsoleSnake.Enums;
using System;

namespace ConsoleSnake.Helpers
{
    public static class InputHandler
    {
        public static Direction GetKeyDirection(ConsoleKey key)
        {
            Direction direction;

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
            else //if (key == ConsoleKey.UpArrow) // TODO: Handle exception
            {
                direction = Direction.UP;
            }
         
            return direction;
        }
    }
}
