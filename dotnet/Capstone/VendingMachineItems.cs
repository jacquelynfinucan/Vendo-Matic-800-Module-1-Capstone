﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone
{
    public abstract class VendingMachineItems
    {
        public string ItemName { get; set; }
        public decimal Price { get; set; }
        public int Inventory { get; set; }

        public VendingMachineItems(string itemName, decimal price, int inventory)
        {
            this.ItemName = itemName;
            this.Price = price;
            this.Inventory = inventory;
        }
        

        

    }
}