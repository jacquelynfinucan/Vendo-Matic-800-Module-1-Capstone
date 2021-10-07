using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone
{
    public class Beverages : VendingMachineItems
    {
        public string FunMessage { get; } = "Glug Glug, Yum!";
        public Beverages(string itemName, decimal price, int inventory) 
            : base(itemName, price, inventory)
        {

        }
    }
}
