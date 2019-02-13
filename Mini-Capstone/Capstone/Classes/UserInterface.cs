using System;
using System.Collections.Generic;
using System.Text;
using Capstone.Classes;
using System.Drawing;
using Console = Colorful.Console;
using Colorful;

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
            //TODO: AB DONE Underline current menu title - Changed font color
            MasterPage();
            StyleSheet styleSheetMM = new StyleSheet(Color.White);
            styleSheetMM.AddStyle("MAIN MENU", (Color.LimeGreen));
            Console.WriteLine("MAIN MENU", Color.LimeGreen);
            Console.WriteLine("\n(1) Display Vending Machine Items\n(2) Make A Purchase\n(3) End Program\n");
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
                Console.WriteLineStyled("\n\nPress enter to return to the MAIN MENU...", styleSheetMM);
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
                //Console.WriteLine("Press enter to exit.");
                //Console.ReadLine();
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
                Console.WriteLineStyled("SELECTION NOT VALID! Press enter to return to the MAIN MENU.", styleSheetMM);
                Console.ReadLine();
                return StopMenu;
            }
        }//Menu
        public void Display()
        {
            MasterPage();
            Console.WriteLine("VENDING MACHINE ITEMS\n", Color.LimeGreen);
            List<VendingMachineItem> items = vendingMachine.GetInventoryData();
            List<string> itemsDisplay = new List<string>();
            foreach (VendingMachineItem item in items)
            {
                itemsDisplay.Add(item.ToString());
            }
            itemsDisplay.Sort();
            Console.WriteLine(string.Format("{0, 10} {1, 20} {2, 8:C} {3, 11}", "Product", "Item", "Price", "Available"));
            Console.WriteLine(string.Format("{0, 7} {1, 20} {2, 6:C} {3, 16}", "Code", "", "", "Inventory"));
            Console.WriteLine("-----------------------------------------------------", (Color.LimeGreen));
            foreach (string item in itemsDisplay)
            {
                Console.WriteLine(item);
            }
        }//Display
        public bool Purchase()
        {
            MasterPage();
            const bool PurchaseComplete = true;
            const bool PurchaseIncomplete = false;


            string userSelection = "";
            const string FeedMoneyOption = "1";
            const string SelectProductOption = "2";
            const string FinishTransactionOption = "3";

            // might want to consider separate method for testing valid user selection
            while (!(userSelection == FeedMoneyOption || userSelection == SelectProductOption || userSelection == FinishTransactionOption)) // Magic Constant test
            {

                Console.WriteLine("PURCHASE MENU", Color.LimeGreen);
                Console.WriteLine("\n(1) Insert Payment\n(2) Select Product\n(3) Complete Transaction\n");
                Console.WriteLine("Current Money Provided: {0:C}\n", vendingMachine.TransactionBalance, (Color.LimeGreen));
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
        }//InitiateSalesReport

        public void FeedMoney()
        {
            List<string> allowedBills = new List<string> { "1", "2", "5", "10", "20" };
            //const bool Counterfeit = false;
            //bool isFeedMoneyAccepted = Counterfeit;

            MasterPage();
            Console.WriteLine("FEED MONEY\n", Color.LimeGreen);
            Console.WriteLine("Please enter whole dollar amount (1, 2, 5, 10, 20):");
            string dollarFeedInput = Console.ReadLine();

            if (allowedBills.Contains(dollarFeedInput))
            {

                int dollarFeed = 0;
                int.TryParse(dollarFeedInput, out dollarFeed);
                vendingMachine.AddTender(dollarFeed);

            }
            else
            {
                Console.WriteLine("Valid U.S. currency ONLY\n");
                Console.ReadLine();

            }


        }//FeedMoney
        public void SelectProduct()
        {
            MasterPage();
            StyleSheet styleSheetPM = new StyleSheet(Color.White);
            styleSheetPM.AddStyle("PURCHASE MENU", (Color.LimeGreen));
            Console.WriteLine("MAKE A PURCHASE\n", Color.LimeGreen);
            Display();
            Console.WriteLine("\nEnter product code to purchase:", Color.LimeGreen);
            string productSelector = Console.ReadLine(); // TODO KH Done Fix productSelector spelling

            string transactionResult = vendingMachine.Vend(productSelector);

            if (transactionResult == "SOLD")//Magic Sold
            {
                List<VendingMachineItem> products = new List<VendingMachineItem>(vendingMachine.GetInventoryData());
                foreach (VendingMachineItem item in products)
                {
                    if (item.SlotID.ToUpper() == productSelector.ToUpper())
                    {
                        Console.WriteAscii(item.Message, FigletFont.Default, Color.LawnGreen);
                        
                    }
                }

            }
            else if (transactionResult == "") // Magic Constant test
            {
                Console.WriteLine("OOPS - Nothing was entered! Press enter to return to the PURCHASE MENU.", styleSheetPM);
            }
            else if (transactionResult == "DoesNotExist") // Magic Constant test
            {
                Console.WriteLine("Item does not exist! Please enter a valid product code! Press enter to return to the PURCHASE MENU.", styleSheetPM);
            }
            else if (transactionResult == "OutOfStock") // Magic Constant test
            {
                Console.WriteLine("OUT OF STOCK! Please make another selection. Press enter to return to the PURCHASE MENU.", styleSheetPM);
            }
            else //cant afford
            {
                Console.WriteLineStyled("INSUFFICIENT FUNDS! Please make an alternative selection. Press enter to return to the PURCHASE MENU.", styleSheetPM);
            }
            Console.ReadLine();


        }//SelectProduct
        public void FinishTransaction()
        {
            MasterPage();
            Console.WriteLine("ENJOY YOUR SNACK!", Color.LimeGreen);
            Console.WriteLine($"Your change is {vendingMachine.TransactionBalance.ToString("C")}");
            int[] change = vendingMachine.DispenseChange();  //display change from decimal [] 
            Console.WriteLine($"{change[0]} quarters, {change[1]} dimes, {change[2]} nickels", Color.LimeGreen);
            Console.ReadLine();
        }//FinishTransaction
        public void MasterPage()
        {
            Console.Clear();
            Console.WriteLine("Fulton Vending Company...");
            Console.WriteAscii("Snacking Refactored!", FigletFont.Default, Color.Plum);
            StyleSheet styleSheetMM = new StyleSheet(Color.White);
            styleSheetMM.AddStyle("MAIN MENU", (Color.LimeGreen));
            //StyleSheet styleSheetPM = new StyleSheet(Color.White);
            //styleSheetPM.AddStyle("PURCHASE MENU", (Color.LimeGreen));
        }


    }//class
}//namespace