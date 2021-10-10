using Microsoft.VisualStudio.TestTools.UnitTesting;
using Capstone;

namespace CapstoneTests
{
    [TestClass]
    public class GetFunMessageTests
    {
        [TestMethod]
        public void GetFunMessageTest()
        {
            VendingMachine vendingMachine = new VendingMachine();
            Assert.AreEqual("CRUNCH CRUNCH, YUM!", vendingMachine.GetFunMessage("Chip"));
            Assert.AreEqual("GLUG GLUG, YUM!", vendingMachine.GetFunMessage("Drink"));
            Assert.AreEqual("MUNCH MUNCH, YUM!", vendingMachine.GetFunMessage("Candy"));
            Assert.AreEqual("CHEW CHEW, YUM!", vendingMachine.GetFunMessage("Gum"));
            Assert.AreEqual(null, vendingMachine.GetFunMessage("Chocolate"));
        }
    }
}
