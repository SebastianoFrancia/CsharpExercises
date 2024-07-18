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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PrimoProgettoStringhe
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            StringManagement stringManagement;

            try
            {
                string string1 = txbString.Text;
                char char1 = char.Parse(txbChar.Text);
                string subString = txbSubString.Text;
                stringManagement = new StringManagement(string1, char1, subString );

                txtOutput.Text = $"String lenght: {stringManagement.Lenght}\n" +
                                 $"String number of vocals: {stringManagement.VoclasNumber}\n" +
                                 $"String number of upprcase letter: {stringManagement.UppercaseLetersNumber}" +
                                 $"String number of char: {stringManagement.CharNumber}\n" +
                                 $"comparison string is substring: {stringManagement.TherSubstring}";
            }
            catch (Exception ex)
            {
                txtError.Text = ex.Message;
            }

            



        }
    }
}
