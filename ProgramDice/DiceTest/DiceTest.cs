using DiceClass;
namespace TestDice
{
    [TestClass]
    public class TestDice
    {
        [TestMethod]
        public void Corectly_Dice()
        {
            Dice DiceOne = new Dice(6);
            Assert.AreEqual(6, DiceOne.NumFace);
        }

        [TestMethod]
        public void InCorectly_Dice()
        {
            Assert.ThrowsException<System.ArgumentOutOfRangeException>(() => { Dice dadoUno = new Dice(3);}) ;
        }
        
    }
}