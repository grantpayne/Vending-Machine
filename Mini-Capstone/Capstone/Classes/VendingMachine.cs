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
        private string fileName = @"vendingmachine.csv";

        public decimal TransactionBalance { get; private set; }
        public decimal TotalRevenue { get; private set; }

        IO io = new IO();
        public VendingMachine()
        {
            TransactionBalance = 0M;
            TotalRevenue = 0M;

            List<string[]> stockList = new List<string[]>();
            stockList = io.FetchData(filePath, fileName);


            foreach (string[] stockItemArray in stockList)
            {
                items.Add(new VendingMachineItem(stockItemArray[0], stockItemArray[1], decimal.Parse(stockItemArray[2]))); //TODO: Handle Parse exception
            }

        }


        public bool AddTender(int moneyTendered)
        {
            //checked for dollars bills
            // if good update log
            //update TransactionBalance
            //return true;
            io.WriteLog(filePath, "FEED MONEY:", moneyTendered, TransactionBalance);
            return false;
            //false if coutnerfit
        }

        public bool Vend(string itemSelection)
        {
            bool canAfford = false;
            decimal initialBalance = TransactionBalance;
            //checking balance and storing pre-balance for IO call
            //dispense item if >0
            //adjust inventory VendingMachineItem.Count -1
            return canAfford;
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
