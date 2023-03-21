namespace SnakeSharp.Implementation.Renderers.ConsoleRendering;


public class ConsoleManager
{
    // Get Size of the console
    public CanvasModel GetConsoleModel()
    {
        CanvasModel canvasModel = new CanvasModel();
        canvasModel.Width = Console.WindowWidth;
        canvasModel.Height = Console.WindowHeight;
        return canvasModel;
    }
}