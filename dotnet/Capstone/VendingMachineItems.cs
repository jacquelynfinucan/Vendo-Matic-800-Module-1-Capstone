using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone
{
    public class VendingMachineItems
    {
        public string ItemName { get; set; }
        public decimal Price { get; set; }
        public int Inventory { get; set; }
        public string ItemType { get; set; }

        public VendingMachineItems(string itemName, decimal price, int inventory, string itemType)
        {
            this.ItemName = itemName;
            this.Price = price;
            this.Inventory = inventory;
            this.ItemType = itemType;
        }
        
        



    }
}
