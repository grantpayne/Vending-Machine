using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.Classes
{

    public class VendingMachineItem
    {
        
        public int InventoryCount { get; set; }
        public decimal Price { get; }
        public string SlotID { get; }
        public string ItemName { get; }
        public string Message
        {
            get
            {
                string message = "";

                switch (SlotID[0])
                {
                    case 'A':
                        message = "Crunch Crunch, Yum!";
                        break;
                    case 'B':
                        message = "Munch Munch, Yum!";
                        break;
                    case 'C':
                        message = "Glug Glug, Yum!";
                        break;
                    case 'D':
                        message = "Chew Chew, Yum!";
                        break;
                    default:
                        message = "Salad-dodger! This food is bad for you! Eat a salad.";
                        break;
                }

                return message;
            }
        }

        //constructor
        public VendingMachineItem(string slotID, string itemName, decimal price)
        {
            SlotID = slotID;
            ItemName = itemName;
            Price = price;
            InventoryCount = 5;
        }

        public override string ToString()
        {
            string result = (string.Format("{0, 5} {1, 25} {2, 8:C}", SlotID, ItemName, Price));
            if (InventoryCount == 0)
            {
                result += "SOLD OUT".PadLeft(10);
            }
            else
            {
                result += InventoryCount.ToString().PadLeft(10);
            }
            return result;

        }


    }





}
