using Capstone.Classes;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace CapstoneTests
{
    [TestClass]
    public class VendingMachineTestClass
    {
        [TestMethod]
        public void VendingMachineInstantiationTest()
        {
            VendingMachine testVendingMachine = new VendingMachine();
            Assert.IsNotNull(testVendingMachine);
            Assert.AreEqual(0M, testVendingMachine.TotalRevenue, "Total revenue property should initialize to zero.");
            Assert.AreEqual(0M, testVendingMachine.TransactionBalance, "Transaction balance property should initialize to zero.");
        }

        //[TestMethod] //TODO: Add test for Fetching Data into List items
        //public void VendingMachineInventoryStockTest()
        //{
        //    VendingMachine testVendingMachine = new VendingMachine();
            
        //}
    }
}
