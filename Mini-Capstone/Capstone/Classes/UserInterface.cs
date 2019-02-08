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
            Console.WriteLine("Welcome to Fulton Vending!\n\nMAIN MENU\nPlease make a selection:\n\n(1) Display Vending Machine Items\n(2) Purchase\n(3) End\n");
            string menuInput = Console.ReadLine();
            if (menuInput == "1")
            {

                Display();
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

            //menu goes here
            //2.The main menu should display when the software is run presenting the following options:

            //(1) Display Vending Machine Items(2) Purchase(3) End

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

            Console.WriteLine(string.Format("{0, 5} {1, 25} {2, 8:C} {3, 9}\n", " ", "Product", "Price", "Quantity"));

            foreach (string item in itemsDisplay)
            {

                Console.WriteLine(item);
            }

            Console.WriteLine("\nPress enter to return to the MAIN MENU...");
            Console.ReadLine();
            //5. When the customer selects ​(1) Display Vending Machine Items​ they have presented a list of all items in the vending machine, the price, and its quantity remaining. a. Each vending machine product has a slot identifier and a purchase price. b. Each slot in the vending machine has enough room for 5 of that product. c. Every product is initially stocked to the maximum amount. d. A product which has run out should indicate it is SOLD OUT. 
        }

        public bool Purchase()
        {
            //            7.When the customer selects ​(2) Purchase​ they are guided through the purchasing process menu:

            //            (1) Feed Money(2) Select Product(3) Finish Transaction Current Money Provided: $2.00


            //Customers remain in the purchase menu until they select 3 and are returned to the main menu(below).
            bool isPurchaseTransactionComplete = false;

            string userSelection = "";
            while (!(userSelection == "1" || userSelection == "2" || userSelection == "3"))
            {
                Console.WriteLine("\nPURCHASE MENU\n\nPlease make a selection:\n(1) Feed Money\n(2) Select Product\n(3) Finish Transaction\n");
                Console.WriteLine("Current Money Provided: {0:C}\n", vendingMachine.TransactionBalance);
                Console.WriteLine(vendingMachine.TransactionBalance);
                userSelection = Console.ReadLine();

            }

            if (userSelection == "1")
            {

                bool isAccepted = false;
                Console.WriteLine("Please enter dollar bill to deposit (U.S. currency only)");
                //TODO: add error handling for parse
                while (!isAccepted)
                {
                    int dollarFeed = int.Parse(Console.ReadLine());
                    isAccepted = vendingMachine.AddTender(dollarFeed);
                    if (!isAccepted)
                    {
                        Console.WriteLine("Valid U.S. currency ONLY\n");
                    }
                }
            }
            else if (userSelection == "2")
            {

            }
            else
            {
                isPurchaseTransactionComplete = true;
            }

            int moneyTendered = 0;
            //while false prompt for non counterfit money
            vendingMachine.AddTender(moneyTendered);

            string itemSelection = "";

            //check transaction balance
            //check if exist 
            vendingMachine.Vend(itemSelection);



            //while done tendering and selecting
            vendingMachine.DispenseChange();  //display change from decimal [] 

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