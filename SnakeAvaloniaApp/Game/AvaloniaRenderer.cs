using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Shapes;
using Avalonia.Media;
using Avalonia.Threading;
using ShakeSharpEngine.Core.Rendering;
using ShakeSharpEngine.Implementation.Renderers;
using Point = ShakeSharpEngine.Core.Models.Point;

namespace SnakeAvaloniaApp.Game;

public class AvaloniaRenderer : ISnakeGameRenderer
{
        private readonly Canvas _canvas;

        public AvaloniaRenderer(Canvas canvas)
        {
            _canvas = canvas;
        }
        
        int timeBetweenFrames = 1;
        public void RenderSnake(LinkedList<Point> snake)
        {
            new Thread(() =>
            {
                Dispatcher.UIThread.InvokeAsync(() =>
                {
                    // Render the game
                    _canvas.Children.Clear();

                    var gh =snake.ToArray();

                    foreach (var point in gh)
                    {
                        var rect = new Rectangle
                        {
                            Width = 10,
                            Height = 10,
                            Fill = Brushes.Green,
                        };

                        Canvas.SetLeft(rect, point.X * 10);
                        Canvas.SetTop(rect, point.Y * 10);

                        _canvas.Children.Add(rect);
                    }
                });
                Thread.Sleep(timeBetweenFrames);
            }).Start();
            
           
        }

        void ISnakeGameRenderer.RenderFood(Point food)
        {
            RenderFood(food);
        }

        public void RenderFood(Point food)
        {
            
            new Thread(() =>
            {
                Dispatcher.UIThread.InvokeAsync(() =>
                {
                    // Render the game
                    var rect = new Rectangle
                    {
                        Width = 10,
                        Height = 10,
                        Fill = Brushes.Cyan,
                    };

                    Canvas.SetLeft(rect, food.X * 10);
                    Canvas.SetTop(rect, food.Y * 10);

                    _canvas.Children.Add(rect);
                });
                Thread.Sleep(timeBetweenFrames);
            }).Start();
            
           
        }

        
        public void RenderEnd(string message = "Game Over")
        {
            
            
            new Thread(() =>
            {
                Dispatcher.UIThread.InvokeAsync(() =>
                {
                    _canvas.Children.Clear();
                    var text = new FormattedText
                    {
                        Text = message,
                        TextAlignment = TextAlignment.Center,
                        //VerticalAlignment = Avalonia.Media.VerticalAlignment.Center,
                        //HorizontalAlignment = Avalonia.Media.HorizontalAlignment.Center,
                        Typeface = new Typeface("Segoe UI", FontStyle.Oblique),
                        FontSize = 36,
                        //Brush = Brushes.Black,
                    };
                    
                    
                    TextBlock textBlock = new TextBlock();
                    textBlock.Text = message;
                    textBlock.Foreground = new SolidColorBrush(Colors.Black);
//Canvas.SetLeft(textBlock, x);
//Canvas.SetTop(textBlock, y);
                    textBlock.RenderTransform = new RotateTransform(-90, 0, 0); // this line can rotate it but not in the axis i want
                    textBlock.Margin = new Thickness(100, 100, 0, 0);
                    
                    
                    //_canvas.Children.Add(text);
                    
                    



                    Canvas.SetLeft(textBlock, (_canvas.Bounds.Width - text.Bounds.Width) / 2);
                    Canvas.SetTop(textBlock, (_canvas.Bounds.Height - text.Bounds.Height) / 2);

                    _canvas.Children.Add(textBlock);
                });
                Thread.Sleep(timeBetweenFrames);
            }).Start();
            
            
        }

        public void ResetView()
        {
            new Thread(() =>
            {
                Dispatcher.UIThread.InvokeAsync(() =>
                {
                    _canvas.Children.Clear();
                });
                // Wait for the next frame
                Thread.Sleep(timeBetweenFrames);
            }).Start();
            
            
        }
        
        private CanvasModel _canvasModel;

        public CanvasModel CanvasModel
        {
            // write getter with logic
            get => GetCanvasModel();
        }
        
        private CanvasModel GetCanvasModel()
        {
            if (_canvasModel == null)
            {
                _canvasModel = new CanvasModel(
                    (int)_canvas.Width / 10,
                    (int)_canvas.Height / 10);
            }

            return _canvasModel;

        }

       
    }
