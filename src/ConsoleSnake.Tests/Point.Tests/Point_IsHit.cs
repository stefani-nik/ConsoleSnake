using Xunit;
using ConsoleSnake.Components;

namespace ConsoleSnake.Tests.Point.Tests
{
    public class Point_IsHit
    {
        [Fact]
        public void ShouldReturnTrueWithDifferentSymbol()
        {
            //arange
            Components.Point point = new Components.Point(2, 3, 'a');
            Components.Point isHitPoint = new Components.Point(2, 3, 'b');

            //act
            bool result = point.IsHit(isHitPoint);

            //assert
            Assert.True(result);

        }

        [Fact]
        public void ShouldReturnTrueWithSameSymbol()
        {
            //arange
            Components.Point point = new Components.Point(2, 3, 'a');
            Components.Point isHitPoint = new Components.Point(2, 3, 'a');

            //act
            bool result = point.IsHit(isHitPoint);

            //assert
            Assert.True(result);

        }

        [Fact]
        public void ShouldReturnFalse()
        {
            //arange
            Components.Point point = new Components.Point(2, 2, 'a');
            Components.Point isHitPoint = new Components.Point(2, 3, 'b');

            //act
            bool result = point.IsHit(isHitPoint);

            //assert
            Assert.False(result);

        }

    }
}
