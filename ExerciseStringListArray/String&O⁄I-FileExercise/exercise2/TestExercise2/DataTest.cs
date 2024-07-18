using static System.Runtime.InteropServices.JavaScript.JSType;
using Exercise2;

namespace TestExercise2
{
    [TestClass]
    public class DataTest
    {
        [TestMethod]
        public void DayWithWrongValue()
        {
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => new Exercise2.Date("42-4-2003"));
            Assert.ThrowsException<FormatException>(() => new Exercise2.Date("-2/4/2003"));
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => new Exercise2.Date("30-2-2003"));
        }

        [TestMethod]
        public void MounthWithWrongValue()
        {
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => new Exercise2.Date("2-13-2003"));
            Assert.ThrowsException<FormatException>(() => new Exercise2.Date("2/-4/2003"));
        }

        [TestMethod]
        public void YearWithWrongValue()
        {
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => new Exercise2.Date("2/4/2510"));
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => new Exercise2.Date("2/4/1803"));
            Assert.ThrowsException<FormatException>(() => new Exercise2.Date("3/4/-2003"));
        }

        [TestMethod]
        public void DateWithWrongString()
        {
            Assert.ThrowsException<IndexOutOfRangeException>(() => new Exercise2.Date(""));
        }

    }
}