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
        }
        public bool Menu()
        {
            bool isPurchaseTransactionComplete = false;
            Console.Clear();
            //TODO: Underline current menu title
            Console.WriteLine("Welcome to Fulton Vending!\n\nMAIN MENU\n\nPlease make a selection:\n\n(1) Display Vending Machine Items\n(2) Purchase\n(3) End\n");
            string menuInput = Console.ReadLine();
            if (menuInput == "1")
            {

                Display();
                Console.WriteLine("\nPress enter to return to the MAIN MENU...");
                Console.ReadLine();
                return false;
            }
            else if (menuInput == "2")
            {
                while (!isPurchaseTransactionComplete)
                {
                    isPurchaseTransactionComplete = Purchase();

                }
                return false;

            }
            else if (menuInput == "3")
            {
                Console.WriteLine("Press enter to exit.");
                Console.ReadLine();
                return true;
            }
            else if (menuInput == "9")
            {
                Console.WriteLine("Generating summary report...");
                OptionalReport();
                Console.ReadLine();
                return false;
            }
            else
            {
                Console.WriteLine("Invalid selection - press enter to return to the main menu.");
                Console.ReadLine();
                return false;
            }

        }


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

            //Console.WriteLine("\nPress enter to return to the MAIN MENU...");
            //Console.ReadLine();
            //5. When the customer selects ​(1) Display Vending Machine Items​ they have presented a list of all items in the vending machine, the price, and its quantity remaining. a. Each vending machine product has a slot identifier and a purchase price. b. Each slot in the vending machine has enough room for 5 of that product. c. Every product is initially stocked to the maximum amount. d. A product which has run out should indicate it is SOLD OUT. 
        }

        public bool Purchase()
        {
            bool isPurchaseTransactionComplete = false;

            string userSelection = "";
            while (!(userSelection == "1" || userSelection == "2" || userSelection == "3"))
            {
                Console.Clear();
                Console.WriteLine("PURCHASE MENU\n\nPlease make a selection:\n\n(1) Feed Money\n(2) Select Product\n(3) Finish Transaction\n");
                Console.WriteLine("Current Money Provided: {0:C}\n", vendingMachine.TransactionBalance);
                userSelection = Console.ReadLine();

            }

            if (userSelection == "1")
            {

                bool isAccepted = false;
                Console.Clear();
                Console.WriteLine("Please enter dollar bill to deposit (U.S. currency only)");
                int dollarFeed = 0;

                int.TryParse(Console.ReadLine(), out dollarFeed);
                isAccepted = vendingMachine.AddTender(dollarFeed);

                if (!isAccepted)
                {
                    Console.WriteLine("Valid U.S. currency ONLY\n");
                    Console.ReadLine();
                    isAccepted = true;
                }
            }
            else if (userSelection == "2")
            {
                Display();
                Console.WriteLine("\nPlease select product code: ");
                string prodcutSelector = Console.ReadLine();

                string transactionResult = vendingMachine.Vend(prodcutSelector);
                if (transactionResult == "SOLD")

                {


                    List<VendingMachineItem> products = new List<VendingMachineItem>(vendingMachine.GetInventoryData());
                    foreach (VendingMachineItem item in products)
                    {
                        if (item.SlotID == prodcutSelector)
                        {
                            Console.WriteLine(item.Message);
                        }
                    }
                    Console.ReadLine();
                    userSelection = "";


                }
                else
                {
                    if (transactionResult == "DoesNotExist")
                    {
                        Console.WriteLine("Item does not exist! Select a valid product code!");

                    }
                    else if (transactionResult == "OutOfStock")
                    {
                        Console.WriteLine("OUT OF STOCK! Please make another selection.");
                    }
                    else
                    {
                        Console.WriteLine("Please enter more money or make another selection.");
                    }


                    Console.ReadLine();
                    userSelection = "";

                }


            }
            else
            {
                Console.Clear();
                Console.WriteLine($"Your change is {vendingMachine.TransactionBalance.ToString("C")}");
                int [] change = vendingMachine.DispenseChange();  //display change from decimal [] 
                Console.WriteLine($"{change[0]} quarters, {change[1]} dimes, {change[2]} nickels");
                Console.ReadLine();
                isPurchaseTransactionComplete = true;

            }




            return isPurchaseTransactionComplete;
        }


        public void OptionalReport()
        {

        }
        public void emptyMachine()
        {

        }

    }
}