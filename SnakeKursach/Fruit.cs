using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Shapes;
using System.Windows;
using System.Windows.Media;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace SnakeKursach
{
    public class Fruit
    {
        BitmapImage img = new BitmapImage(new Uri(@"F:\Новая папка\C#\SnakeKursach\SnakeKursach\Source\Image\4.png"));
        public Coordinate FruitCoordinate { get; private set; }
        public Ellipse Circle { get; set; } = new Ellipse();
        public Fruit()
        {
            var rd = new Random();
            var x = rd.Next(0, 61) * 10;
            var y = rd.Next(0, 40) * 10;

            Circle.Width = Circle.Height = 20;
            Circle.Fill = new ImageBrush(img);

            Canvas.SetLeft(Circle, x);
            Canvas.SetTop(Circle, y);

            FruitCoordinate = new Coordinate(x, y);

        }
    }
    public class GreenFruit:Fruit
    {
        BitmapImage img = new BitmapImage(new Uri(@"F:\Новая папка\C#\SnakeKursach\SnakeKursach\Source\Image\3.png"));
        public Coordinate FruitCoordinate { get; private set; }
        public GreenFruit()
        {
            var rd = new Random();
            var x = rd.Next(0, 61) * 10;
            var y = rd.Next(0, 40) * 10;

            Circle.Width = Circle.Height = 20;
            Circle.Fill = new ImageBrush(img);

            Canvas.SetLeft(Circle, x);
            Canvas.SetTop(Circle, y);

            FruitCoordinate = new Coordinate(x, y);
        }
    }
    public class YellowFruit: Fruit
    {
        BitmapImage img = new BitmapImage(new Uri(@"F:\Новая папка\C#\SnakeKursach\SnakeKursach\Source\Image\2.png"));
        public Coordinate FruitCoordinate { get; private set; }
        public YellowFruit()
        {
            var rd = new Random();
            var x = rd.Next(0, 61) * 10;
            var y = rd.Next(0, 40) * 10;

            Circle.Width = Circle.Height = 20;
            Circle.Fill = new ImageBrush(img);
            Canvas.SetLeft(Circle, x);
            Canvas.SetTop(Circle, y);

            FruitCoordinate = new Coordinate(x, y);
        }
    }
    public class GiantFruit:Fruit
    {
        BitmapImage img = new BitmapImage(new Uri(@"F:\Новая папка\C#\SnakeKursach\SnakeKursach\Source\Image\5.png"));
        public Coordinate FruitCoordinate { get; private set; }
        public GiantFruit()
        {
            var rd = new Random();
            var x = rd.Next(0, 61) * 10;
            var y = rd.Next(0, 40) * 10;

            Circle.Width = Circle.Height = 20;
            Circle.Fill = new ImageBrush(img);
            Canvas.SetLeft(Circle, x);
            Canvas.SetTop(Circle, y);

            FruitCoordinate = new Coordinate(x, y);
        }
    }
}
