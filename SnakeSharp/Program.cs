// See https://aka.ms/new-console-template for more information

using ShakeSharpEngine.Core.Models;
using ShakeSharpEngine.Implementation.Game;
using ShakeSharpEngine.Implementation.Renderers.ConsoleRendering;

// start the game
var snakeGameV2 = new SnakeGameV2(new ConsoleSnakeGameRenderer(), new ConsoleInputManagerSnakeEngine());
snakeGameV2.Start();






//Console.WriteLine("Hello, World!");

