using Xunit;
using ConsoleSnake.Components;

namespace ConsoleSnake.Tests.Point.Tests
{
    public class Point_Clear
    {
        [Fact]
        public void ShouldClearSymbol()
        {
            //arange
            Components.Point point = new Components.Point(2, 3, 'a');

            //act
            point.Clear();

            //assert
            Assert.Equal(' ', point.Symbol);
        }
    }
}
