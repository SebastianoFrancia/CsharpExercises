using System;

namespace Shipments
{
    public partial class ShipmentsManagment
    {
        private List<Package> _packages = new List<Package>();
        
        private List<Package> Packages
        {
            get { return _packages; }
        }

        public void AddPackage(Package package)
        {
            foreach (Package p in Packages)
            {
                if (p == package) throw new ArgumentException("the package is already exist!");
            }
            Packages.Add(package);
        }

        public string? SearchPackageFromId(int id)
        {
            for (int i = 0; i < Packages.Count; i++)
            {
                if (Packages[i].Id == id) return Packages[i].ToString();
            }
            return null;
        }

        public List<Package> PackagesFormDispatchDateAndAddress(DateTime startDispatchDate, DateTime endDispatchDate, string city)
        {
            if (startDispatchDate > endDispatchDate) throw new ArgumentException("the end DispatchDate is greater from start");
            List<Package> packages= new List<Package>();
            
            for (int i = 0; i < Packages.Count; i++)
            {
                if (Packages[i].Address.Contains(city) && packages[i].DispatchDate > startDispatchDate && packages[i].DispatchDate < endDispatchDate ) 
                    packages.Add(Packages[i]);
            }    
            return packages;
        }

        public double CalculateImport(List<CashOnDeliveryPackage> cashOnDeliveryPackage)
        {
            double totalAmmount = 0;
            for(int i = 0; i < cashOnDeliveryPackage.Count; i++)
            {
                totalAmmount += cashOnDeliveryPackage[i].Amount;
            }
            return totalAmmount;
        }
    }
}