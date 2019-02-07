using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.Classes
{
    public class VendingMachine
    {
        private List<VendingMachineItem> items = new List<VendingMachineItem>(); //do not change
        private string filePath = @"C:\VendingMachine"; //do not change  - write all files/reports here...

        public decimal TransactionBalance { get; private set; }
        public decimal TotalRevenue { get; private set; }


        public void Vend(string itemSelection)
        {
            
            //dispense item if >0
            //adjust inventory VendingMachineItem.Count -1

        }

        public int []  DispenseChange()
        {   //use vendingMachine.TransactionBalance and break into coins.
            //figure out quarters,nickels,dimes
            int [] change = new int [3]; //quarter, nickel, dimes
                                         //greedy algo?
            TransactionBalance = 0;
            return change;
        }
        

    }

}
