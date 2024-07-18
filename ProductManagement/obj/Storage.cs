using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Text;
using System.IO;


namespace Matrixs
{
    public class Storage
    {
        private Product[] _products;

        public Storage(Product[] products)
        {
            _products = products;
        }

        public Storage()
        {
            _products = new Product[0];
        }

        public void AddProduct(string name, int purchaseCost, int saleCost)
        {
            Product p = new Product(name,purchaseCost,saleCost);
            Product[] tempProducts = new Product[_products.Length+1];
            for(int i=0; i<=_products.Length; i++)
            {
                tempProducts[i]=_products[i];
            }
            tempProducts[_products.Length+1] = p;
            _products = tempProducts;
        }

        public void SaveDataOnFile()
        {
            string[] lines = { "First line", "Second line", "Third line" };

            string docPath =Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

            using (StreamWriter outputFile = new StreamWriter(Path.Combine(docPath, "Prodotti.txt")))
            {
                outputFile.WriteLine($"{_products.Length}");
                for(int i=1; i<= _products.Length; i++)
                {
                    outputFile.WriteLine($"{_products[i].Name}|{_products[i].PurchaseCost}|{_products[i].SaleCost}");
                }
                    
            }   

            
            
            
        }
    }
}