using RestaurantSpaces;
namespace RestaurantTestSpaces
{
    [TestClass]
    public class RestaurantTest
    {
        [TestMethod]
        public void SetDailyTakings_WithInvalidArgument()
        {
            Restaurant r = new Restaurant();
            
            Assert.ThrowsException<System.ArgumentOutOfRangeException>(() => r.SetDailyTakings(168, -1));
            Assert.ThrowsException<System.ArgumentOutOfRangeException>(() => r.SetDailyTakings(-1, 650));
            
        }

        [TestMethod]
        public void Verificated_CalculateAverageTakings()
        {
            Restaurant r = new Restaurant();

            for(int i = 0; i < 366;i++)
            {
                r.SetDailyTakings(i, 2*i);
            }

            Assert.AreEqual(365.0, r.CalculateAverageTakings());
            

        }

        [TestMethod]
        public void Verificated_CalcualteDayMinimumTakings()
        {
            Restaurant r = new Restaurant();

            for(int i = 0; i < 366;i += 2)
            {
                r.SetDailyTakings(i, 2*i);
            }

            Assert.AreEqual(0, r.CalcualteDayMinimumTakings());
        }

        [TestMethod]
        public void Verificated_CalcualteDayMaximumTakings()
        {
            Restaurant r = new Restaurant();

            for(int i = 0; i < 366;i += 2)
            {
                r.SetDailyTakings(i, 2*i);
            }

            Assert.AreEqual(364, r.CalcualteDayMaximumTakings());
        }

        [TestMethod]
        public void verificated_calculateOpeningDaysTakingsBelowValue()
        {
            Restaurant r = new Restaurant();

            for(int i = 0; i < 366;i++)
            {
                r.SetDailyTakings(i, 2*i);
            }

            Assert.AreEqual(1, r.calculateOpeningDaysTakingsBelowValue(2));
        }

        [TestMethod]
        public void verificated_calculateOpeningDaysTakingsgreaterValue()
        {
            Restaurant r = new Restaurant();

            for(int i = 0; i < 366;i += 2)
            {
                r.SetDailyTakings(i, 2*i);
            }

            Assert.AreEqual(182, r.calculateOpeningDaysTakingsgreaterValue(3));
        }

        [TestMethod]
        public void verificated_calculateOpenDaye()
        {
            Restaurant r = new Restaurant();

            for(int i = 0; i < 366;i += 2)
            {
                r.SetDailyTakings(i, 2*i);
            }

            Assert.AreEqual(182, r.calculateOpenDay());
        }

        [TestMethod]
        public void verificated_calculateCloseDay()
        {
            Restaurant r = new Restaurant();

            for(int i = 1; i < 366;i += 2)
            {
                r.SetDailyTakings(i, 2*i);
                r.setCloseDay(i-1);
            }

            Assert.AreEqual(183, r.calculateCloseDay());
        }
    }
}