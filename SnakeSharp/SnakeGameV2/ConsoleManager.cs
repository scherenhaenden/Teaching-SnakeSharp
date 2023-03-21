namespace SnakeSharp.SnakeGameV2;


public class ConsoleManager
{
    // Get Size of the console
    public ConsoleModel GetConsoleModel()
    {
        ConsoleModel consoleModel = new ConsoleModel();
        consoleModel.Width = Console.WindowWidth;
        consoleModel.Height = Console.WindowHeight;
        return consoleModel;
    }
}