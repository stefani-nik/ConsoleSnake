using System;
using Xunit;
namespace ConsoleSnake.Tests.Line.Tests
{
    public class Line_Create
    {
        [Fact]
        public void ShouldThrowException()
        {
            //arange
            int startX = 5, endX = 6, y = 7;
            char symbol = '.';
            string lineStrategy = "BERTIKAL";

            //act
            Exception ex = Assert.Throws<NullReferenceException>(() => new Components.Line(startX, endX, y, symbol, lineStrategy));

            //assert 
            Assert.Equal("The line strategy is not recognized", ex.Message);

        }
    }
}
