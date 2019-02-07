using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.Classes
{
    public class VendingMachine
    {
        //constructor takes in filepath and creats lis of content

        private List<VendingMachineItem> items = new List<VendingMachineItem>(); //do not change
        private string filePath = @"C:\VendingMachine"; //do not change  - write all files/reports here...

        public decimal TransactionBalance { get; private set; }
        public decimal TotalRevenue { get; private set; }

        public bool AddTender(int moneyTendered)
        {
            //checked for dollars bills
            // if good update log
            //update TransactionBalance
            //return true;

            return false;
            //false if coutnerfit
        }

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
