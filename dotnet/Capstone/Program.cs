using System;

namespace Capstone
{
    public class Program
    {
        static void Main(string[] args)
        {
            VendingMachine vendingMachine = new VendingMachine();
            vendingMachine.ReadInputFile();
            vendingMachine.CreateDictionaryOfItems();

            //Console.WriteLine(vendingMachine.dictonaryOfVendingItems["A1"].Inventory);

            Console.WriteLine("Welcome to the Vendo-Matic-800!");
            Console.WriteLine();
            bool giantLoop = true;
            while (giantLoop)
            {
                Console.WriteLine("(1) Display Vending Machine Items\n(2) Purchase\n(3) Exit");
                string mainMenuInput = Console.ReadLine();
                Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
                bool mainMenuLoop = true;


                while (mainMenuLoop)
                {
                    if (mainMenuInput == "1") //DISPLAY VENDING MACHINE ITEMS
                    {
                        vendingMachine.DisplayMenu();
                        bool displayMenuLoop = true;
                        while (displayMenuLoop)
                        {
                            Console.WriteLine("When ready, enter 'B' to get back to the Main Menu.");
                            string displayMenuInput = Console.ReadLine().ToUpper();

                            if (displayMenuInput == "B")
                            {
                                mainMenuLoop = false;
                                displayMenuLoop = false;
                            }
                            else
                            {
                                Console.WriteLine("Invalid option, please select another option.");
                            }
                        }
                        mainMenuLoop = false;
                    }
                    else if (mainMenuInput == "2") //PURCHASE (PURCHASE MENU STARTS)
                    {
                        bool purchaseMenuLoop = true;
                        while (purchaseMenuLoop)
                        {
                            Console.WriteLine("(1) Feed Money\n(2) Select Product\n(3) Finish Transaction");
                            string purchaseMenuInput = Console.ReadLine();
                            if (purchaseMenuInput == "1") //FEED MONEY
                            {
                                vendingMachine.RepeatedlyFeedMoney();
                            }
                            else if (purchaseMenuInput == "2") //SELECT PRODUCT
                            {
                                vendingMachine.DisplayMenu();
                                Console.WriteLine();
                                Console.WriteLine($"Current Balance: ${vendingMachine.currentBalance}.00");
                                Console.WriteLine();
                                bool selectProductLoop = true;
                                while (selectProductLoop)
                                {
                                    
                                    Console.WriteLine("Please enter your selected product's slot number.");//clarify slot # for our user
                                    Console.WriteLine("Or you can enter 'B' to get back to the Purchase Menu to feed money or exit.");
                                    string selectProductInput = Console.ReadLine().ToUpper();

                                    if (selectProductInput == "B")
                                    {
                                        break;
                                    }
                                    else if (vendingMachine.dictonaryOfVendingItems.ContainsKey(selectProductInput)) //If their selection was valid
                                    {
                                        vendingMachine.UserSlotSelection(selectProductInput);
                                        
                                    }
                                    else
                                    {
                                        Console.WriteLine("**Invalid option, please select another option.**");
                                        Console.WriteLine();
                                    }
                                }


                                mainMenuLoop = false;
                                
                            }
                            else if (purchaseMenuInput == "3") //FINISH TRANSACTION
                            {

                                mainMenuLoop = false;
                                purchaseMenuLoop = false;
                            }
                            else
                            {
                                Console.WriteLine("Invalid option, please select another option.");
                            }
                        }
                        //mainMenuLoop = false;
                    }
                    else if (mainMenuInput == "3") //EXIT
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
}
