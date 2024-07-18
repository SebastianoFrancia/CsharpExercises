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
    /// Logica di interazione per OrderPage.xaml
    /// </summary>
    public partial class OrderPage : Page
    {
        private Order _newOrder;
        private kitchenWindows _kitchen;
        public OrderPage(kitchenWindows kitchen,Menu menu, int id)
        {
            InitializeComponent();
            lbxMenu.ItemsSource = menu.GetMenu;
            _kitchen = kitchen;
            try
            {
                _newOrder = new Order(id);
            }catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
            
        }


        private void btnAddOrder_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (lbxMenu.SelectedItem != null && 
                    lbxMenu.SelectedItem is Product)
                {
                    Product nuovoProduct = lbxMenu.SelectedItem as Product;
                    _newOrder.AddProduct(nuovoProduct);
                   
                    lbxOrder.ItemsSource = null;
                    lbxOrder.ItemsSource = _newOrder.OrderList;
                    UpdateAmmount();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private void btnConfirmOrder_Click(object sender, RoutedEventArgs e)
        {
            WriteFile writeFile = new WriteFile("Orders.csv");
            writeFile.WriteOrder(_newOrder);
            _kitchen.AddNewOrder(_newOrder);
            MainWindow mainW = ((MainWindow)Application.Current.MainWindow);
            mainW.Content = mainW.mainFrame;
        }

        private void UpdateAmmount()
        {
            string amount = _newOrder.Amount.ToString();
            lblAmmount.Content = $"Totale: €{amount}";
        }

        private void btnRimuoviOrdine_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (lbxOrder.SelectedItem != null && lbxOrder.SelectedItem is Product)
                {
                    Product nuovoProduct = lbxOrder.SelectedItem as Product;
                    _newOrder.RemoveProduct(nuovoProduct);

                    lbxOrder.ItemsSource = null;
                    lbxOrder.ItemsSource = _newOrder.OrderList;
                    UpdateAmmount();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
