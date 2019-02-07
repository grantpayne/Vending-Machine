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
                //derived
                return "";
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


    }




    
}
