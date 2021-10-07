using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone
{
    public class Candy : VendingMachineItems
    {
        public string FunMessage { get; } = "Munch Munch, Yum!";
        public Candy(string itemName, decimal price, int inventory)
            : base(itemName, price, inventory)
        {

        }
    }
}
