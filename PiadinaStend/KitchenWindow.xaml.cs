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

namespace PiadinaStend
{
    public partial class kitchenWindows : Window
    {
        private List<Order> _orders;
        private Menu _menu;
        public kitchenWindows(Menu menu)
        {
            InitializeComponent();
            _menu = menu;
            _orders = new List<Order>();
        }

        public void AddNewOrder(Order newOrder)
        {
            if (newOrder != null) 
            {
                _orders.Add(newOrder);
                UpdateLbxOrder();
            }else
            {
                MessageBox.Show("the new order is null");
            }
        }

        public void EditOrder(Order order)
        {
            if (order != null)
            {
                _orders.Remove(order);
                _orders.Add(order);
                UpdateLbxOrder();
            }
            else
            {
                MessageBox.Show("the new order is null");
            }
        }

        private int GenerateId()
        {
            DateTime? lastOrderTime;
            int? lastOrderId;
            DateTime now = DateTime.Now;
            try
            {
                ReadFile readFile = new ReadFile("Orders.csv");
                lastOrderTime = readFile.LastDateTimeOrder();
                lastOrderId = readFile.LastOrderId();
                if (lastOrderId != null && lastOrderId != null)
                {
                    DateTime lastOrderTimeValue = (DateTime)lastOrderTime;
                    if (lastOrderTimeValue > now) throw new ArgumentException("the last order time cant be in the future");
                    if (lastOrderTimeValue.Year == now.Year && lastOrderTimeValue.Month == now.Month && lastOrderTimeValue.Day == now.Day)
                    {
                        return (int)lastOrderId + 1;
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return 1;

        }

        private void btnToPrepare_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (lbxOrders.SelectedItem != null)
                {
                    Order order = lbxOrders.SelectedItem as Order;
                    if (order != null)
                    {
                        int? index = FindIndexOfOrderX(order);
                        if (index == null) throw new ArgumentException("can't find the order");
                        _orders[(int)index].ToPrepare();

                        lbxOrders.SelectedItem = order;
                        UpdateLbxOrder();
                    }

                }
            }catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private int? FindIndexOfOrderX(Order orderX)
        {
            int i = -1;
            foreach(Order order in _orders)
            {
                i++;
                if (order == orderX) return i;
            }
            return null;
        }


        private void UpdateLbxOrder()
        {
            lbxOrders.ItemsSource = null;
            lbxOrders.ItemsSource = _orders;
        }
        private void btnAddProduct_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                kitchenWindows kitchenW = this;
                KitchenOrderPage kitchenOrderPage = new KitchenOrderPage(kitchenW, _menu, GenerateId());
                this.Content = kitchenOrderPage;
                UpdateLbxOrder();

            }catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnEditOrder_Click(object sender, RoutedEventArgs e)
        {          
            try
            {
                object selectedItem = lbxOrders.SelectedItem;
                if (selectedItem is Order)
                {
                    Order? orderToEdit = selectedItem as Order;
                    if (orderToEdit != null)
                    {
                        kitchenWindows kitchenW = this;
                        KitchenOrderPage kitchenOrderPage = new KitchenOrderPage(kitchenW, _menu, orderToEdit);
                        this.Content = kitchenOrderPage;
                        UpdateLbxOrder();
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnTerminated_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (lbxOrders.SelectedItem != null)
                {
                    Order order = lbxOrders.SelectedItem as Order;
                    if (order != null)
                    {
                        int? index = FindIndexOfOrderX(order);
                        if (index == null) throw new ArgumentException("can't find the order");
                        _orders[(int)index].TerminateOrder();

                        lbxOrders.SelectedItem = order;
                        UpdateLbxOrder();
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnEditAmount_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                double editedAmount = int.Parse(tbxEditAmount.Text);
                if (lbxOrders.SelectedItem != null)
                {
                    Order order = lbxOrders.SelectedItem as Order;
                    if(order.Amount < editedAmount) throw new ArgumentException("the value of the total price mustn't exceed the sum of the cost of the products");
                    order.Amount = editedAmount;
                    lbxOrders.SelectedItem = order;
                    UpdateLbxOrder();
                }

            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
