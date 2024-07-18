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
    public partial class KitchenOrderPage : Page
    {
        private Order _newOrder;
        private kitchenWindows _kitchen;
        public KitchenOrderPage(kitchenWindows kitchen, Menu menu)
        {
            InitializeComponent();
            lbxMenu.ItemsSource = menu.GetMenu;
            _kitchen = kitchen;
        }

        public KitchenOrderPage(kitchenWindows kitchen, Menu menu,int id) : this(kitchen, menu)
        {
            btnConfirmOrder.Visibility = Visibility.Visible;
            btnConfirmEdit.Visibility = Visibility.Collapsed;
            try
            {
                _newOrder = new Order(id);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public KitchenOrderPage(kitchenWindows kitchen, Menu menu, Order orderToedit) : this(kitchen,menu)
        {
            _newOrder = orderToedit;
            btnConfirmOrder.Visibility = Visibility.Collapsed;
            btnConfirmEdit.Visibility = Visibility.Visible;
            lbxOrder.ItemsSource = _newOrder.OrderList;
            UpdateAmmount();
        }


        private void btnAddOrder_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (lbxMenu.SelectedItem != null && lbxMenu.SelectedItem is Product)
                {
                    Product newProduct = lbxMenu.SelectedItem as Product;
                    _newOrder.AddProduct(newProduct);

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
            ((MainWindow)Application.Current.MainWindow).NavigateToKitchenWindows();
        }

        private void UpdateAmmount()
        {
            string amount = _newOrder.Amount.ToString();
            lblAmmount.Content = $"Totale: €{amount}";
        }

        private void btnemuveProduct_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (lbxOrder.SelectedItem != null &&
                    lbxOrder.SelectedItem is Product)
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

        private void btnConfirmEdit_Click(object sender, RoutedEventArgs e)
        {
            WriteFile writeFile = new WriteFile("Orders.csv");
            writeFile.WriteOrder(_newOrder);
            _kitchen.EditOrder(_newOrder);
            ((MainWindow)Application.Current.MainWindow).NavigateToKitchenWindows();

        }
    }
}
