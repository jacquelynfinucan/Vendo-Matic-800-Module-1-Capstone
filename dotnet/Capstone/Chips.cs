using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone
{
    public class Chips : VendingMachineItems
    {
        public Chips(string itemName, decimal price, int inventory, string itemType)
            : base(itemName, price, inventory, itemType)
        {
        }
    }
}
