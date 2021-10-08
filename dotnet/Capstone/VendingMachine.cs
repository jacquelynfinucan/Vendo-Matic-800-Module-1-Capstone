using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Capstone
{
    public class VendingMachine
    {
        

        public List<string> listOfItems = new List<string>();

        public List<string> displayMenu = new List<string>();

        public string[] arrayOfSplit = new string[4];
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
        public string[] ListSplit()
        {
            foreach(string line in listOfItems)
            {
                line.Split(@"|");
            }
        }


    }
}
