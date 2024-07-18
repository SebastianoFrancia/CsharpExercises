using SwitchesClass;

namespace SwitchseTest
{
    [TestClass]
    public class SwitchseTest 
    {
        [TestMethod]
        public void Controll_SwitchesOff()
        { 
            Switches one = new Switches();            
            Assert.AreEqual("off", one._bulbsOfSwitche.Status);
        }

        [TestMethod]
        public void Controll_SwitchesOn()
        { 
            Switches one = new Switches();
            one.Status(true);
            Assert.AreEqual("on", one._bulbsOfSwitche.Status);
        }
    }
}