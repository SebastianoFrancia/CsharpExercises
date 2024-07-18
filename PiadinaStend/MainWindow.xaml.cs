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

namespace PiadinaStend
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Menu menu;
        private kitchenWindows kitchen;
        public MainWindow()
        {
            InitializeComponent();

            try
            {
                menu = new Menu();
                ReadFile readFile = new ReadFile("menu.csv");
                menu = readFile.InizializzaMenu();
                
            }catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            lblMenu.Content = menu.ToString();

            kitchen = new kitchenWindows(menu);
            kitchen.Show();
        }

        private int GenerateId()
        {
            DateTime? lastOrderTime;
            int? lastOrderId;
            DateTime now = DateTime.Now;


            ReadFile readFile = new ReadFile("Orders.csv");
            lastOrderTime = readFile.LastDateTimeOrder();
            lastOrderId = readFile.LastOrderId();
            if (lastOrderTime != null && lastOrderId != null)
            {
                DateTime lastOrderTimeValue = (DateTime)lastOrderTime;
                if (lastOrderTimeValue > now) throw new ArgumentException("the last order time cant be in the future");
                if (lastOrderTimeValue.Year == now.Year && lastOrderTimeValue.Month == now.Month && lastOrderTimeValue.Day == now.Day)
                {
                    return (int)lastOrderId + 1;
                }
            }
            return 1; 
            
        }

        public void NavigateToKitchenWindows()
        {
            kitchen.Content = kitchen.kitchenFrame;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                OrderPage ordinePag = new OrderPage(kitchen, menu, GenerateId());
                this.Content = ordinePag;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
