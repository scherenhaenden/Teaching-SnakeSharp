using ShakeSharpEngine.Core.Models;
using ShakeSharpEngine.Core.Rendering;

namespace ShakeSharpEngine.Implementation.Renderers.ConsoleRendering;

public class ConsoleRenderer: IRenderer
{
    public ConsoleRenderer()
    {
        Console.TreatControlCAsInput = true;
        GetConsoleModel();
        // print size of console 
        //System.Console.WriteLine(width.Width);
        //System.Console.WriteLine(width.Height);
    }

    public void RenderEnd(string message="Game Over")
    {
        Console.Clear();
        Console.SetCursorPosition(Console.WindowWidth / 2 - 4, Console.WindowHeight / 2);
        Console.Write(message);
        Console.ReadKey(true);
    }

    public void ResetView()
    {
        Console.Clear();
    }

    public CanvasModel CanvasModel { get; } = new ();
    
    private void GetConsoleModel()
    {
        CanvasModel.Width = Console.WindowWidth;
        CanvasModel.Height = Console.WindowHeight;
    }
    
    public void RenderSnake(LinkedList<Point> snake)
    {
        
        foreach (var point in snake)
        {
            Console.SetCursorPosition(point.X, point.Y);
            //direction = _keyDetection.KeyDirectionDetection(direction);
            Console.Write('*');
        }
    }

    public void RenderFood(Point food)
    {
        Console.SetCursorPosition(food.X, food.Y);
        Console.Write('@');
    }
}