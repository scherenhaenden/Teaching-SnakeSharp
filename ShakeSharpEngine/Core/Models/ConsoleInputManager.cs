namespace ShakeSharpEngine.Core.Models;


public interface IInputManagerSnakeEngine
{
    Point GetDirection(Point currentDirection);

    Point GetDirection(Point currentDirection, string key);
    
    void KeyDown(string key);

}

public class AvaloniaInputManagerSnakeEngine : IInputManagerSnakeEngine
{
    public Point GetDirection(Point currentDirection)
    {
        // Handle the key press here.
        // You can use the KeyEventArgs to determine the direction.
        // For example:
        // if (e.Key == Key.Left && !Equals(currentDirection, Direction.Right))
        // {
        //    currentDirection = Direction.Left;
        // }
        // ...
        
        if(_key == "Left" && !Equals(currentDirection, Direction.Left))
        {
            currentDirection = Direction.Left;
        }
        else if (_key == "Right" && !Equals(currentDirection, Direction.Right))
        {
            currentDirection = Direction.Right;
        }
        else if (_key == "Up" && !Equals(currentDirection, Direction.Up))
        {
            currentDirection = Direction.Up;
        }
        else if (_key == "Down" && !Equals(currentDirection, Direction.Down))
        {
            currentDirection = Direction.Down;
        }

        return currentDirection;
    }

    public Point GetDirection(Point currentDirection, string key)
    {
        throw new NotImplementedException();
    }
    
    private string _key;
    
    public void KeyDown(string key)
    {
        _key = key;
        /*switch (_key)
        {
            case "Up":
                _direction = Direction.Up;
                break;
            case "Down":
                _direction = Direction.Down;
                break;
            case "Left":
                _direction = Direction.Left;
                break;
            case "Right":
                _direction = Direction.Right;
                break;
        }*/
    }
}

public class ConsoleInputManagerSnakeEngine : IInputManagerSnakeEngine
{
    public Point GetDirection(Point currentDirection)
    {
        if (Console.KeyAvailable)
        {
            var key = Console.ReadKey(true).Key;

            if (key == ConsoleKey.LeftArrow && !Equals(currentDirection, Direction.Right))
            {
                currentDirection = Direction.Left;
            }
            else if (key == ConsoleKey.RightArrow && !Equals(currentDirection, Direction.Left))
            {
                currentDirection = Direction.Right;
            }
            else if (key == ConsoleKey.UpArrow && !Equals(currentDirection, Direction.Down))
            {
                currentDirection = Direction.Up;
            }
            else if (key == ConsoleKey.DownArrow && !Equals(currentDirection, Direction.Up))
            {
                currentDirection = Direction.Down;
            }
        }

        return currentDirection;
    }

    public Point GetDirection(Point currentDirection, string key)
    {
        throw new NotImplementedException();
    }

    public void KeyDown(string key)
    {
        throw new NotImplementedException();
    }
}