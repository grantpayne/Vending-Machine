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

            //TODO: refactor stockItemArray indexing variables to specific names

            foreach (string[] stockItemArray in stockList)
            {
                items.Add(new VendingMachineItem(stockItemArray[0], stockItemArray[1], decimal.Parse(stockItemArray[2]))); //TODO: Handle Parse exception
            }

        }


        public bool AddTender(int moneyTendered)
        {
            //checked for dollars bills {1, 2, 5, 10, 20}
            List<int> allowedBills = new List<int> { 1, 2, 5, 10, 20 };
            bool isAcceptedUSBill = allowedBills.Contains(moneyTendered);

            if (isAcceptedUSBill)
            {
                TransactionBalance += moneyTendered;
                io.WriteLog(filePath, "FEED MONEY:", moneyTendered, TransactionBalance);
                return isAcceptedUSBill;
            }
            else
            {
                return isAcceptedUSBill;
            }
            // if good update log
            //update TransactionBalance
            //return true;
            //false if coutnerfit
        }

        public string Vend(string itemSelection)
        {
            

             string result = "";

            foreach (VendingMachineItem item in items)
            {
                if (item.SlotID == itemSelection)
                {
                    if (item.InventoryCount > 0)
                    {


                        if (TransactionBalance >= item.Price)
                        {



                            decimal initialBalance = TransactionBalance;

                            item.InventoryCount--;
                            TransactionBalance -= item.Price;
                            TotalRevenue += item.Price;

                            
                            // pre-balance for IO call = TransactionBalance + item.Price;
                            

                           io.WriteLog(filePath, (item.ItemName + " " + item.SlotID), (TransactionBalance + item.Price), TransactionBalance);

                            result = "SOLD";

                            break;





                        }
                        else
                        {
                            result = "cantAfford";
                            break;
                        }


                    }
                    else
                    {
                        result = "OutOfStock";
                        break;
                    }
                                                          
                }
                else
                {
                    result = "DoesNotExist";
                }
            }



            return result;
        }


        public int[] DispenseChange()
        {
            //Assuming all prices are divisible by .05 cause no pennies;
            //figure out quarters[0],dimes[1],nickels[2]
            decimal tempBalance = TransactionBalance;
            int[] change = new int[3];
            change[0] = (int)Math.Floor(TransactionBalance / 0.25M);
            TransactionBalance -= change[0]* 0.25M;
            change[1] = (int)(Math.Floor(TransactionBalance / 0.10M));
            TransactionBalance -= change[1] * 0.10M;
            change[2] = (int)(Math.Floor(TransactionBalance  / 0.05M));
            TransactionBalance = 0;
            io.WriteLog(filePath, "GIVE CHANGE:", tempBalance, TransactionBalance);

            return change;

        }

        public List<VendingMachineItem> GetInventoryData()
        {

            return items;
        }

    }

}
