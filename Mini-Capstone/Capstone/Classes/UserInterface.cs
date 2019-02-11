using System;
using System.Collections.Generic;
using System.Text;
using Capstone.Classes;

namespace Capstone.Classes
{
    public class UserInterface
    {
        public VendingMachine vendingMachine = new VendingMachine();
        public void RunInterface()
        {
            bool done = false;
            while (!done)
            {
                done = Menu();
            }
        }//RunInterface
        public bool Menu()
        {
            Console.Clear();
            //TODO: Underline current menu title
            Console.WriteLine("Fulton Vending Company\n\n---Food Refactored---\n\n\nMAIN MENU\n\nPlease make a selection:\n\n(1) Display Vending Machine Items\n(2) Purchase\n(3) End\n");
            string menuInput = Console.ReadLine();

            //TODO: KH Done Magic Constant for menu
            const bool StopMenu = false;
            const bool ContinueMenu = true;
            //const bool Complete = true;
            const bool Incomplete = false;
            bool isPurchaseTransactionComplete = Incomplete;
            const string DisplaySelction = "1";
            const string PurchaseSelection = "2";
            const string SecretReport = "9";
            const string EndProgram = "3";

            if (menuInput == DisplaySelction)
            {
                Display();
                Console.WriteLine("\nPress enter to return to the MAIN MENU...");
                Console.ReadLine();
                return StopMenu;
            }
            else if (menuInput == PurchaseSelection)
            {
                while (isPurchaseTransactionComplete == Incomplete)
                {
                    isPurchaseTransactionComplete = Purchase();
                }
                return StopMenu;
            }
            else if (menuInput == EndProgram)
            {
                Console.WriteLine("Press enter to exit.");
                Console.ReadLine();
                return ContinueMenu;
            }
            else if (menuInput == SecretReport)
            {
                Console.WriteLine("Generating sales report...");
                InitiateSalesReport();
                Console.ReadLine();
                Console.Clear();
                return StopMenu;
            }
            else
            {
                Console.WriteLine("Invalid selection - press enter to return to the main menu.");
                Console.ReadLine();
                return StopMenu;
            }
        }//Menu
        public void Display()
        {
            Console.Clear();
            List<VendingMachineItem> items = vendingMachine.GetInventoryData();
            List<string> itemsDisplay = new List<string>();
            foreach (VendingMachineItem item in items)
            {
                itemsDisplay.Add(item.ToString());
            }
            itemsDisplay.Sort();
            Console.WriteLine(string.Format("{0, 5} {1, 25} {2, 8:C} {3, 9}\n", "Code", "Product", "Price", "Quantity"));
            foreach (string item in itemsDisplay)
            {
                Console.WriteLine(item);
            }
        }//Display
        public bool Purchase()
        {
            const bool PurchaseComplete = true;
            const bool PurchaseIncomplete = false;


            string userSelection = "";
            const string FeedMoneyOption = "1";
            const string SelectProductOption = "2";
            const string FinishTransactionOption = "3";

            // might want to consider separate method for testing valid user selection
            while (!(userSelection == FeedMoneyOption || userSelection == SelectProductOption || userSelection == FinishTransactionOption)) // Magic Constant test
            {
                Console.Clear();
                Console.WriteLine("PURCHASE MENU\n\nPlease make a selection:\n\n(1) Feed Money\n(2) Select Product\n(3) Finish Transaction\n");
                Console.WriteLine("Current Money Provided: {0:C}\n", vendingMachine.TransactionBalance);
                userSelection = Console.ReadLine();
            }
            if (userSelection == FeedMoneyOption)
            {
                FeedMoney();
            }

            else if (userSelection == SelectProductOption)
            {
                SelectProduct();
            }
            else
            {
                FinishTransaction();
                return PurchaseComplete;
            }//finished
            return PurchaseIncomplete;
        } //Purchase
        public void InitiateSalesReport()
        {
            vendingMachine.WriteSalesReportData(vendingMachine);
        }//OptionalReport
        

        public void FeedMoney()
        {
            List<string> allowedBills = new List<string> { "1", "2", "5", "10", "20" };
            //const bool Counterfeit = false;
            //bool isFeedMoneyAccepted = Counterfeit;

            Console.Clear();
            Console.WriteLine("Please enter dollar bill to deposit (U.S. currency only)");
            string dollarFeedInput = Console.ReadLine();

            if ( allowedBills.Contains(dollarFeedInput))
            {
               
                int dollarFeed = 0;
                int.TryParse(dollarFeedInput, out dollarFeed);
                vendingMachine.AddTender(dollarFeed);

            }
            else
            {
                Console.WriteLine("Whole dollar amounts ONLY: 1, 2, 5, 10, 20\n");
                Console.ReadLine();

            }


        }//FeedMoney
        public void SelectProduct()
        {
            Display();

            Console.WriteLine("\nPlease select product code: ");
            string productSelector = Console.ReadLine(); // TODO KH Done Fix productSelector spelling

            string transactionResult = vendingMachine.Vend(productSelector);

            if (transactionResult == "SOLD")//Magic Sold
            {
                List<VendingMachineItem> products = new List<VendingMachineItem>(vendingMachine.GetInventoryData());
                foreach (VendingMachineItem item in products)
                {
                    if (item.SlotID.ToUpper() == productSelector.ToUpper())
                    {
                        Console.WriteLine(item.Message);
                    }
                }

            }
            else if (transactionResult == "DoesNotExist") // Magic Constant test
            {
                Console.WriteLine("Item does not exist! Select a valid product code!");
            }
            else if (transactionResult == "OutOfStock") // Magic Constant test
            {
                Console.WriteLine("OUT OF STOCK! Please make another selection.");
            }
            else //cant afford
            {
                Console.WriteLine("Please enter more money or make another selection.");
            }
            Console.ReadLine();


        }//SelectProduct
        public void FinishTransaction()
        {

            Console.Clear();
            Console.WriteLine($"Your change is {vendingMachine.TransactionBalance.ToString("C")}");
            int[] change = vendingMachine.DispenseChange();  //display change from decimal [] 
            Console.WriteLine($"{change[0]} quarters, {change[1]} dimes, {change[2]} nickels");
            Console.ReadLine();
        }//FinishTransaction

    }//class
}//namespace