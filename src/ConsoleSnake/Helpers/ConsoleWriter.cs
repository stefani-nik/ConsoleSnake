using ConsoleSnake.Helpers;
using System;

namespace ConsoleSnake.Engine
{
    public static class ConsoleWriter
    {
        public static void ConfigureConsole()
        {
            Console.SetWindowSize(Constants.ConsoleWidth,Constants.ConsoleHeight);
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.SetCursorPosition(Constants.GameOverCursorPositionX, Constants.GameOverCursorPositionY);
            Console.WriteLine("Press any key to start the game!");
            Console.CursorVisible = false;
            Console.ReadKey();
            Console.Clear();
            Console.Beep();
        }

        public static void WriteGameOver()
        {
            Console.Clear();
            Console.SetCursorPosition(Constants.GameOverCursorPositionX, Constants.GameOverCursorPositionY);
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("You lost . Press any key to quit the game.");
            Console.ReadKey();
            Environment.Exit(0);
        }

        //TODO: Implement score

    }
}
