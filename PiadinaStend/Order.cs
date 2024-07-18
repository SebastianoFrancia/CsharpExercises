using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PiadinaStend
{
    public enum Status
    {
        waiting,
        toPrepare,
        terminated
    }
    public class Order
    {
        private int _id;
        private Status _orderStatus;
        private List<Product> _productList;
        private DateTime _dateTime;
        private double _amount;

        public int Id
        {
            get { return _id; }
            private set 
            {
                if( value<0 ) throw new ArgumentOutOfRangeException("the id is invalid");
                _id = value; 
            }
        }
        public Status OrderStatus
        {
            get { return _orderStatus; }
        }
        public List<Product> OrderList
        {
            get { return _productList; }
        }
        public DateTime DateTime
        {
            get { return _dateTime; }
        }

        public double Amount
        {
            get { return _amount; }
            set
            {
                if (value <= 0) throw new ArgumentOutOfRangeException("the ammount is invalid");
                _amount = value;
            }
        }

        public Order(int id)
        {
            Id = id;
            _productList = new List<Product> ();
            _dateTime = DateTime.Now;
            _amount = 0;
            _orderStatus = Status.waiting;
        }


        public void AddProduct(Product newProduct)
        {
            if (_orderStatus == Status.waiting)
            {
                _productList.Add(newProduct);
                _amount += newProduct.Price;
            }
            else throw new Exception("the Order is already inviated");
        }

        public void TerminateOrder()
        {
            _orderStatus = Status.terminated;
        }

        public void ToPrepare()
        {
            _orderStatus = Status.toPrepare;
        }

        public void RemoveProduct(Product remuveProduct)
        {
            if( _orderStatus == Status.waiting )
            {
                _productList.Remove(remuveProduct);
                _amount -= remuveProduct.Price;
            }
            else throw new Exception("the Order is already inviated");
        }

        public bool Equals(object? obj)
        {
            if (obj is Order)
            {
                Order Order = obj as Order;
                if (Order.Id == _id) return true;
            }
            return false;
        }

        public string OrderListToString()
        {
            string prodotti = "";
            for(int i=0; i<_productList.Count-1;i++)
            {
                prodotti += $"{_productList[i].Id},";
            }
            prodotti += $"{_productList[_productList.Count-1].Id}";
            return prodotti;
        }
        public override string ToString()
        {
            return $"{_id} - {_dateTime.ToString("dd/MM/yy H:mm:ss")} - {_amount} - {OrderStatus} \n" + OrderListToString() +"\n\n";
        }
        public string ToPrint()
        {
            return $"product:{_id};{_dateTime.ToString("dd/MM/yyyy H:mm:ss")};{_amount};" + OrderListToString() + ";" + OrderStatus;
        }
    }
}
