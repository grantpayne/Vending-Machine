﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.Classes
{
    public class UserInterface
    {
        private VendingMachine vendingMachine = new VendingMachine();

        public void RunInterface()
        {
            bool done = false;

            ////while (!done)
            //{
            //    Console.WriteLine("BoBo");
            //    Console.ReadLine();
            //}

            while (!done)
            {
                done = Menu();
            }
        }
        public bool Menu()
        {
            bool done = false;
            //menu goes here
            return done;
        }


        public void Display()
        {
            //
        }

        public void Purchase()
        {
            int moneyTendered =0;
            //while false prompt for non counterfit money
            vendingMachine.AddTender(moneyTendered);
           
           string itemSelection ="";
                       
            //check transaction balance
           //check if exist 
            vendingMachine.Vend(itemSelection);

            

            //while done tendering and selecting
            vendingMachine.DispenseChange();  //display change from decimal [] 

        }
        

        public void OptionalReport()
        {

        }
        public void emptyMachine()
        {

        }

    }
}