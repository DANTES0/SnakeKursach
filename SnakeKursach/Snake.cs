using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace SnakeKursach
{
    public class Snake
    {
        public Coordinate Position { get; private set; } = new Coordinate();
        public List<Coordinate> Tail { get; private set; } = new List<Coordinate>();
        public Direction Direction { get; set; } = Direction.Right;
        public Rectangle Rec { get; private set; }
        public int Lenght { get; set; } = 1;
    
        public void DrawSnakeHead()
        {
            Rec = new Rectangle
            {
                Height = 10,
                Width = 10,
                Fill = Brushes.Red
            };
            Canvas.SetLeft(Rec, Position.X);
            Canvas.SetTop(Rec, Position.Y);
        }
        public void TailLogic()
        {
            Tail.Add(new Coordinate(Position.X, Position.Y));
            if (Lenght < Tail.Count)
            {
                var endTail = Tail.First();
                Tail.Remove(endTail);
            }
        }
        public void Move()
        {
            switch (Direction)
            {
                case Direction.Left:
                    Position.X -= 10;
                    break;
                case Direction.Right:
                    Position.X += 10;
                    break;
                case Direction.Up:
                    Position.Y -= 10;
                    break;
                case Direction.Down:
                    Position.Y += 10;
                    break;
            }
        }
    }
    public enum Direction { Left, Right, Up, Down }
}
