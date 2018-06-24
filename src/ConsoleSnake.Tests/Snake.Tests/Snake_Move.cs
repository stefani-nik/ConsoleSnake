using Xunit;

namespace ConsoleSnake.Tests.Snake.Tests
{
    public class Snake_Move
    {
        [Fact]
        public void ShouldMoveToNextPointDown()
        {
            //arange 
            Components.Snake snake = Components.Snake.Instance;
            Helpers.InputHandler inputHandler = new Helpers.InputHandler();
            snake.Head.X = Helpers.Constants.SnakeStartPointX;
            snake.Head.Y = Helpers.Constants.SnakeStartPointY;
            snake.NextMove = snake.MoveDown;

            //act
            inputHandler.KeyPressed(System.ConsoleKey.DownArrow);
            snake.NextMove.Invoke();

            //assert
            Assert.Equal(snake.MoveDown, snake.NextMove);
            Assert.Equal(7, snake.Head.Y);
            Assert.Equal(4, snake.Head.X);
        }

        [Fact]
        public void ShouldMoveToNextPointLeft()
        {
            //arange 
            Components.Snake snake = Components.Snake.Instance;
            Helpers.InputHandler inputHandler = new Helpers.InputHandler();
            snake.Head.X = Helpers.Constants.SnakeStartPointX;
            snake.Head.Y = Helpers.Constants.SnakeStartPointY;
            snake.NextMove = snake.MoveRight;

            //act
            inputHandler.KeyPressed(System.ConsoleKey.LeftArrow);
            snake.NextMove.Invoke();

            //assert
            Assert.Equal(snake.MoveLeft, snake.NextMove);
            Assert.Equal(6, snake.Head.Y);
            Assert.Equal(3, snake.Head.X);
        }

        [Fact]
        public void ShouldMoveToNextPointUp()
        {
            //arange 
            Components.Snake snake = Components.Snake.Instance;
            Helpers.InputHandler inputHandler = new Helpers.InputHandler();
            snake.Head.X = Helpers.Constants.SnakeStartPointX;
            snake.Head.Y = Helpers.Constants.SnakeStartPointY;
            snake.NextMove = snake.MoveUp;

            //act
            inputHandler.KeyPressed(System.ConsoleKey.UpArrow);
            snake.NextMove.Invoke();

            //assert
            Assert.Equal(snake.MoveUp, snake.NextMove);
            Assert.Equal(5, snake.Head.Y);
            Assert.Equal(4, snake.Head.X);
        }

        [Fact]
        public void ShouldMoveToNextPointRight()
        {
            //arange 
            Components.Snake snake = Components.Snake.Instance;
            Helpers.InputHandler inputHandler = new Helpers.InputHandler();
            snake.Head.X = Helpers.Constants.SnakeStartPointX;
            snake.Head.Y = Helpers.Constants.SnakeStartPointY;
            snake.NextMove = snake.MoveRight;

            //act
            inputHandler.KeyPressed(System.ConsoleKey.RightArrow);
            snake.NextMove.Invoke();

            //assert
            Assert.True(snake.IsHitTail());
            Assert.Equal(snake.MoveRight, snake.NextMove);
            Assert.Equal(6, snake.Head.Y);
            Assert.Equal(5, snake.Head.X);
        }

        [Fact]
        public void ShouldMakeAHit()
        {
            //arange 
            Components.Snake snake = Components.Snake.Instance;
            Helpers.InputHandler inputHandler = new Helpers.InputHandler();
            snake.Head.X = Helpers.Constants.SnakeStartPointX;
            snake.Head.Y = Helpers.Constants.SnakeStartPointY;
            snake.NextMove = snake.MoveRight;

            //act
            inputHandler.KeyPressed(System.ConsoleKey.DownArrow);
            snake.NextMove.Invoke();
            inputHandler.KeyPressed(System.ConsoleKey.LeftArrow);
            snake.NextMove.Invoke();
            inputHandler.KeyPressed(System.ConsoleKey.UpArrow);
            snake.NextMove.Invoke();
            inputHandler.KeyPressed(System.ConsoleKey.RightArrow);
            snake.NextMove.Invoke();

            //assert
            Assert.True(snake.IsHitTail());

        }
    }
}
