using ConsoleSnake.Helpers;
using System;

namespace ConsoleSnake.Engine
{
    public static class ConsoleWriter
    {
        public static void ConfigureConsole()
        {
            try
            {
                Console.SetWindowSize(Constants.ConsoleWidth, Constants.ConsoleHeight);
            }
            catch(IndexOutOfRangeException)
            {
                throw new IndexOutOfRangeException("The boundries of the console window are out of range");
            }
            
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
            Console.WriteLine("You lost. Press any key to quit the game.");
            Console.ReadKey();
            Environment.Exit(0);
        }

        public static void WritePoint(int x, int y, char symbol)
        {
            try
            {
                Console.SetCursorPosition(x, y);
            }
            catch
            {
                throw new IndexOutOfRangeException("Trying to set the cursor on non-existing coordinates.");
            }
          
            Console.Write(symbol);
        }

        public static void WriteScore(int score)
        {
            Console.SetCursorPosition(2, Constants.ConsoleHeight - 2);
            Console.WriteLine($"Score: {score}");
        }

    }
}
