using ShakeSharpEngine.Core.Game;
using ShakeSharpEngine.Core.Models;
using ShakeSharpEngine.Core.Rendering;

namespace ShakeSharpEngine.Implementation.Game;

public class SnakeGameV1: ISnakeGame
{
    private readonly ISnakeGameRenderer _snakeGameRenderer;
    private readonly IInputManagerSnakeEngine _inputManagerSnakeEngine;

    public SnakeGameV1(ISnakeGameRenderer snakeGameRenderer, IInputManagerSnakeEngine inputManagerSnakeEngine)
    {
        _snakeGameRenderer = snakeGameRenderer;
        _inputManagerSnakeEngine = inputManagerSnakeEngine;
    }


    // Write start method
    public void Start()
    {
        
        var canvasWidth = _snakeGameRenderer.CanvasModel.Width;
        var canvasHeight = _snakeGameRenderer.CanvasModel.Height;
        
        var snake = new LinkedList<Point>();

        snake.AddLast(new Point(canvasWidth / 2, canvasHeight / 2));
       
        
        // initialize the food
        var food = new Point(RandomNumber(0, canvasWidth), RandomNumber(0, canvasHeight));

        var direction = Direction.Right;
        
        GameRunner(direction, snake, food);
        _snakeGameRenderer.RenderEnd();
    }

    private void GameRunner(Point direction, LinkedList<Point> snake, Point food)
    {
        var canvasWidth = _snakeGameRenderer.CanvasModel.Width;
        var canvasHeight = _snakeGameRenderer.CanvasModel.Height;
        while (true)
        {
            direction = _inputManagerSnakeEngine.GetDirection(direction);
            // clear the console
            _snakeGameRenderer.ResetView();
            direction = _inputManagerSnakeEngine.GetDirection(direction);

            // draw the snake
            _snakeGameRenderer.RenderSnake(snake);

            // draw the food
            _snakeGameRenderer.RenderFood(food);

            direction = _inputManagerSnakeEngine.GetDirection(direction);

            // update the snake
            var head = UpdateSnake(direction, snake, out var newHead);
            snake.AddFirst(newHead);

            direction = _inputManagerSnakeEngine.GetDirection(direction);

            if (newHead.X == food.X && newHead.Y == food.Y)
            {
                
                food = new Point(RandomNumber(0, canvasWidth), RandomNumber(0, canvasHeight));
                //snake.AddFirst(newHead);
                head = UpdateSnake(direction, snake, out newHead);
                direction = _inputManagerSnakeEngine.GetDirection(direction);
            }
            else
            {
                snake.RemoveLast();
                direction = _inputManagerSnakeEngine.GetDirection(direction);
            }

            // check for collision with the wall
            if (head.X < 0 || head.X >= canvasWidth || head.Y < 0 || head.Y >= canvasHeight)
            {
                break;
            }

            direction = _inputManagerSnakeEngine.GetDirection(direction);
            // check for collision with the snake
            if (snake.Count > 1 && snake.Skip(1).Contains(newHead))
            {
                break;
            }


            // handle input
            direction = _inputManagerSnakeEngine.GetDirection(direction);

            // wait for a short time before updating the console again
            Thread.Sleep(100);
            direction = _inputManagerSnakeEngine.GetDirection(direction);
        }
    }

    private Point UpdateSnake(Point direction, LinkedList<Point> snake, out Point newHead)
    {
        // check for null could be done in a better way
        if(snake.First == null)
            throw new ArgumentNullException(nameof(snake));
        var head = snake.First.Value;
        newHead = new Point(head.X + direction.X, head.Y + direction.Y);
        return head;
    }


    // Write method for random number

    private int RandomNumber(int min, int max)
    {
        var random = new Random();
        return random.Next(min, max);
    }
}