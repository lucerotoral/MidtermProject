using System;
using System.Collections.Generic;
using System.Text;

namespace GroupProject_1
{
    class Order
    {
        public string ItemName { get; set; }
        public int Qty { get; set; }
        public decimal LinePrice { get; set; }

        public Order(string itemName, int qty, decimal linePrice)
        {
            ItemName = itemName;
            Qty = qty;
            LinePrice = linePrice;
        }

        public static decimal CreateOrder()
        {
            string line;
            var menuList = new List<Menu>();
            var orderList = new List<Order>();

            System.IO.StreamReader file =                
                new System.IO.StreamReader("productlist.txt");
            while ((line = file.ReadLine()) != null)
            {
                var words = line.Split(',');
                menuList.Add(new Menu(words[0], words[1], words[2], words[3], words[4]));
            }

            file.Close();

            string userContinues;
            int orderCounter = 0;
            bool loopforItemEntry= true;

            do
            {
                Console.Write($"Enter the item #(1-12) that you want to order: ");
                var itemSelectionString = Console.ReadLine();
                int itemSelection;

                while (!int.TryParse(itemSelectionString, out itemSelection))
                {
                    Console.WriteLine("Invalid entry!");
                    Console.WriteLine();
                    Console.Write($"Enter the item #(1-12) that you want to order: ");
                    itemSelectionString = Console.ReadLine();
                }

                while (itemSelection < 1 || itemSelection > 12)
                {
                    Console.WriteLine("Invalid entry!");
                    Console.WriteLine();
                    Console.Write($"Enter the item #(1-12) that you want to order: ");
                    //new code
                    itemSelectionString = Console.ReadLine();
                    while (!int.TryParse(itemSelectionString, out itemSelection))
                    {
                        Console.WriteLine("Invalid entry!");
                        Console.WriteLine();
                        Console.Write($"Enter the item #(1-12) that you want to order: ");
                        itemSelectionString = Console.ReadLine();
                    }

                    //new code
                    //uncomment below if needed
                    //itemSelection = int.Parse(Console.ReadLine());
                }

                Console.Clear();
                Console.Write($"How many {menuList[itemSelection].Name} would you like?: ");                
                var orderQtyString = Console.ReadLine();
                int orderQty;

                while (!int.TryParse(orderQtyString, out orderQty))
                {
                    Console.Clear();
                    Console.WriteLine("Invalid entry!");
                    Console.WriteLine();
                    Console.Write($"Enter the number of {menuList[itemSelection].Name} you would like to order: ");
                    orderQtyString = Console.ReadLine();
                }

                while (orderQty < 1)
                {
                    Console.Clear();
                    Console.WriteLine("Invalid entry!");
                    Console.WriteLine();
                    Console.Write($"Please enter a positive number of {menuList[itemSelection].Name}: ");
                    orderQtyString = Console.ReadLine();
                    //new code
                    while (!int.TryParse(orderQtyString, out orderQty))
                    {
                        Console.Clear();
                        Console.WriteLine("Invalid entry!");
                        Console.WriteLine();
                        Console.Write($"Please enter a positive number of {menuList[itemSelection].Name}: ");
                        orderQtyString = Console.ReadLine();
                    }
                }

                orderList.Add(new Order(menuList[itemSelection].Name, orderQty, (orderQty * (Decimal.Parse(menuList[itemSelection].Price)))));

                Console.Clear();
                Console.WriteLine($"{orderList[orderCounter].ItemName} X {orderList[orderCounter].Qty} = {String.Format("{0:C2}",orderList[orderCounter].LinePrice)}\n");

                orderCounter++;


                while (true)
                {
                    Console.Write("Would you like something else? (y)es or (n)o: ");
                    userContinues = Console.ReadLine();
                    Console.Clear();
                    if (userContinues.Equals("y", StringComparison.OrdinalIgnoreCase) || userContinues.Equals("yes", StringComparison.OrdinalIgnoreCase))
                    {
                        //added code

                        do
                        {
                            Console.Write("Would you like to see the menu again? Enter (y)es or (n)o: ");
                            var redisplayMenu = Console.ReadLine();
                            Console.Clear();
                            if (redisplayMenu.Equals("y", StringComparison.OrdinalIgnoreCase) || redisplayMenu.Equals("yes", StringComparison.OrdinalIgnoreCase))
                            {
                                Console.Clear();                                
                                Menu.CreateMenu();
                                break;
                            }
                            else if (redisplayMenu.Equals("n", StringComparison.OrdinalIgnoreCase) || redisplayMenu.Equals("no", StringComparison.OrdinalIgnoreCase))
                            {
                                Console.Clear();
                                break;
                            }
                            else
                            {
                                Console.WriteLine("Invalid Entry. Please try again.");
                                Console.WriteLine();
                            }
                        } while (true);

                        break;
                    }
                    else if (userContinues.Equals("n", StringComparison.OrdinalIgnoreCase) || userContinues.Equals("no", StringComparison.OrdinalIgnoreCase))
                    {
                        loopforItemEntry = false;
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Invalid Entry. Please try again.");
                        Console.WriteLine();
                    }
                }

            } while (loopforItemEntry);

            //new code
            decimal subTotal= 0;
           
            foreach (var item in orderList)
            {                
                Console.WriteLine($"{item.ItemName} X {item.Qty} = {String.Format("{0:C2}", item.LinePrice)}");
                subTotal += item.LinePrice;
            }

            decimal salesTax = subTotal * .06m;
            decimal grandTotal = subTotal + salesTax;
            

            Console.WriteLine($"Subtotal: {String.Format("{0:C2}", subTotal)} \nSales tax: {String.Format("{0:C2}", salesTax)} \nGrand total: {String.Format("{0:C2}", grandTotal)}");
            //new code

            return grandTotal;
            //return orderList;
        }
    }
}
