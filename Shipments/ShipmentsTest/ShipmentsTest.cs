using Newtonsoft.Json.Serialization;
using Shipments;

namespace ShipmentsTest;

[TestClass]
public class UnitTest1
{
    [TestMethod]
    public void TestPackageWithInvalidParameter()
    {
        Package package;
        Assert.ThrowsException<ArgumentOutOfRangeException>(() => new Package(0000, "cesena,via.Plauto,32", new DateTime(2014, 8, 5, 12, 30, 00), new DateTime(2014, 8, 9, 14, 30, 00), -12.3));
        Assert.ThrowsException<ArgumentOutOfRangeException>(() => new Package(0000, "cesena,via.Plauto,32", new DateTime(2014, 8, 5, 12, 30, 00), new DateTime(2014, 4, 9, 14, 30, 00), 12.3));
        Assert.ThrowsException<ArgumentOutOfRangeException>(() => new Package(0000, "cesena,via.Plauto,32", new DateTime(2014, 8, 10, 12, 30, 00), new DateTime(2014, 8, 9, 14, 30, 00), 12.3));
        Assert.ThrowsException<ArgumentNullException>(() => new Package(0000, "", new DateTime(2014, 8, 5, 12, 30, 00), new DateTime(2014, 8, 9, 14, 30, 00), 12.3));
        Assert.ThrowsException<ArgumentOutOfRangeException>(() => new Package(-11, "cesena,via.Plauto,32", new DateTime(2014, 8, 5, 12, 30, 00), new DateTime(2014, 8, 9, 14, 30, 00), 12.3));
    }

    [TestMethod]
    public void TestShipmentsManagmentInvalidAddPackagec()
    {
        ShipmentsManagment packages= new ShipmentsManagment();
        Package p = new Package(0000, "cesena,via Plauto,32", new DateTime(2014, 8, 5, 12, 30, 00), new DateTime(2014, 8, 9, 14, 30, 00), 12.3);
        Package p1 = new Package(0011, "cesena,via Plauto,15", new DateTime(2014, 8, 5, 12, 30, 00), new DateTime(2014, 8, 9, 14, 30, 00), 12.3);
        Package p2 = new Package(0002, "cesena,via Plauto,30", new DateTime(2014, 8, 5, 12, 30, 00), new DateTime(2014, 8, 9, 14, 30, 00), 12.3);
        packages.AddPackage(p);
        packages.AddPackage(p1);
        packages.AddPackage(p2);
        Assert.ThrowsException<ArgumentException>(() => packages.AddPackage(p));
        Assert.ThrowsException<ArgumentException>(() => packages.AddPackage(p1));
        Assert.ThrowsException<ArgumentException>(() => packages.AddPackage(p2));

    }

    [TestMethod]
    public void TestShipmentsManagmentEqualSearchPackageFromId()
    {
        ShipmentsManagment packages= new ShipmentsManagment();
        Package p = new Package(0000, "cesena,via Plauto,32", new DateTime(2014, 8, 5, 12, 30, 00), new DateTime(2014, 8, 9, 14, 30, 00), 12.3);
        Package p0 = new Package(00021, "cesena,via Cervese,15", new DateTime(2014, 8, 5, 12, 30, 00), new DateTime(2014, 8, 9, 14, 30, 00), 1.3);
        packages.AddPackage(p);
        Assert.AreEqual(p.ToString(), packages.SearchPackageFromId(0000));
        packages.AddPackage(p0);
        Assert.AreEqual(null, packages.SearchPackageFromId(0002));
        Assert.AreEqual(p0.ToString(), packages.SearchPackageFromId(0021));

    }

    [TestMethod]
    public void TestShipmentsManagmentEqualPackagesFormDispatchDateAndAddress()
    {
        ShipmentsManagment packages= new ShipmentsManagment();
        List<Package> pl = new List<Package>();
        Package p = new Package(0000, "cesena,via Plauto,32", new DateTime(2014, 8, 5, 12, 30, 00), new DateTime(2014, 8, 9, 14, 30, 00), 12.3);
        Package p0 = new Package(00021, "cesena,via Cervese,15", new DateTime(2014, 5, 5, 12, 30, 00), new DateTime(2014, 8, 9, 14, 30, 00), 1.3);
        Package p1 = new Package(00031, "forli,via Cervese,15", new DateTime(2014, 5, 5, 12, 30, 00), new DateTime(2014, 8, 9, 14, 30, 00), 1.3);
        packages.AddPackage(p);
        packages.AddPackage(p0);
        packages.AddPackage(p1);
        pl.Add(p0);
        Assert.ThrowsException<ArgumentException>(() => packages.PackagesFormDispatchDateAndAddress(new DateTime(2014,8,1,10,10,00),new DateTime(2014,6,1,10,10,00), "forli"));
        //Assert.AreEqual(pl[0], packages.PackagesFormDispatchDateAndAddress(new DateTime(2014,3,1,10,10,00),new DateTime(2014,6,1,10,10,00), "cesena")[0]);
        

    }
    
}