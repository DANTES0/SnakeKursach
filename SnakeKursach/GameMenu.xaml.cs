using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace SnakeKursach
{
    /// <summary>
    /// Логика взаимодействия для GameMenu.xaml
    /// </summary>
    public partial class GameMenu : Window
    {
        public GameMenu()
        {
            InitializeComponent();
        }
        private void ExitKey_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            foreach (Window window in App.Current.Windows)
            {
                if (window is Game)
                    window.Close();
            }
            this.Close();
        }
        private void ContinueKey_Click(object sender, RoutedEventArgs e)
        {
            foreach (Window window in App.Current.Windows)
            {
                if (window is Game)
                    window.Opacity = 1;
            }
            this.Close();
        }
    }
}
