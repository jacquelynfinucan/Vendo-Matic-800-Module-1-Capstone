using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone
{
    public class Candy : VendingMachineItems
    {
        public Candy(string itemName, decimal price, int inventory, string itemType)
            : base(itemName, price, inventory, itemType)
        {
        }
    }
}
