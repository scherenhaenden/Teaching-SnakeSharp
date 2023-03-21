using Avalonia.Controls;
using ShakeSharpEngine.Core.Game;
using ShakeSharpEngine.Core.Models;
using ShakeSharpEngine.Core.Rendering;
using ShakeSharpEngine.Implementation.Game;
using ShakeSharpEngine.Implementation.Renderers;

namespace SnakeAvaloniaApp.Game;

public class GameOfSnake
{
    private readonly Canvas _canvas;
    private readonly ISnakeGame _snakeGame;
    private readonly ISnakeGameRenderer _snakeGameRenderer;
    public GameOfSnake(Canvas canvas, IInputManagerSnakeEngine inputManagerSnakeEngine)
    {
        _canvas = canvas;
        
        _snakeGameRenderer= new AvaloniaRenderer(canvas);
        _snakeGame = new SnakeGameV2(_snakeGameRenderer, inputManagerSnakeEngine);
        CanvasModel =  new CanvasModel(800, 800);
        CanvasModelAsCoordinates = _snakeGameRenderer.CanvasModel;
    }
    
    public void Run()
    {
        
        _snakeGame.Start();
    }
    
    // Method for key down with key parameter
    public void KeyDown(string key)
    {
        //snakeGame.KeyDown(key);
    }
    

    private CanvasModel CanvasModelAsCoordinates { get; } 
    
    public CanvasModel CanvasModel { get; } 
}