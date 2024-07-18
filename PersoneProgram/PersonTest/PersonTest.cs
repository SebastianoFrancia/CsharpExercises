using NotPerson;
namespace PesonTest
{
    [TestClass]
    public class PersonTest
    {
        [TestMethod]
        public void CalculateAge_WithInvalidDay()
        {
            Person uno = new Person("gino", "rossi", 23, 2, 1980);
            Assert.ThrowsException<System.ArgumentException>(()=>uno.CalculateAge(-2, 2, 2023));
        }
        [TestMethod]
        public void CalculateAge_WithInvalidMonth()
        {
            Person uno = new Person("gino", "rossi", 23, 2, 1980);
            Assert.ThrowsException<System.ArgumentException>(()=>uno.CalculateAge(9, 0, 2023));
        }
        [TestMethod]
        public void CalculateAge_WithInvalidYear()
        {
            Person uno = new Person("gino", "rossi", 23, 2, 1980);
            Assert.ThrowsException<System.ArgumentException>(()=>uno.CalculateAge(9, 9, 1969));
        }
        
        [TestMethod]
        public void CalculateAge_CorectDate()
        {
            Person persona1 = new Person("Francesco", "Foschi", 02, 11, 2007);
            Assert.AreEqual(15, persona1.CalculateAge(8, 10, 2023));
        }

        [TestMethod]
        public void Corectuality_OverAge()
        {
            Person persona1 = new Person("Sebastino", "Francia", 02, 06, 2007);
            Assert.AreEqual(false, persona1.VerifyOverAge);
        }

        [TestMethod]
        public void Corectuality_PreSchool()
        {
            Person persona1 = new Person("Francesco", "Foschi", 02, 11, 2007);
            Assert.AreEqual(false, persona1.VerifyPreSchoolAge);
        }
    }
}