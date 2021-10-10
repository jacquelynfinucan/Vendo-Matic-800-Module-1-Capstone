using Microsoft.VisualStudio.TestTools.UnitTesting;
using Capstone;

namespace CapstoneTests
{
    [TestClass]
    public class UserSlotSelectionTests
    {
        [TestMethod]
        public void UserSlotSelectionTest()
        {
            VendingMachine vendingMachine = new VendingMachine();
            vendingMachine.ReadInputFile();
            vendingMachine.CreateDictionaryOfItems();
            vendingMachine.currentBalance = 10.00M;
            vendingMachine.dictonaryOfVendingItems["A1"].Inventory = 5;
            decimal result = vendingMachine.UserSlotSelection("A1");
            Assert.AreEqual(6.95M, result);
        }
    }
}
