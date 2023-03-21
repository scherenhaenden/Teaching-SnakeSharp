using ShakeSharpEngine.Core.Game;
using ShakeSharpEngine.Core.Models;
using ShakeSharpEngine.Core.Rendering;

namespace ShakeSharpEngine.Implementation.Game;

public class SnakeGameV2: ISnakeGame
{
    private readonly KeyDetection _keyDetection = new();
    
    private readonly IRenderer _renderer;

    public SnakeGameV2(IRenderer renderer)
    {
        _renderer = renderer;
    }

    // Write start method
    public void Start()
    {
        var canvasWidth = _renderer.CanvasModel.Width;
        var canvasHeight = _renderer.CanvasModel.Height;
        
        var snake = new LinkedList<Point>();

        snake.AddLast(new Point(canvasWidth / 2, canvasHeight / 2));
       
        
        // initialize the food
        var food = new Point(RandomNumber(0, canvasWidth), RandomNumber(0, canvasHeight));

        var direction = Direction.Right;
        
        GameRunner(direction, snake, food);
        _renderer.RenderEnd();
        
    }

    private void GameRunner(System.Drawing.Point direction, LinkedList<Point> snake, Point food)
    {
        var canvasWidth = _renderer.CanvasModel.Width;
        var canvasHeight = _renderer.CanvasModel.Height;
        while (true)
        {
            direction = _keyDetection.KeyDirectionDetection(direction);
            // clear the console
            _renderer.ResetView();
            direction = _keyDetection.KeyDirectionDetection(direction);

            // draw the snake
            _renderer.RenderSnake(snake);

            // draw the food
            _renderer.RenderFood(food);

            direction = _keyDetection.KeyDirectionDetection(direction);

            // update the snake
            var head = UpdateSnakeThroughWalls(direction, snake, out var newHead);
            snake.AddFirst(newHead);

            direction = _keyDetection.KeyDirectionDetection(direction);

            if (newHead.X == food.X && newHead.Y == food.Y)
            {
                food = new Point(RandomNumber(0, Console.WindowWidth), RandomNumber(0, Console.WindowHeight));
                //snake.AddFirst(newHead);
                head = UpdateSnakeThroughWalls(direction, snake, out newHead);
                direction = _keyDetection.KeyDirectionDetection(direction);
            }
            else
            {
                snake.RemoveLast();
                direction = _keyDetection.KeyDirectionDetection(direction);
            }

            direction = _keyDetection.KeyDirectionDetection(direction);
            // check for collision with the snake
            if (snake.Count > 1 && snake.Skip(1).Contains(newHead))
            {
                break;
            }
            
            // handle input
            direction = _keyDetection.KeyDirectionDetection(direction);

            // wait for a short time before updating the console again
            Thread.Sleep(100);
            direction = _keyDetection.KeyDirectionDetection(direction);
        }
    }

    private Point UpdateSnakeThroughWalls(System.Drawing.Point direction, LinkedList<Point> snake, out Point newHead)
    {
        // check for null could be done in a better way
        if(snake.First == null)
            throw new ArgumentNullException(nameof(snake));
        
        var head = snake.First.Value;
        
        var sumOfX = head.X + direction.X;
        var sumOfY = head.Y + direction.Y;

        if (sumOfX < 0)
        {
            head.X = Console.WindowWidth;
            head = UpdateSnakeOverTheWall(direction, snake, head.X ,head.Y ,  out newHead);
            return head;
        }
        
        if (sumOfX >= Console.WindowWidth)
        {
            head.X = 0;
            head = UpdateSnakeOverTheWall(direction, snake, head.X ,head.Y ,  out newHead);
            return head;
        }
        
        if (sumOfY < 0)
        {
            head.Y = Console.WindowHeight;
            head = UpdateSnakeOverTheWall(direction, snake, head.X ,head.Y ,  out newHead);
            return head;
        }
        
        if (sumOfY >= Console.WindowHeight)
        {
            head.Y = 0;
            head = UpdateSnakeOverTheWall(direction, snake, head.X ,head.Y ,  out newHead);
            return head;
        }
        
            

        newHead = new Point(head.X + direction.X, head.Y + direction.Y);
        return head;
    }
    
    private Point UpdateSnakeOverTheWall(System.Drawing.Point direction, LinkedList<Point> snake, int X, int Y, out Point newHead)
    {
        // check for null could be done in a better way
        if(snake.First == null)
            throw new ArgumentNullException(nameof(snake));
        var head = snake.First.Value;
        newHead = new Point(X + direction.X, Y + direction.Y);
        return head;
    }


    // Write method for random number

    private int RandomNumber(int min, int max)
    {
        var random = new Random();
        return random.Next(min, max);
    }
}