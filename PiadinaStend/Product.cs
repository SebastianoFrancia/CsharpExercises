using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PiadinaStend
{
    public class Product
    {
        private int _id;
        private string _name;
        private string _description;
        private double _price;

        public int Id
        {
            get { return _id; }
            private set
            {
                if (value <= 0) throw new ArgumentOutOfRangeException("the id can't be negative");
                _id = value;
            }
        }

        public string Nome
        {
            get { return _name; }
            private set
            {
                if (value == string.Empty) throw new ArgumentException("the name is empty");
                //if (!(value.All(char.IsAsciiLetter))) throw new ArgumentException("il nome puo contenere solo lettere");
                _name = value;
            }
        }

        public string Descrizzione
        {
            get { return _description; }
            private set
            {
                if (value == string.Empty) throw new ArgumentException("the description is empty");
                //if (!(value.All(char.IsAsciiLetterOrDigit ))) throw new ArgumentException("l' elemento della descrizione puo contenere solo lettere o numeri");
                _description = value;
            }
        }

        public double Price
        {
            get { return _price; }
            private set
            {

                if (value <= 0) throw new ArgumentOutOfRangeException("the price is zero or less");
                _price = value;
            }

        }

        public Product(int id, string nome, string descrizione, double prezzo)
        {
            Id = id;
            Nome = nome;
            Descrizzione = descrizione;
            Price = prezzo;
        }

        public override bool Equals(object? obj)
        {
            if (obj != null && obj is Product)
            {
                Product Product = obj as Product;
                if (_id == Product.Id && _description == Product.Descrizzione
                    && _name == Product.Nome && _price == Product._price) return true;
            }
            return false;
        }
        public override string ToString()
        {
            return $"{_id},{_name},{_description},{_price}";
        }
    }
}
