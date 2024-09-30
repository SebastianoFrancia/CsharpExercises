using System.Net.Http.Headers;

namespace Shipments
{
    public class CashOnDeliveryPackage : Package
    {
        private double _amount;

        public double Amount 
        { 
            get { return _amount; } 
            private set
            {
                if (value <= 0) throw new ArgumentException(message:"the ammount is <= 0");
                _amount = value;
            }
        }

        public CashOnDeliveryPackage(int id, string address, DateTime dispatchDate, DateTime deliveryDate, double weight, double amount) : base(id, address, dispatchDate, deliveryDate, weight)
        {
            Amount = amount;
        }
    }
}