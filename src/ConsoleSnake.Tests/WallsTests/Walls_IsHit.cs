using Xunit;

namespace ConsoleSnake.Tests.WallsTests
{
    public class Walls_IsHit
    {
        [Fact]
        public void ShouldReturnTrue()
        {
            //arange 
            Components.Walls walls = Components.Walls.Instance;
            Components.Point point = new Components.Point(78, 23, 'd');

            // act 
            bool result = walls.IsHit(point);

            //assert
            Assert.True(result);
            
        }

        [Fact]
        public void ShouldReturnFalse()
        {
            //arange 
            Components.Walls walls = Components.Walls.Instance;
            Components.Point point = new Components.Point(77, 22, 'd');

            // act 
            bool result = walls.IsHit(point);

            //assert
            Assert.False(result);

        }
    }
}
