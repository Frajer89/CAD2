using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace CAD_
{
    public class Canvas2D
    {
        public List<Point> Points { get; set; } = new List<Point>();

        public void AddPoint(Point point)
        {
            Points.Add(point);
            Log.Info($"Byl přidán bod: {point}");
        }

        public void Refresh(Canvas canvas)
        {
            canvas.Children.Clear();
            foreach (var point in Points)
            {
                Ellipse ellipse = new Ellipse()
                {
                    Width = 8,
                    Height = 8,
                    Fill = Brushes.Blue
                };
                Canvas.SetLeft(ellipse, point.X - 4);
                Canvas.SetTop(ellipse, point.Y - 4);
                canvas.Children.Add(ellipse);
            }
        }
    }
}