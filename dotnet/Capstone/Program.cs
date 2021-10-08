using System;

namespace Capstone
{
    public class Program
    {
        static void Main(string[] args)
        {

            VendingMachine vendingMachine = new VendingMachine();
            vendingMachine.ReadInputFile();
            
            Console.WriteLine("Welcome to the Vendo-Matic-800!");
            Console.WriteLine("(1) Display Vending Machine Items\n(2) Purchase\n(3) Exit");
            string mainMenuInput = Console.ReadLine();
            bool mainMenuLoop = true;


            while (mainMenuLoop)
            {
                if (mainMenuInput == "1")
                {
                    vendingMachine.DisplayMenu();
                    
                    Console.WriteLine("Step 1");
                    mainMenuLoop = false;
                }
                else if (mainMenuInput == "2")
                {

                    Console.WriteLine("Step 2");
                    mainMenuLoop = false;
                }
                else if (mainMenuInput == "3")
                {

                    Console.WriteLine("Step 3");
                    mainMenuLoop = false;
                }
                else
                {
                    Console.WriteLine("Please enter a valid option.");
                    Console.WriteLine("(1) Display Vending Machine Items\n(2) Purchase\n(3) Exit");
                    mainMenuInput = Console.ReadLine();
                }
            }
            
        }
    }
}
