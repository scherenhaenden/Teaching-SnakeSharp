using ShakeSharpEngine.Core.Game;
using ShakeSharpEngine.Core.Models;
using ShakeSharpEngine.Core.Rendering;
using ShakeSharpEngine.Implementation.Game;
using ShakeSharpEngine.Implementation.Renderers;

namespace SnakeSharpBlazor.Client.Snake;

public class GameOfSnake
{
    private readonly IInputManagerSnakeEngine _inputManagerSnakeEngine;
    private ISnakeGame snakeGame;
    private HTML5Canvas html5Canvas;
    public GameOfSnake(IInputManagerSnakeEngine inputManagerSnakeEngine)
    {
        _inputManagerSnakeEngine = inputManagerSnakeEngine;
        html5Canvas= new HTML5Canvas();
        html5Canvas= new HTML5Canvas();
        snakeGame = new SnakeGameV2(html5Canvas, _inputManagerSnakeEngine);
        CanvasModel =  new CanvasModel(800, 800);
        CanvasModelAsCoordinates = html5Canvas.CanvasModel;
    }
    
    public void Run()
    {
        //ISnakeGame snakeGame = new SnakeGameV2(new HTML5Canvas());
    }
    
    // Method for key down with key parameter
    public void KeyDown(string key)
    {
        //snakeGame.KeyDown(key);
    }
    

    private CanvasModel CanvasModelAsCoordinates { get; } 
    
    public CanvasModel CanvasModel { get; } 
}

public class HTML5Canvas : ISnakeGameRenderer
{
    private const int PointSize = 10;
    // Using canvas of 800*800 pixel
    // each point is 10*10 pixel
    public HTML5Canvas()
    {
        CanvasModel = new CanvasModel(80, 80);
    }
    
    public void RenderSnake(LinkedList<Point> snake)
    {
        throw new NotImplementedException();
    }

    public void RenderFood(Point food)
    {
        throw new NotImplementedException();
    }

    public void RenderEnd(string message = "Game Over")
    {
        throw new NotImplementedException();
    }
    
    public void ResetView()
    {
        throw new NotImplementedException();
    }

    public CanvasModel CanvasModel { get; }
}