using System;

namespace GroupProject_1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Grand Chirpus Tacos!");
            Console.WriteLine();

            Console.WriteLine("Would you like to place an order?");
            Console.Write("Please enter (y)es or (n)o: ");
            var userInput1 = Console.ReadLine().ToLower();
            Console.Clear();
    

            var continueLoop = true;

            while (continueLoop)
            {

                if (userInput1.Equals("y", StringComparison.OrdinalIgnoreCase) || userInput1.Equals("yes", StringComparison.OrdinalIgnoreCase))
                {
                    while (userInput1.Equals("y", StringComparison.OrdinalIgnoreCase) || userInput1.Equals("yes", StringComparison.OrdinalIgnoreCase))
                    {
                        var continueLoop2 = true;

                        while (continueLoop2)
                        {
                            //display menu list
                            Menu.CreateMenu();
                            var grandTotal = Order.CreateOrder();

                            Console.WriteLine($"This is the grand total variable in program class: {grandTotal}");
                            
                            
                                                       

                            Console.WriteLine("Are there any more customers?");
                            Console.Write("Please enter (y)es or (n)o: ");
                            userInput1 = Console.ReadLine().ToLower();
                            Console.Clear();

                            var continueLoop3 = true;

                            while (continueLoop3)
                            {
                                if (userInput1.Equals("y", StringComparison.OrdinalIgnoreCase) || userInput1.Equals("yes", StringComparison.OrdinalIgnoreCase))
                                {
                                    Console.WriteLine("Welcome to Grand Chirpus Tacos!");
                                    Console.WriteLine();
                                    break;
                                }
                                else if (userInput1.Equals("n", StringComparison.OrdinalIgnoreCase) || userInput1.Equals("no", StringComparison.OrdinalIgnoreCase))
                                {
                                    continueLoop2 = false;                                  
                                    break;
                                }
                                else
                                {
                                    Console.WriteLine("Invalid entry. Please try again.");
                                    Console.Clear();
                                    Console.WriteLine("Are there any more customers?");
                                    Console.Write("Please enter (y)es or (n)o: ");
                                    userInput1 = Console.ReadLine().ToLower();
                                    Console.WriteLine();
                                }
                            }
                        }
                    }
                    break;
                }
                else if (userInput1.Equals("n", StringComparison.OrdinalIgnoreCase) || userInput1.Equals("no", StringComparison.OrdinalIgnoreCase))
                {
                    Console.Clear();
                    break;
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Invalid entry. Please try again.");
                    Console.WriteLine();
                    Console.WriteLine("Would you like to place an order?");
                    Console.Write("Please enter (y)es or (n)o: ");
                    userInput1 = Console.ReadLine().ToLower();
                    Console.WriteLine();
                }
            }

            Console.WriteLine("OK, closing time. Goodbye!");
                Console.ReadKey();
        }
    }
}
