namespace SnakeSharp.SnakeGameV2;

public class KeyDetection
{
    public System.Drawing.Point KeyDirectionDetection(System.Drawing.Point direction)
    {
        if (Console.KeyAvailable)
        {
            var key = Console.ReadKey(true).Key;

            if (key == ConsoleKey.LeftArrow && !Equals(direction, Direction.Right))
            {
                direction = Direction.Left;
            }
            else if (key == ConsoleKey.RightArrow && !Equals(direction, Direction.Left))
            {
                direction = Direction.Right;
            }
            else if (key == ConsoleKey.UpArrow && !Equals(direction, Direction.Down))
            {
                direction = Direction.Up;
            }
            else if (key == ConsoleKey.DownArrow && !Equals(direction, Direction.Up))
            {
                direction = Direction.Down;
            }
        }

        return direction;
    }
}