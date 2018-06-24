using ConsoleSnake.Components.Contracts;
using ConsoleSnake.Helpers;
using System;
using System.Collections.Generic;

namespace ConsoleSnake.Components
{
    public class Walls
    {
        private List<Line> _walls;

        private static readonly Lazy<Walls> instance =
                      new Lazy<Walls>(() => new Walls());

        public static Walls Instance { get => instance.Value; }

        private Walls()
        {
            _walls = new List<Line>()
            {
                new Line(0, Constants.ConsoleWidth - 2, 0, '-', "horizontal"),
                new Line(0, Constants.ConsoleWidth - 2, Constants.ConsoleHeight - 1, '-', "horizontal"),
                new Line(0, Constants.ConsoleHeight - 1, 0, '|', "vertical"),
                new Line(0, Constants.ConsoleHeight - 1, Constants.ConsoleWidth - 2, '|', "vertical"),
            };
        }

        public void DrawWalls()
        {
            this._walls.ForEach(w => w.DrawFigure());
        }

        public bool IsHit(Point withPoint)
        {
            bool isHit = false;
            this._walls.ForEach(w =>
            {
                w.PointsToDraw.ForEach(p => {
                    if (p.IsHit(withPoint))
                        isHit = true;
                });
            });

            return isHit;
        }

    }
}
