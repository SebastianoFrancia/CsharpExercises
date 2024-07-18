using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PiadinaStend
{
    public class Menu
    {
        private List<Product> _menu;

        public List<Product> GetMenu
        {
            get { return _menu; }
        }

        public Menu()
        {
            _menu = new List<Product>();
        }

        public void AddProduct(Product newProduct)
        {
            foreach (Product prodotto in _menu)
            {
                if (newProduct.Equals(prodotto)) throw new Exception("the new products is already exist");
            }
            _menu.Add(newProduct);
        }

        public override string ToString()
        {
            string output = "";
            foreach (Product prodotto in _menu)
            {
                output += $"{prodotto.Nome}, {prodotto.Price}€ \n({prodotto.Descrizzione}) \n\n";
            }
            return output;
        }
    }
}
