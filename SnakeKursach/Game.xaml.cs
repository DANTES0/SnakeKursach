using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using System.Windows.Shapes;
using System.Windows.Threading;
using System.Xml;

namespace SnakeKursach
{
    /// <summary>
    /// Логика взаимодействия для Game.xaml
    /// </summary>
    /// 
    public partial class Game : Window
    {
        Snake _snake = new Snake();
        Fruit _fruit = new Fruit();
        GreenFruit _Gfruit = new GreenFruit();
        YellowFruit _Yfruit = new YellowFruit();
        GiantFruit _Giantfruit = new GiantFruit();
        DispatcherTimer _time = new DispatcherTimer();
        private int _previousDirection = 0;
        public int CurScore = 0;
        public int speed = 100;
        
        public Game()
        {
            
            InitializeComponent();
            _time.Tick += Time_Tick;

        }
        private void Time_Tick(object sender, EventArgs e)
        {

            SetSnakeInCanvas();
            _snake.Move();

            _snake.TailLogic();

            if (((_snake.Position.X == _fruit.FruitCoordinate.X)||(_snake.Position.X == _fruit.FruitCoordinate.X+10)||(_snake.Position.X == _fruit.FruitCoordinate.X - 2)) &&
                ((_snake.Position.Y == _fruit.FruitCoordinate.Y)||(_snake.Position.Y == _fruit.FruitCoordinate.Y+10)|| (_snake.Position.Y == _fruit.FruitCoordinate.Y - 2)) ||
                ((_snake.Position.X == _Gfruit.FruitCoordinate.X) || (_snake.Position.X == _Gfruit.FruitCoordinate.X + 10) || (_snake.Position.X == _Gfruit.FruitCoordinate.X - 2)) &&
                ((_snake.Position.Y == _Gfruit.FruitCoordinate.Y) || (_snake.Position.Y == _Gfruit.FruitCoordinate.Y + 10) || (_snake.Position.Y == _Gfruit.FruitCoordinate.Y - 2)) ||
                ((_snake.Position.X == _Yfruit.FruitCoordinate.X) || (_snake.Position.X == _Yfruit.FruitCoordinate.X + 10) || (_snake.Position.X == _Yfruit.FruitCoordinate.X - 2)) &&
                ((_snake.Position.Y == _Yfruit.FruitCoordinate.Y) || (_snake.Position.Y == _Yfruit.FruitCoordinate.Y + 10) || (_snake.Position.Y == _Yfruit.FruitCoordinate.Y - 2)))
            {
                CurScore += 1;
                txtScore.Text = CurScore.ToString();
                _snake.Lenght++;
                myCanvas.Children.RemoveAt(0);
                _fruit = new Fruit();
                _Gfruit = new GreenFruit();
                _Yfruit = new YellowFruit();
                _Giantfruit = new GiantFruit();
                SetFruitInCanvas();
            }
            else
                    if (((_snake.Position.X == _Giantfruit.FruitCoordinate.X) || (_snake.Position.X == _Giantfruit.FruitCoordinate.X + 10) || (_snake.Position.X == _Giantfruit.FruitCoordinate.X - 2)) &&
                ((_snake.Position.Y == _Giantfruit.FruitCoordinate.Y) || (_snake.Position.Y == _Giantfruit.FruitCoordinate.Y + 10) || (_snake.Position.Y == _Giantfruit.FruitCoordinate.Y - 2)))
            {
                speed -= 5;
                _time.Interval = new TimeSpan(0, 0, 0, 0, speed);
                CurScore += 5;
                txtScore.Text = CurScore.ToString();
                _snake.Lenght++;
                myCanvas.Children.RemoveAt(0);
                _fruit = new Fruit();
                _Gfruit = new GreenFruit();
                _Yfruit = new YellowFruit();
                _Giantfruit = new GiantFruit();
                SetFruitInCanvas();
            }

                var lengthToRemove = 0;
            for (int i = 0; i < myCanvas.Children.Count; i++)
            {
                if (myCanvas.Children[i] is Rectangle)
                    lengthToRemove++;
            }
            lengthToRemove -= _snake.Tail.Count;
            myCanvas.Children.RemoveRange(1, lengthToRemove);

            if (GameOver())
            {
                GoToList();
                foreach (Window window in App.Current.Windows)
                {
                    if (!(window is WriteHighScore))
                    {   
                        MessageBox.Show($@"Ты проиграл! Твои очки: {CurScore}", "Игра окончена", MessageBoxButton.OK, MessageBoxImage.Hand);
                        _time.Start();
                    }
                }

                
                _snake.Lenght = 1;
                _snake.Tail.Clear();
                _snake.Position.X = _snake.Position.Y = 0;
                _snake.Tail.Add(_snake.Position);
                _snake.Direction = Direction.Right;
                CurScore = 0;
                speed = 100;
                _time.Interval = new TimeSpan(0, 0, 0, 0, speed);
            }
        }
        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
            {
                _time.Stop();
                this.Opacity = 0.4;
                GameMenu gameMenu = new GameMenu();
                gameMenu.ShowDialog();
                foreach(Window window in App.Current.Windows)
                {
                    if (!((window is GameMenu)||(window is MainWindow))||(window is HighScore))
                    {
                        _time.Start();
                    }
                }
            }
            switch (e.Key)
            {
                case Key.Up:
                    if (_previousDirection != (int)Direction.Down)
                    _snake.Direction = Direction.Up;
                    break;
                case Key.Left:
                    if (_previousDirection != (int)Direction.Right)
                    _snake.Direction = Direction.Left;
                    break;
                case Key.Down:
                    if(_previousDirection != (int)Direction.Up)
                    _snake.Direction = Direction.Down;
                    break;
                case Key.Right:
                    if (_previousDirection != (int)Direction.Left)
                    _snake.Direction = Direction.Right;
                    break;
            }
            _previousDirection = (int)_snake.Direction;
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            _time.Interval = new TimeSpan(0, 0, 0, 0, speed);
            _time.Start();
            SetSnakeInCanvas();
            SetFruitInCanvas();
        }
        private void SetFruitInCanvas()
        {
            var rd = new Random();
            var choose = rd.Next(0, 13);
            if (choose == 0 || choose == 1 || choose == 2 || choose == 3)
                myCanvas.Children.Insert(0, _fruit.Circle);
            if (choose == 4 || choose == 5 || choose == 6 || choose == 7)
                myCanvas.Children.Insert(0, _Gfruit.Circle);
            if (choose == 8 || choose == 9 || choose == 10 || choose == 11)
                myCanvas.Children.Insert(0, _Yfruit.Circle);
            if (choose == 12)
                myCanvas.Children.Insert(0, _Giantfruit.Circle);
        }
        private void SetSnakeInCanvas()
        {
            _snake.DrawSnakeHead();
            myCanvas.Children.Add(_snake.Rec);
        }
        private bool GameOver()
        {

            if (_snake.Position.X > 610 || _snake.Position.Y > 405 || _snake.Position.X < 0 || _snake.Position.Y < 0)
            {
               
                return true;
            }

            return _snake.Tail.Where(c => c.X == _snake.Position.X && c.Y == _snake.Position.Y).ToList().Count > 1;
        }

