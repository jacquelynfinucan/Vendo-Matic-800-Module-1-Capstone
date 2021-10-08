using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Capstone
{
    public class VendingMachine
    {
        public Dictionary<string, VendingMachineItems> dictonaryOfVendingItems = new Dictionary<string, VendingMachineItems>();

        public List<string> listOfItems = new List<string>();

        public int currentBalance = 0;
        public decimal trueBalance = 0.0M;

        public List<string> ReadInputFile()
        {
            string filePath = @"C:\Users\Student\git\csharp-capstone-module-1-team-1\dotnet\vendingmachine.csv";
            using (StreamReader sr = new StreamReader(filePath))
            {
                while (!sr.EndOfStream)
                {

                    string line = sr.ReadLine();
                    listOfItems.Add(line);
                }
                return listOfItems;
            }
        }
        public void DisplayMenu()
        {
            foreach (KeyValuePair<string, VendingMachineItems> item in dictonaryOfVendingItems)
            {
                if(item.Value.Inventory == 0)
                {
                    
                    Console.WriteLine($"{item.Key}\t{item.Value.ItemName}\t\t${item.Value.Price}\tCurrent Stock: SOLD OUT");
                }
                Console.WriteLine($"{item.Key}\t{item.Value.ItemName}\t\t${item.Value.Price}\tCurrent Stock: {item.Value.Inventory}");
                //maybe make more pretty?
            }
        }
        public Dictionary<string, VendingMachineItems> CreateDictionaryOfItems()
        {
            foreach (string line in listOfItems)
            {
                string[] arrayOfSplit = line.Split(@"|");

                string slotNumber = arrayOfSplit[0];
                string nameOfItem = arrayOfSplit[1];
                decimal costOfItem = decimal.Parse(arrayOfSplit[2]);
                string typeOfItem = arrayOfSplit[3];
                int inventory = 5;

                if (typeOfItem == "Chip")
                {
                    Chips chip = new Chips(nameOfItem, costOfItem, inventory);
                    dictonaryOfVendingItems[slotNumber] = chip;
                }
                else if (typeOfItem == "Candy")
                {
                    Candy candy = new Candy(nameOfItem, costOfItem, inventory);
                    dictonaryOfVendingItems[slotNumber] = candy;
                }
                else if (typeOfItem == "Drink")
                {
                    Beverages drink = new Beverages(nameOfItem, costOfItem, inventory);
                    dictonaryOfVendingItems[slotNumber] = drink;
                }
                else if (typeOfItem == "Gum")
                {
                    Gum gum = new Gum(nameOfItem, costOfItem, inventory);
                    dictonaryOfVendingItems[slotNumber] = gum;
                }
                else
                {
                    Console.WriteLine("Invalid type");
                }
            }
            return dictonaryOfVendingItems;
        }
        public int RepeatedlyFeedMoney()
        {
            bool feedMoneyLoop = true;
            while (feedMoneyLoop)
            {
                int moneyInput = 0;
                Console.WriteLine("Please enter how much money you'd like to add (whole dollars only, ex; 2).");
                Console.WriteLine("If finished entering money, enter 'Q' to quit.");
                string feedMoneyInput = Console.ReadLine().ToUpper();
                if (feedMoneyInput == "Q")
                {
                    break;
                }
                try
                {
                    moneyInput = int.Parse(feedMoneyInput);
                    currentBalance += moneyInput;
                    Console.WriteLine($"Current Balance: ${currentBalance}.00");
                }
                catch (Exception e)
                {
                    Console.WriteLine("Invalid format.");
                }
            }
            return currentBalance;
        }
        public decimal UserSlotSelection(string userInput)
        {
            if(dictonaryOfVendingItems[userInput].Inventory == 0)
            {
                Console.WriteLine("That item is SOLD OUT. Please something");
                //break & bring back to display menu to select product or back
            }
            else if(currentBalance < dictonaryOfVendingItems[userInput].Price)
            {
                Console.WriteLine("Sorry you do not have enough money for that item. Please enter more money or select another product.");
                //break & bring back to display menu to select product or back
            }
            else
            {
                //trueBalance = decimal.Parse(currentBalance); ********have to figure out why we can't parse
                trueBalance -= dictonaryOfVendingItems[userInput].Price;

                //Console.WriteLine($"{dictonaryOfVendingItems[userInput].ItemName} {dictonaryOfVendingItems[userInput].Price} {dictonaryOfVendingItems[userInput].FunMessage}");
                Console.WriteLine($"Current Balance: {currentBalance}");

            }


            return 0.0M;
            
        }





    } //end of class
}
