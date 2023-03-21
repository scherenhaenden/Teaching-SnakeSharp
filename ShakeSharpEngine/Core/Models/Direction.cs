namespace ShakeSharpEngine.Core.Models;

public abstract class Direction
{
    public static readonly System.Drawing.Point Up = new(0, -1);
    public static readonly System.Drawing.Point Down = new(0, 1);
    public static readonly System.Drawing.Point Left = new(-1, 0);
    public static readonly System.Drawing.Point Right = new(1, 0);
}