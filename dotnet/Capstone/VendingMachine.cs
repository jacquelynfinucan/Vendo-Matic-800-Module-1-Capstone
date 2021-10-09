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

        public decimal currentBalance = 0.00M;

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
                    Console.WriteLine($"{item.Key}\t{item.Value.ItemName}\t\t${item.Value.Price}\tCurrent Stock: *SOLD OUT*");
                }
                else
                {
                    Console.WriteLine($"{item.Key}\t{item.Value.ItemName}\t\t${item.Value.Price}\tCurrent Stock: {item.Value.Inventory}");
                }
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
                    Chips chip = new Chips(nameOfItem, costOfItem, inventory, typeOfItem);
                    dictonaryOfVendingItems[slotNumber] = chip;
                }
                else if (typeOfItem == "Candy")
                {
                    Candy candy = new Candy(nameOfItem, costOfItem, inventory, typeOfItem);
                    dictonaryOfVendingItems[slotNumber] = candy;
                }
                else if (typeOfItem == "Drink")
                {
                    Beverages drink = new Beverages(nameOfItem, costOfItem, inventory, typeOfItem);
                    dictonaryOfVendingItems[slotNumber] = drink;
                }
                else if (typeOfItem == "Gum")
                {
                    Gum gum = new Gum(nameOfItem, costOfItem, inventory, typeOfItem);
                    dictonaryOfVendingItems[slotNumber] = gum;
                }
                else
                {
                    Console.WriteLine("Invalid type");
                }
            }
            return dictonaryOfVendingItems;
        }
        public decimal RepeatedlyFeedMoney()
        {
            bool feedMoneyLoop = true;
            while (feedMoneyLoop)
            {
                decimal moneyInput = 0.00M;
                Console.WriteLine("Please enter how much money you'd like to add (whole dollars only, ex; 2).");
                Console.WriteLine("If finished entering money, enter 'B' to get back to the Purchase Menu.");
                string feedMoneyInput = Console.ReadLine().ToUpper();
                if (feedMoneyInput == "B")
                {
                    break;
                }
                else
                {
                    try
                    {
                        moneyInput = decimal.Parse(feedMoneyInput) + 0.00M;
                        if (moneyInput % 1 == 0)
                        {
                            currentBalance += moneyInput;
                            Console.WriteLine($"Current Balance: ${currentBalance}");
                            LogTransaction($"FEED MONEY:", moneyInput, currentBalance);
                        }
                        else
                        {
                            Console.WriteLine("**Invalid format.**");
                        }
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("**Invalid format.**");
                    }
                }
            }
            return currentBalance;
        }
        public string GetFunMessage(string objectType)
        {
            if (objectType == "Chip")
            {
                return "Crunch Crunch, Yum!";
            }
            else if(objectType == "Drink")
            {
                return "Glug Glug, Yum!";
            }
            else if(objectType == "Gum")
            {
                return "Chew Chew, Yum!";
            }
            else if(objectType == "Candy")
            {
                return "Munch Munch, Yum!";
            }
            else
            {
                return null;
            }
        }
        public void LogTransaction(string logType, decimal firstBalance, decimal secondBalance)
        {
            string outputFilePath = @"C:\Users\Student\git\csharp-capstone-module-1-team-1\dotnet\Log.txt";
            using (StreamWriter sw = new StreamWriter(outputFilePath, true))
            {
                sw.WriteLine($"{ DateTime.Now} {logType} ${firstBalance} ${secondBalance}");
            }
        }
        public decimal UserSlotSelection(string userInput)
        {
            if(dictonaryOfVendingItems[userInput].Inventory == 0)
            {
                Console.WriteLine("**That item is SOLD OUT. Please select another product.**");
                Console.WriteLine();
                //break & bring back to select product menu
            }
            else if(currentBalance < dictonaryOfVendingItems[userInput].Price)
            {
                Console.WriteLine("**Sorry you do not have enough money for that item. Please feed more money or select another product.**");
                Console.WriteLine();
                //break & bring back to select product menu
            }
            else
            {
                decimal startingBalance = currentBalance;
                currentBalance -= dictonaryOfVendingItems[userInput].Price;
                dictonaryOfVendingItems[userInput].Inventory --;
                Console.WriteLine();
                Console.WriteLine($"Purchased: {dictonaryOfVendingItems[userInput].ItemName} Price: {dictonaryOfVendingItems[userInput].Price}");
                Console.WriteLine(GetFunMessage(dictonaryOfVendingItems[userInput].ItemType));
                Console.WriteLine();
                Console.WriteLine($"There are {dictonaryOfVendingItems[userInput].Inventory} {dictonaryOfVendingItems[userInput].ItemName}(s) remaining.");
                Console.WriteLine($"Current Balance: {currentBalance}");
                LogTransaction($"{dictonaryOfVendingItems[userInput].ItemName} {userInput}", startingBalance, currentBalance);
            }
            return currentBalance;
        }
        public decimal ReturnChange()
        {
            int quarterCounter = 0;
            int dimeCounter = 0;
            int nickelCounter = 0;

            decimal finalBalanceForLog = currentBalance;
            while (currentBalance != 0)
            {
                if (currentBalance >= 0.25M)
                {
                    currentBalance -= 0.25M;
                    quarterCounter++;
                }
                else if(currentBalance >= 0.10M)
                {
                    currentBalance -= 0.10M;
                    dimeCounter++;
                }
                else if(currentBalance >= 0.05M)
                {
                    currentBalance -= 0.05M;
                    nickelCounter++;
                }
                else
                {
                    currentBalance = 0.0M;
                }
            }
            Console.WriteLine();
            Console.WriteLine($"You've received ${finalBalanceForLog} in {quarterCounter} Quarters, {dimeCounter} Dimes, and/or {nickelCounter} Nickels as your change.");
            Console.WriteLine("Thanks and have a great day!");
            Console.WriteLine();

            LogTransaction("GIVE CHANGE:", finalBalanceForLog, currentBalance);
            return currentBalance;
        }
        public void ResetInventory()
        {
            foreach(KeyValuePair<string, VendingMachineItems> item in dictonaryOfVendingItems)
            {
                dictonaryOfVendingItems[item.Key].Inventory = 5;
            }
        }
    } //end of class
}
