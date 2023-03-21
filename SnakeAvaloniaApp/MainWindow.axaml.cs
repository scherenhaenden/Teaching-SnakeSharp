using System.Threading.Tasks;
using Avalonia.Controls;
using Avalonia.Controls.Shapes;
using Avalonia.Input;
using Avalonia.Media;
using Avalonia.Threading;
using ShakeSharpEngine.Core.Models;
using SnakeAvaloniaApp.Game;
//using IInputManager = Avalonia.Input.IInputManager;

namespace SnakeAvaloniaApp;

public partial class MainWindow : Window
{

    private IInputManagerSnakeEngine _inputManager;
    public MainWindow()
    {
        InitializeComponent();
        _inputManager = new AvaloniaInputManagerSnakeEngine();
        GameOfSnake gameOfSnake = new GameOfSnake(snakeCanvas, _inputManager);
        
        Task.Run(() => gameOfSnake.Run());
        
        this.KeyDown += OnKeyDown;
    }
    
    public void OnKeyDown(object sender, KeyEventArgs e)
    {
        Dispatcher.UIThread.InvokeAsync(() =>
        {
            // Handle the key press here
            if (e.Key == Key.Up)
            {
                _inputManager.KeyDown("Up");
                // Handle up arrow key
            }
            else if (e.Key == Key.Down)
            {
                // Handle down arrow key
                _inputManager.KeyDown("Down");
            }
            else if (e.Key == Key.Left)
            {
                // Handle left arrow key
                _inputManager.KeyDown("Left");
            }
            else if (e.Key == Key.Right)
            {
                // Handle right arrow key
                _inputManager.KeyDown("Right");
            }
        });
        
        
        /*switch (e.Key)
        {
            case Key.Left:
                // Handle left arrow key press.
                break;
            case Key.Right:
                // Handle right arrow key press.
                break;
            case Key.Up:
                // Handle up arrow key press.
                break;
            case Key.Down:
                // Handle down arrow key press.
                break;
        }*/
    }

    

}