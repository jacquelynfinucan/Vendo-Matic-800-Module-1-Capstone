using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone
{
    public class Gum : VendingMachineItems
    {
        public string FunMessage { get; } = "Chew Chew, Yum!";
        public Gum(string itemName, decimal price, int inventory)
            : base(itemName, price, inventory)
        {

        }
     

    }
}
