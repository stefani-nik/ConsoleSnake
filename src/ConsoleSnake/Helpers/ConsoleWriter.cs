using ConsoleSnake.Helpers;
using System;

namespace ConsoleSnake.Engine
{
    public static class ConsoleWriter
    {
        public static void ConfigureConsole()
        {
            Console.SetBufferSize(Constants.ConsoleWidth, Constants.ConsoleHeight);
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine("Press enter to start the game!");
            Console.ResetColor();
            Console.ReadLine();
        }

        static void WriteGameOver()
        {
            Console.SetCursorPosition(Constants.GameOverCursorPositionX, Constants.GameOverCursorPositionY);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("You lost . Press enter to quit the game.");
        }

        //TODO: Implement score

    }
}
