namespace Shipments
{
    public class Package
    {
        private int _id;
        private string _address;
        private DateTime _dispatchDate;
        private DateTime _deliveryDate;
        private double _weightKg;

        public int Id 
        { 
            get { return _id; }
            private set 
            { 
                if (value < 0) throw new ArgumentOutOfRangeException("id is negative");
                _id = value;
            } 
        }

        public string Address
        {
            get { return _address; }
            private set 
            {
                if (value == string.Empty) throw new ArgumentNullException("addres is empty string");
                _address = value;
            }
        }

        public DateTime DispatchDate
        {
            get { return _dispatchDate; }
        }

        public DateTime DeliveryDate
        {
            get { return _deliveryDate; }
            private set
            {
                if (value.Year < _dispatchDate.Year || value.Month < _dispatchDate.Month || value.Day < _dispatchDate.Day || 
                    value.Hour < _dispatchDate.Hour || value.Minute < _dispatchDate.Minute) throw new ArgumentOutOfRangeException("the date of delivery cannot be less recent than the date of delivery");
                _deliveryDate = value;
            }
        }

        public double WeightKg
        {
            get { return _weightKg; }
            private set
            {
                if (value <= 0 ) throw new ArgumentOutOfRangeException("the weight can't be negative");
                _weightKg = value;
            }
        }

        public Package(int id, string address, DateTime dispatchDate, DateTime deliveryDate, double weight)
        {
            Id = id;
            Address = address;
            _dispatchDate = dispatchDate;
            DeliveryDate = deliveryDate;
            WeightKg = weight;
        }

        public override bool Equals(object? obj)
        {
            if (obj is Package)
            {
                Package? p = obj as Package;
                if (p != null)
                {
                    if (p.Id == this.Id || p.Address == this.Address)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public override string ToString()
        {
            return $"{_id},{Address},{DispatchDate},{DeliveryDate},{WeightKg}";
        }
    }
}