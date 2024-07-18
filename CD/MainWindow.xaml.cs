using System;
using System.Collections.Generic;
using System.Diagnostics;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CD
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Disc _cd;
        public MainWindow()
        {
            InitializeComponent();
            ReadFile("cd1.csv");
            lblTitle.Content = _cd.Title;
            lblArtist.Content = _cd.Artist;
            lblDuration_Min_Sec.Content =$"{_cd.DurationSeconds()} second";
            lbxTraks.ItemsSource = _cd.Tracks;
        }

        public void ReadFile(string filePath)
        {
            try
            {

                using (StreamReader sr = new StreamReader(filePath))
                {
                    string firstLine = sr.ReadLine();
                    string[] titleElements = firstLine.Split(';');

                    _cd = new Disc(titleElements[0], titleElements[1]);

                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        string[] trakElement = line.Split(',');
                        string[] timeElements = trakElement[1].Split(':');

                        if (int.TryParse(timeElements[0], out int minutes) && int.TryParse(timeElements[1], out int seconds))
                        {
                            _cd.AddTrack(new Track(trakElement[0], minutes, seconds));
                        }

                    }
                }
            }catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
