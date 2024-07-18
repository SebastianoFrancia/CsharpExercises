using AppointmentClass;
using TimeClass;

namespace Verifica_2023_10_20_Test
{
    [TestClass]
    public class Test
    {
        [TestMethod]
        public void Time_WithInvalidHous()
        {
            Time one;
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => one = new Time(32, 52, 5));
        }

        [TestMethod]
        public void Time_WithInvalidMinutes()
        {
            Time one;
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => one = new Time(6, 60, 5));
        }

        [TestMethod]
        public void Time_WithInvalidSeconds()
        {
            Time one;
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => one = new Time(2, 52, 61));
        }

        [TestMethod]
        public void ControllCheckIfMorning()
        {
            Time one = new Time(8, 42, 25);
            Assert.AreEqual(true, one.CheckIfMorning());
        }

        [TestMethod]
        public void Appointment_WithInvalidTime()
        {
            Appointment one;
            Assert.ThrowsException<ArgumentException>(() => one = new Appointment(14, 24, 32, 5, 26, 0));
        }

        [TestMethod]
        public void Controll_CalculateTimeSeconds()
        {
            Appointment one = new Appointment(6, 40, 6, 7, 40, 6);
            Assert.AreEqual(3600, one.CalculateTimeSeconds());
        }

        [TestMethod]
        public void Controll_VerifyMoreLonger()
        {
            Appointment appointmentFirst = new Appointment(6, 5, 0, 18, 7, 0);
            Appointment appointmentSecond = new Appointment(8, 5, 0, 10, 57, 0);
            Assert.AreEqual(true, appointmentFirst.VerifyMoreLonger(appointmentSecond));
        }

        [TestMethod]
        public void Controll_VerifyMoreShorter()
        {
            Appointment appointmentFirst = new Appointment(6, 5, 0, 18, 7, 0);
            Appointment appointmentSecond = new Appointment(8, 5, 0, 10, 57, 0);
            Assert.AreEqual(true, appointmentFirst.VerifyOvernyng(appointmentSecond));
        }
    }
}