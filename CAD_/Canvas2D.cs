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
        public List<Line> Lines { get; set; } = new List<Line>();

        public void AddPoint(Point point)
        {
            Points.Add(point);
            Log.Info($"Byl přidán bod: {point}");
        }

        public void AddLine(Point startPoint, Point endPoint)
        {
            Line line = new Line
            {
                X1 = startPoint.X,
                Y1 = startPoint.Y,
                X2 = endPoint.X,
                Y2 = endPoint.Y,
                Stroke = Brushes.Black,
                StrokeThickness = 2
            };
            Lines.Add(line);
            Log.Info($"Line added: {startPoint} to {endPoint}");
        }

        public void Refresh(Canvas canvas)
        {
            canvas.Children.Clear();

            foreach (var point in Points)
            {
                DrawPoint(canvas, point);
            }

            foreach (var line in Lines)
            {
                canvas.Children.Add(line);
            }
        }

        private void DrawPoint(Canvas canvas, Point point)
        {
            Ellipse ellipse = new Ellipse
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