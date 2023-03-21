namespace SnakeSharp.SnakeGameV2;

public class SnakeGameV2
{
    private readonly KeyDetection _keyDetection = new KeyDetection();

    // Write start method
    public void Start()
    {
        //DetectKeyStroke();
        
        Console.TreatControlCAsInput = true;
        // get current size of the console
        var width = GetSizeConsoleModel();
        
        // print size of console 
        Console.WriteLine(width.Width);
        Console.WriteLine(width.Height);
        
        var snake = new LinkedList<Point>();
        snake.AddLast(new Point(Console.WindowWidth / 2, Console.WindowHeight / 2));
       
        
        // initialize the food
        var food = new Point(RandomNumber(0, Console.WindowWidth), RandomNumber(0, Console.WindowHeight));

        var direction = Direction.Right;
        
        GameRunner(direction, snake, food);
        Console.Clear();
        Console.SetCursorPosition(Console.WindowWidth / 2 - 4, Console.WindowHeight / 2);
        Console.Write("Game Over");
        Console.ReadKey(true);
        
    }

    private void GameRunner(System.Drawing.Point direction, LinkedList<Point> snake, Point food)
    {
        while (true)
        {
            direction = _keyDetection.KeyDirectionDetection(direction);
            // clear the console
            Console.Clear();
            direction = _keyDetection.KeyDirectionDetection(direction);

            // draw the snake
            foreach (var point in snake)
            {
                Console.SetCursorPosition(point.X, point.Y);
                direction = _keyDetection.KeyDirectionDetection(direction);
                Console.Write('*');
            }

            // draw the food
            Console.SetCursorPosition(food.X, food.Y);
            Console.Write('@');

            direction = _keyDetection.KeyDirectionDetection(direction);

            // update the snake
            var head = UpdateSnake(direction, snake, out var newHead);
            snake.AddFirst(newHead);

            direction = _keyDetection.KeyDirectionDetection(direction);

            if (newHead.X == food.X && newHead.Y == food.Y)
            {
                food = new Point(RandomNumber(0, Console.WindowWidth), RandomNumber(0, Console.WindowHeight));
                //snake.AddFirst(newHead);
                head = UpdateSnake(direction, snake, out newHead);
                direction = _keyDetection.KeyDirectionDetection(direction);
            }
            else
            {
                snake.RemoveLast();
                direction = _keyDetection.KeyDirectionDetection(direction);
            }

            // check for collision with the wall
            if (head.X < 0 || head.X >= Console.WindowWidth || head.Y < 0 || head.Y >= Console.WindowHeight)
            {
                break;
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

    private static Point UpdateSnake(System.Drawing.Point direction, LinkedList<Point> snake, out Point newHead)
    {
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

    public ConsoleModel GetSizeConsoleModel()
    {
        ConsoleManager consoleManager = new ConsoleManager();
        
        // get current size of the console
        return consoleManager.GetConsoleModel();
    }

    
    
    
    
}