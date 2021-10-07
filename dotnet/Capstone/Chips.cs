using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone
{
    public class Chips : VendingMachineItems
    {
        public string FunMessage { get; } = "Crunch Crunch, Yum!";
        public Chips(string itemName, decimal price, int inventory)
            : base(itemName, price, inventory)
        {

        }
    }
}
