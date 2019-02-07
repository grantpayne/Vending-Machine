using Capstone.Classes;
using Microsoft.VisualStudio.TestTools.UnitTesting;



namespace CapstoneTests
{
    [TestClass]
    public class VendingMachineItemTestClass
    {

        [TestMethod]
        public void VendingMachineItemInstantiationTest()
        {
            VendingMachineItem vendingMachineItemTest = new VendingMachineItem("A1", "Potato Crisps", 1.00M );
            Assert.IsNotNull(vendingMachineItemTest);
            Assert.AreEqual("A1", vendingMachineItemTest.SlotID);
            Assert.AreEqual("Potato Crisps", vendingMachineItemTest.ItemName);
            Assert.AreEqual(1.00M, vendingMachineItemTest.Price);
            Assert.AreEqual(5, vendingMachineItemTest.InventoryCount);
        }

        [TestMethod]
        public void VendingMachineItemMessagePropertyTest()
        {
            VendingMachineItem vendingMachineItemTestA = new VendingMachineItem("A1", "Potato Crisps", 1.00M);
            Assert.AreEqual("Crunch Crunch, Yum!", vendingMachineItemTestA.Message);
            VendingMachineItem vendingMachineItemTestB = new VendingMachineItem("B1", "Moonpie", 1.80M);
            Assert.AreEqual("Munch Munch, Yum!", vendingMachineItemTestB.Message);
            VendingMachineItem vendingMachineItemTestC = new VendingMachineItem("C1", "Cola", 1.25M);
            Assert.AreEqual("Glug Glug, Yum!", vendingMachineItemTestC.Message);
            VendingMachineItem vendingMachineItemTestD = new VendingMachineItem("D1", "U-Chews", 0.85M);
            Assert.AreEqual("Chew Chew, Yum!", vendingMachineItemTestD.Message);
        }


    }
}