        //Хороший блок ******************************************************************
        List<SnakeHighScore> users = new List<SnakeHighScore>();
        public void GoToList()
        {
            XmlDocument xml = new XmlDocument();
            xml.Load(@"F:\Новая папка\C#\SnakeKursach\SnakeKursach\HighScore.xml");
            XmlElement element = xml.DocumentElement;
            foreach (XmlNode xnode in element)
            {
                SnakeHighScore user = new SnakeHighScore();
                XmlNode attr = xnode.Attributes.GetNamedItem("name");
                if (attr != null)
                    user.PlayerName = attr.Value;

                foreach (XmlNode childnode in xnode.ChildNodes)
                {
                    if (childnode.Name == "score")
                        user.Score = Int32.Parse(childnode.InnerText);
                }
                users.Add(user);
            }
            users.Sort(delegate (SnakeHighScore us1, SnakeHighScore us2)
            {
                return us1.Score.CompareTo(us2.Score);
            });
            foreach (SnakeHighScore u in users)
            {
                if (CurScore > u.Score)
                {
                    DeleteElements();
                    WriteHighScore wr = new WriteHighScore(CurScore);
                    _time.Stop();
                    wr.ShowDialog();
                    break;
                }
            }
            if (users.Count == 5)
            {
                users.RemoveAt(users.Count - 1);
            }
        }
        public void DeleteElements()
        {
            XmlDocument xml = new XmlDocument();
            xml.Load(@"F:\Новая папка\C#\SnakeKursach\SnakeKursach\HighScore.xml");
            XmlElement element = xml.DocumentElement;
            XmlElement? xRoot = xml.DocumentElement;
            XmlNode? lastNode = xRoot?.LastChild;
            if (lastNode is not null) xRoot?.RemoveChild(lastNode);
            xml.Save(@"F:\Новая папка\C#\SnakeKursach\SnakeKursach\HighScore.xml");
        }

        private void PauseBtn_Click(object sender, RoutedEventArgs e)
        {
            _time.Stop();
            this.Opacity = 0.4;
            GameMenu gameMenu = new GameMenu();
            gameMenu.ShowDialog();
            foreach (Window window in App.Current.Windows)
            {
                if (!((window is GameMenu) || (window is MainWindow)) || (window is HighScore))
                {
                    _time.Start();
                }
            }
        }
        //***********************************************************************
    }
}
