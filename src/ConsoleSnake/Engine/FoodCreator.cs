using ConsoleSnake.Components;
using ConsoleSnake.Components.Contracts;
using ConsoleSnake.Helpers;
using System;

namespace ConsoleSnake.Engine
{
    public static class FoodCreator
    {
        public static Point CreateFood()
        {
            Random random = new Random();
            int x = random.Next(2, Constants.WallsWidth);
            int y = random.Next(2, Constants.WallsHeight);
            return new Point(x, y, Constants.FoodSymbol);
        }
    }
}
