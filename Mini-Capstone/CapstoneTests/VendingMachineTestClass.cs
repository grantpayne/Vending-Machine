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

        [TestMethod]
        public void VendingMachineAddTenderTest()
        {
            VendingMachine testVendingMachine = new VendingMachine();
            Assert.IsTrue(testVendingMachine.AddTender(1));
            Assert.IsFalse(testVendingMachine.AddTender(3));
            Assert.AreEqual(1M, testVendingMachine.TransactionBalance);
            testVendingMachine.AddTender(2);
            Assert.AreEqual(3M, testVendingMachine.TransactionBalance);
            testVendingMachine.AddTender(5);
            Assert.AreEqual(8M, testVendingMachine.TransactionBalance);
            testVendingMachine.AddTender(10);
            Assert.AreEqual(18M, testVendingMachine.TransactionBalance);
            testVendingMachine.AddTender(20);
            Assert.AreEqual(38M, testVendingMachine.TransactionBalance);
            testVendingMachine.AddTender(3);
            Assert.AreEqual(38M, testVendingMachine.TransactionBalance);


        }


        //[TestMethod] //TODO: Add test for Fetching Data into List items
        //public void VendingMachineInventoryStockTest()
        //{
        //    VendingMachine testVendingMachine = new VendingMachine();
            
        //}
    }
}
