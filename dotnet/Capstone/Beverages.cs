using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone
{
    public class Beverages : VendingMachineItems
    {
        public Beverages(string itemName, decimal price, int inventory, string itemType) 
            : base(itemName, price, inventory, itemType)
        {
        }
    }
}
