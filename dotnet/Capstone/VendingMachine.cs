using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Capstone
{
    public class VendingMachine
    {
        public void ReadInputFile()
        {
            string filePath = @"C:\Users\Student\git\csharp-capstone-module-1-team-1\dotnet\vendingmachine.csv";
            using (StreamReader sr = new StreamReader(filePath))
            {
                while(!sr.EndOfStream)
                {
                    string line = sr.ReadLine();
                    string[] lineArray = line.Split(@"|");
                    
                    foreach(string word in lineArray)
                    {
                        //A1|Potato Crisps|3.05|Chip
                        //0       1         2    3

                    }


                }
            }
        }
        
    }
}
