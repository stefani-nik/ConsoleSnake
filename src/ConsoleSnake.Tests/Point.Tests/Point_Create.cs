using Xunit;

namespace ConsoleSnake.Tests.Point.Tests
{
    public class Point_Create
    {
        [Fact]
        public void ShouldBeCreatedCorrectly()
        {
            //arange & act
            Components.Point point = new Components.Point(2, 3, 'a');

            //assert
            Assert.Equal(2, point.X);
            Assert.Equal(3, point.Y);
            Assert.Equal('a', point.Symbol);

        }
    }
}
