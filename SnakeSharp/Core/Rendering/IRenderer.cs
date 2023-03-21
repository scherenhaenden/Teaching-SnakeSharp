using SnakeSharp.Implementation.Renderers;
using SnakeSharp.SnakeGameV2;

namespace SnakeSharp.Core.Rendering;

public interface IRenderer
{
    void RenderSnake(LinkedList<Point> snake);
    void RenderFood(Point food);
    
    void RenderEnd(string message="Game Over");
    
    void ResetView();
    
    CanvasModel CanvasModel { get; }
}