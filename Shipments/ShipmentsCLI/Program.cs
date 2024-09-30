using Shipments;

namespace Spadizioni
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            ShipmentsManagment packages = new ShipmentsManagment();
            bool continued = false;;

            do
            {
                Console.Clear();
                Console.WriteLine("── New Packge: ────────────────────────────────────────────────────────────────");
                try
                {
                    Package package;

                    Console.WriteLine("enter parcel id");
                    int id = int.Parse(Console.ReadLine());
                    Console.WriteLine("enter destination address");
                    string address = Console.ReadLine();
                    Console.WriteLine("enter date of shipment (yyyy-mm-dd/hh:mm)");
                    string[] stringsDispatchDate = Console.ReadLine().Split('/');
                    string[] onlyData = stringsDispatchDate[0].Split('-');
                    string[] onlyTime = stringsDispatchDate[1].Split(':');
                    int year = int.Parse(onlyData[0]);
                    int month = int.Parse(onlyData[1]);
                    int day = int.Parse(onlyData[2]);
                    int hour = int.Parse(onlyTime[0]);
                    int minute = int.Parse(onlyTime[1]);
                    DateTime dispatchDate = new DateTime(year, month, day, hour, minute, 00);

                    Console.WriteLine("enter date of delivery (yyyy-mm-dd/hh:mm)");
                    string[] stringsDeliveryDate = Console.ReadLine().Split('/');
                    onlyData = stringsDeliveryDate[0].Split('-');
                    onlyTime = stringsDeliveryDate[1].Split(':');
                    year = int.Parse(onlyData[0]);
                    month = int.Parse(onlyData[1]);
                    day = int.Parse(onlyData[2]);
                    hour = int.Parse(onlyTime[0]);
                    minute = int.Parse(onlyTime[1]);
                    DateTime deliveryDate = new DateTime(year, month, day, hour, minute, 00);

                    Console.WriteLine("enter the weight of the parcel");
                    int weight = int.Parse(Console.ReadLine());

                    Console.WriteLine("insert [C] if the parcel is cash on delivery or [N] if not:");
                    string inputCOD = Console.ReadLine();
                    if (inputCOD == "C")
                    {
                        Console.WriteLine("enter the ammount of cash on delivery");
                        int ammount = int.Parse(Console.ReadLine());
                        package = new CashOnDeliveryPackage(id, address, dispatchDate, deliveryDate, weight, ammount);
                    }
                    else if (inputCOD == "N")
                    {
                        package = new Package(id, address, dispatchDate, deliveryDate, weight);
                    }

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
                Console.WriteLine("─────────────────────────────────────────────────────────────────────────────");
                Console.WriteLine("enter [Y] to enter a new package or [N] to continue");
                string inputContinued = Console.ReadLine();
                if (inputContinued == "Y")
                {
                    continued = true;
                }
                else if (inputContinued == "N")
                {
                    continued = false;
                }
            } while (continued);
            Console.Clear();
            Console.WriteLine("─────────────────────────────────────────────────────────────────────────────");
            Console.WriteLine("enter [1] to search for the information of a parcel given its Id");
            Console.WriteLine("enter [2] to generate the list of parcels that have a shipping date in a certain range and a certain destination city");
            string input = Console.ReadLine();
            Console.Clear();
            Console.WriteLine("─────────────────────────────────────────────────────────────────────────────");
            if (input == "1")
            {
                Console.WriteLine("enter the id of the package to search for");
                int id = int.Parse(Console.ReadLine());
                string? package = packages.SearchPackageFromId(id);
                if (package != null) Console.WriteLine(package);
                else Console.WriteLine("id not found!");
                
            }else if (input == "2")
            {
                
                Console.WriteLine("enter date of shipment range start (yyyy-mm-dd/hh:mm)");
                string[] stringsshipmentDateStart = Console.ReadLine().Split('/');
                string[] onlyData = stringsshipmentDateStart[0].Split('-');
                string[] onlyTime = stringsshipmentDateStart[1].Split(':');
                int year = int.Parse(onlyData[0]);
                int month = int.Parse(onlyData[1]);
                int day = int.Parse(onlyData[2]);
                int hour = int.Parse(onlyTime[0]);
                int minute = int.Parse(onlyTime[1]);
                DateTime shipmentRangeStart = new DateTime(year, month, day, hour, minute, 00);

                Console.WriteLine("enter date of shipment range end (yyyy-mm-dd/hh:mm)");
                string[] stringsshipmentDateEnd = Console.ReadLine().Split('/');
                onlyData = stringsshipmentDateEnd[0].Split('-');
                onlyTime = stringsshipmentDateEnd[1].Split(':');
                year = int.Parse(onlyData[0]);
                month = int.Parse(onlyData[1]);
                day = int.Parse(onlyData[2]);
                hour = int.Parse(onlyTime[0]);
                minute = int.Parse(onlyTime[1]);
                DateTime shipmentRangeEnd = new DateTime(year, month, day, hour, minute, 00);

                Console.WriteLine("enter city name");
                string cityName = Console.ReadLine();
                List<Package> pl = packages.PackagesFormDispatchDateAndAddress(shipmentRangeStart, shipmentRangeEnd, cityName);
                Console.WriteLine("──List of packages found: ──────────────────────────────────────────────────────────────");
                foreach (Package p in pl)
                {
                    Console.WriteLine(p);
                }
            } 
        }
    }
}