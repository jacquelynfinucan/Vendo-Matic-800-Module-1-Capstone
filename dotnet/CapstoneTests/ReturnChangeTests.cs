using Microsoft.VisualStudio.TestTools.UnitTesting;
using Capstone;

namespace CapstoneTests
{
    [TestClass]
    public class ReturnChangeTests
    {
        [TestMethod]
        public void ReturnChangeTest()
        {
            VendingMachine vendingMachine = new VendingMachine();
            vendingMachine.currentBalance = 10.00M;
            decimal result = vendingMachine.ReturnChange();
            Assert.AreEqual(0, result);
        }
    }
}
