using System.Collections.Generic;
using System.Windows;
using System.Xml;

namespace SnakeKursach
{
    /// <summary>
    /// Логика взаимодействия для HighScore.xaml
    /// </summary>
    public partial class HighScore : Window
    {
        List<SnakeHighScore> users = new List<SnakeHighScore>();
        public HighScore()
        {
            InitializeComponent();
            readXML();
        }
        private void BackKey_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        public void readXML()
        {
            XmlDocument xml = new XmlDocument();
            xml.Load(@"F:\Новая папка\C#\SnakeKursach\SnakeKursach\HighScore.xml");
            XmlElement element = xml.DocumentElement;
            foreach (XmlNode xnode in element)
            {
                if (xnode.Attributes.Count > 0)
                {
                    XmlNode attr = xnode.Attributes.GetNamedItem("name");
                    if (attr != null)
                        txt1.Text += attr.Value;
                }
                foreach(XmlNode childnode in xnode.ChildNodes)
                {
                    if(childnode.Name == "score")
                        txt1.Text += (" " + childnode.InnerText + "\n");
                }
            }
        }
       
    }
}
