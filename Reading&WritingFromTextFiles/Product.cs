    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Numerics;
    using System.Text;
    using System.Threading.Tasks;

    namespace ReadingWritingFromTextFiles
    {
        public class Product
    {
        private string  _name;
        private int _purchaseCost;
        private int _saleCost;

        public string Name
        {
            get{ return _name; }
            private set{
                if(value is null || value == "") throw new ArgumentException(message:"the name of product is invalid");
                _name = value;
            }
        }
        public int PurchaseCost
        {
            get{ return _purchaseCost; }
            private set{
                if(value <= 0) throw new ArgumentException(message:"the Purchase Cost of product can't be negative");
                _purchaseCost = value;
            }
        }
         public int SaleCost
        {
            get{ return _saleCost; }
            private set{
                if(value <= 0) throw new ArgumentException(message:"the Sale Cost of product can't be negative");
                _saleCost = value;
            }
        }

        public Product(string name, int purchaseCost, int saleCost)
        {
            Name = name;
            PurchaseCost = purchaseCost;
            SaleCost = saleCost;
        }
    }
}