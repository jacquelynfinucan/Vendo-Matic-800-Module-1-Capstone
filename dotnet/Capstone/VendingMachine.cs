using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Capstone
{
    public class VendingMachine
    {
        VendingMachineItems vendingMachineItems = new VendingMachineItems("", 0.0M, 0);

        public List<string> listOfItems = new List<string>();

        public List<string> displayMenu = new List<string>();

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
            foreach (string line in listOfItems)
            {
                Console.WriteLine(line);
            }

        }
        public Dictionary<string, VendingMachineItems> CreateDictionaryOfItems()
        {
            foreach(string line in listOfItems)
            {
                string[] arrayOfSplit = line.Split(@"|");
                for (int i = 0; i < arrayOfSplit.Length; i++)
                {

                    string slotNumber = arrayOfSplit[0];
                    string nameOfItem = arrayOfSplit[1];
                    decimal costOfItem = decimal.Parse(arrayOfSplit[2]);
                    string typeOfItem = arrayOfSplit[3];
                    int inventory = 5;
                    Chips chip = new Chips(nameOfItem, costOfItem, inventory);
                    vendingMachineItems.dictonaryOfVendingItems[slotNumber] = chip;
                    //will have to find index of item type first
                    Console.WriteLine("This is chip");
                    
                }
            }
            return vendingMachineItems.dictonaryOfVendingItems;
        }


    }
}
