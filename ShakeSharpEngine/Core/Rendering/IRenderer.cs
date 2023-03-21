using ShakeSharpEngine.Core.Models;
using ShakeSharpEngine.Implementation.Renderers;

namespace ShakeSharpEngine.Core.Rendering;

public interface IRenderer
{
    void RenderSnake(LinkedList<Point> snake);
    void RenderFood(Point food);
    
    void RenderEnd(string message="Game Over");
    
    void ResetView();
    
    CanvasModel CanvasModel { get; }
}