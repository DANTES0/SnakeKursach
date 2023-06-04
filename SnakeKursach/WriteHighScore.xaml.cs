using System;
using System.Collections.Generic;
using System.IO;
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
using System.Xml;

namespace SnakeKursach
{
    /// <summary>
    /// Логика взаимодействия для WriteHighScore.xaml
    /// </summary>
    public partial class WriteHighScore : Window
    {
        public int CurScore;
        public string s = "";
        public int v;
        public WriteHighScore(int curScore)
        {
            v = curScore;
            InitializeComponent();
            
        }
        public void WriteXMl()
        {
            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.Load(@"F:\Новая папка\C#\SnakeKursach\SnakeKursach\HighScore.xml");
            XmlElement xRoot = xmlDocument.DocumentElement;
            XmlElement userElem = xmlDocument.CreateElement("user");
            XmlAttribute nameAttr = xmlDocument.CreateAttribute("name");
            XmlElement score = xmlDocument.CreateElement("score");
            XmlText nameText = xmlDocument.CreateTextNode(s);
            XmlText scoreText = xmlDocument.CreateTextNode(v.ToString());
            nameAttr.AppendChild(nameText);
            score.AppendChild(scoreText);
            userElem.Attributes.Append(nameAttr);
            userElem.AppendChild(score);
            xRoot.AppendChild(userElem);
            xmlDocument.Save(@"F:\Новая папка\C#\SnakeKursach\SnakeKursach\HighScore.xml");
        }
        List<SnakeHighScore> users = new List<SnakeHighScore>();
        public void sorted()
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
            users.Reverse();
        }
        public void WriteTempXMl()
        {
            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.Load(@"F:\Новая папка\C#\SnakeKursach\SnakeKursach\HighScore.xml");
            foreach (SnakeHighScore u in users)
            {

                XmlElement xRoot = xmlDocument.DocumentElement;
                XmlElement userElem = xmlDocument.CreateElement("user");
                XmlAttribute nameAttr = xmlDocument.CreateAttribute("name");
                XmlElement score = xmlDocument.CreateElement("score");
                XmlText nameText = xmlDocument.CreateTextNode(u.PlayerName);
                XmlText scoreText = xmlDocument.CreateTextNode(u.Score.ToString());
                nameAttr.AppendChild(nameText);
                score.AppendChild(scoreText);
                userElem.Attributes.Append(nameAttr);
                userElem.AppendChild(score);
                xRoot.AppendChild(userElem);
            }
            xmlDocument.Save(@"F:\Новая папка\C#\SnakeKursach\SnakeKursach\HighScore.xml");
        }
        private void btn_Click(object sender, RoutedEventArgs e)
        {
            s = textBox.Text;
            WriteXMl();
            sorted();
            File.Copy(@"F:\Новая папка\C#\SnakeKursach\SnakeKursach\Source\Score\HighScore.xml", @"F:\Новая папка\C#\SnakeKursach\SnakeKursach\HighScore.xml", true);
            WriteTempXMl();
            this.Close();
        }
       

        
    }
}
