using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaCreator
{
    class Program
    {
        // Create some variables to store pizza information
        private static string pizzaSize = "";
        private static double pizzaSizeCost = 0;

        private static string pizzaMeats = "";
        private static double pizzaMeatsCost = 0;

        private static string pizzaVegetables = "";
        private static double pizzaVegetablesCost = 0;

        private static string pizzaSauce = "";
        private static double pizzaSauceCost = 0;

        private static string pizzaCheese = "";
        private static double pizzaCheeseCost = 0;

        private static string pizzaDelivery = "";
        private static double pizzaDeliveryCost = 0;

        /// <summary>
        /// A simple utility function to confirm the user with a yes or no
        /// </summary>
        private static bool Confirm(string message)
        { 
            while(true)
            {
                Console.Write(message + " (Y)es (N)o ");
                char response = Console.ReadKey().KeyChar;
                Console.WriteLine();

                if (response == 'y' || response == 'Y')
                    return true;

                if (response == 'n' || response == 'N')
                    return false;

                Console.WriteLine("Error: Please respond with a (y)es or (n)o only.");
            }
        }

        /// <summary>
        /// Remove details on the current order
        /// </summary>
        private static void ClearOrder()
        {
            pizzaSize = "";
            pizzaSizeCost = 0;

            pizzaMeats = "";
            pizzaMeatsCost = 0;

            pizzaVegetables = "";
            pizzaVegetablesCost = 0;

            pizzaSauce = "";
            pizzaSauceCost = 0;

            pizzaCheese = "";
            pizzaCheeseCost = 0;

            pizzaDelivery = "";
            pizzaDeliveryCost = 0;
        }

        /// <summary>
        /// Allow the user to read a size of the pizza
        /// </summary>
        private static void SelectPizzaSize()
        {
            char option = '\0';

            while (true)
            {
                Console.Write("Select a size: (S)mall $5.00 (M)edium $6.25 (L)arge $8.75 ");
                option = char.ToUpper(Console.ReadKey().KeyChar);
                Console.WriteLine();

                if (option == 'S' || option == 'M' || option == 'L')
                    break;

                Console.WriteLine("Error: Invalid selection. Try again.");
            }

            // Update the order
            if(option == 'S')
            {
                pizzaSizeCost = 6.25;
                pizzaSize = "Small Pizza".PadRight(20) + pizzaSizeCost.ToString("C") + Environment.NewLine;
            }
            else if(option == 'M')
            {
                pizzaSizeCost = 5.00;
                pizzaSize += "Medium Pizza".PadRight(20) + pizzaSizeCost.ToString("C") + Environment.NewLine;
            }
            else if(option == 'L')
            {
                pizzaSizeCost = 8.75;
                pizzaSize += "Large Pizza".PadRight(20) + pizzaSizeCost.ToString("C") + Environment.NewLine;
            }
        }

        /// <summary>
        /// Allow user to select a meat
        /// </summary>
        private static void SelectPizzaMeat()
        {
            if (!Confirm("Would you like to add meat to your pizza?"))
                return;

            pizzaMeats = "Meats" + Environment.NewLine;
            pizzaMeatsCost = 0;
            
            while (true)
            {
                char option = '\0';

                while (true)
                {
                    Console.Write("Select a meat $0.75 each: (B)acon (H)am (P)epperoni (Sausage) ");
                    option = char.ToUpper(Console.ReadKey().KeyChar);
                    Console.WriteLine();

                    if (option == 'B' || option == 'H' || option == 'P' || option == 'S')
                        break;

                    Console.WriteLine("Error: Invalid selection. Try again.");
                }

                // Update the order
                pizzaMeatsCost += 0.75;

                if (option == 'B')
                    pizzaMeats += "    Bacon".PadRight(20) + pizzaMeatsCost.ToString("C") + Environment.NewLine;
                else if (option == 'H')
                    pizzaMeats += "    Ham".PadRight(20) + pizzaMeatsCost.ToString("C") + Environment.NewLine;
                else if (option == 'P')
                    pizzaMeats += "    Pepperoni".PadRight(20) + pizzaMeatsCost.ToString("C") + Environment.NewLine;
                else if (option == 'S')
                    pizzaMeats += "    Sausage".PadRight(20) + pizzaMeatsCost.ToString("C") + Environment.NewLine;

                if (!Confirm("Would you like to add more meat?"))
                    break;
            }
        }

        /// <summary>
        /// Allow user to select a vegetable
        /// </summary>
        private static void SelectPizzaVegetables()
        {
            if (!Confirm("Would you like to add vegetable to your pizza?"))
                return;

            pizzaVegetables = "Vegetables" + Environment.NewLine;
            pizzaVegetablesCost = 0;

            while (true)
            {
                char option = '\0';

                while (true)
                {
                    Console.Write("Select a vegetable $0.50 each: (B)lackOlives (M)ushrooms (O)nions (P)eppers ");
                    option = char.ToUpper(Console.ReadKey().KeyChar);
                    Console.WriteLine();

                    if (option == 'B' || option == 'M' || option == 'O' || option == 'P')
                        break;

                    Console.WriteLine("Error: Invalid selection. Try again.");
                }

                // Update the order
                pizzaVegetablesCost += 0.50;

                if (option == 'B')
                    pizzaVegetables += "    Black olives".PadRight(20) + pizzaVegetablesCost.ToString("C") + Environment.NewLine;
                else if (option == 'M')
                    pizzaVegetables += "    Mushrooms".PadRight(20) + pizzaVegetablesCost.ToString("C") + Environment.NewLine;
                else if (option == 'O')
                    pizzaVegetables += "    Onions".PadRight(20) + pizzaVegetablesCost.ToString("C") + Environment.NewLine;
                else if (option == 'P')
                    pizzaVegetables += "    Peppers".PadRight(20) + pizzaVegetablesCost.ToString("C") + Environment.NewLine;

                if (!Confirm("Would you like to add more vegetable?"))
                    break;
            }
        }

        /// <summary>
        /// Allow the user to read a sauce, updates the order summary
        /// and total cost.
        /// </summary>
        private static void SelectPizzaSauce()
        {
            pizzaSauce = "Sauce" + Environment.NewLine;
            
            char option = '\0';

            while (true)
            {  
                Console.Write("Select a sauce: (T)raditional $0.00 (G)arlic $1.00 (O)regano $1.00 ");
                option = char.ToUpper(Console.ReadKey().KeyChar);
                Console.WriteLine();

                if (option == 'T' || option == 'G' || option == 'O')
                    break;

                Console.WriteLine("Error: Invalid selection. Try again.");
            }

            // Update the order
    
            if (option == 'T')
            {
                pizzaSauceCost = 0.00;
                pizzaSauce += "    Traditional".PadRight(20) + pizzaSauceCost.ToString("C") + Environment.NewLine;
            }
            else if (option == 'G')
            {
                pizzaSauceCost = 1.00;
                pizzaSauce += "    Garlic".PadRight(20) + pizzaSauceCost.ToString("C") + Environment.NewLine;
            }
            else if (option == 'L')
            {
                pizzaSauceCost = 1.75;
                pizzaSauce += "    Onions".PadRight(20) + pizzaSauceCost.ToString("C") + Environment.NewLine;
            }
        }

        /// <summary>
        /// Allow the user to select a cheese
        /// </summary>
        private static void SelectPizzaCheese()
        {
            pizzaCheese = "Cheese" + Environment.NewLine;

            char option = '\0';

            while (true)
            {
                Console.Write("Select a cheese: (R)egular $0.00 (E)xtra $1.25 ");
                option = char.ToUpper(Console.ReadKey().KeyChar);
                Console.WriteLine();

                if (option == 'R' || option == 'E')
                    break;

                Console.WriteLine("Error: Invalid selection. Try again.");
            }

            // Update the order
            if (option == 'R')
            {
                pizzaCheeseCost = 0.00;
                pizzaCheese += "    Regular".PadRight(20) + pizzaCheeseCost.ToString("C") + Environment.NewLine;
            }
            else if (option == 'G')
            {
                pizzaCheeseCost = 1.25;
                pizzaCheese += "    Extra".PadRight(20) + pizzaCheeseCost.ToString("C") + Environment.NewLine;
            }
        }

        /// <summary>
        /// Allow the user to select a delivery
        /// </summary>
        private static void SelectPizzaDelivery()
        {
            pizzaDelivery = "Delivery" + Environment.NewLine;

            char option = '\0';

            while (true)
            {
                Console.Write("Select a delivery: (T)akeout $0.00 (D)Delivery $2.50 ");
                option = char.ToUpper(Console.ReadKey().KeyChar);
                Console.WriteLine();

                if (option == 'T' || option == 'D')
                    break;

                Console.WriteLine("Error: Invalid selection. Try again.");
            }

            // Update the order
            if (option == 'T')
            {
                pizzaDeliveryCost = 0.00;
                pizzaDelivery += "    Take Out".PadRight(20) + pizzaDeliveryCost.ToString("C") + Environment.NewLine;
            }
            else if (option == 'D')
            {
                pizzaDeliveryCost = 2.50;
                pizzaDelivery += "    Delivery".PadRight(20) + pizzaDeliveryCost.ToString("C") + Environment.NewLine;
            }
        }

        /// <summary>
        /// Start with a new order
        /// </summary>
        private static void NewOrder()
        {
            // If a previous order exists, then confirm for replacement
            if (!string.IsNullOrEmpty(pizzaSize)
                && !Confirm("A current order exists, would you like to replace it?"))
                return;

            // Allow the user to choose a size
            ClearOrder();
            
            // Select pizza size
            SelectPizzaSize();
            Console.WriteLine();

            // Add meat
            SelectPizzaMeat();
            Console.WriteLine();

            // Add vegetables
            SelectPizzaVegetables();
            Console.WriteLine();

            // Add sauce
            SelectPizzaSauce();
            Console.WriteLine();

            // Add Cheese
            SelectPizzaCheese();
            Console.WriteLine();

            // Select delivery
            SelectPizzaDelivery();
            Console.WriteLine();

            // We're done
            Console.WriteLine("Ok: New order created.");
        }

        /// <summary>
        /// Update an existing order
        /// </summary>
        private static void ModifyOrder()
        {
            // If no order exists, then nothing to modify
            if (string.IsNullOrEmpty(pizzaSize))
            {
                Console.WriteLine("Error: There are no order to modify.");
                return;
            }

            // Modify size
            if (Confirm("Would you like to modify the size?"))
                SelectPizzaSize();
            Console.WriteLine();

            // Modify meat
            if(Confirm("Would you like to modify the meat?"))
                SelectPizzaMeat();
            Console.WriteLine();

            // Modify vegetables
            if(Confirm("Would you like to modify the vegetable?"))
                SelectPizzaVegetables();
            Console.WriteLine();

            // Modify sauce
            if(Confirm("Would you like to modify the sauce?"))
                SelectPizzaSauce();
            Console.WriteLine();

            // Modify Cheese
            if(Confirm("Would you like to modify the cheese?"))
                SelectPizzaCheese();
            Console.WriteLine();

            // Modify delivery
            if(Confirm("Would you like to modify the delivery?"))
                SelectPizzaDelivery();
            Console.WriteLine();

            // We're done
            Console.WriteLine("Ok: Order updated.");
        }

        /// <summary>
        /// Display the order
        /// </summary>
        private static void DisplayOrder()
        {
            if (string.IsNullOrEmpty(pizzaSize))
            {
                Console.WriteLine("Error: There are no order to display.");
                return;
            }

            // Display summary
            Console.Write(pizzaSize);
            Console.Write(pizzaDelivery);
            Console.Write(pizzaMeats);
            Console.Write(pizzaVegetables);
            Console.Write(pizzaSauce);
            Console.Write(pizzaCheese);

            for (int i = 0; i < 30; i++)
                Console.Write("-");

            Console.WriteLine();

            // Total the cost
            double totalCost = pizzaSizeCost + pizzaMeatsCost + pizzaVegetablesCost + pizzaSauceCost + pizzaCheeseCost + pizzaDeliveryCost;
            Console.WriteLine("Total".PadRight(20) + totalCost.ToString("C"));
        }

        /// <summary>
        /// Entry point of the program
        /// </summary>
        static void Main(string[] args)
        {        
            // Start with a menu
            char option = '\0';

            while(option != '0')
            {
                // Ask the user what to do
                Console.WriteLine("Main Menu");
                Console.WriteLine("1. New Order");
                Console.WriteLine("2. Modify Order");
                Console.WriteLine("3. Display Order");
                Console.WriteLine("0. Quit");

                Console.Write("Option: ");
                option = Console.ReadKey().KeyChar;
                Console.WriteLine();

                Console.WriteLine();

                // Execute user's option
                if (option == '1')
                    NewOrder();
                else if (option == '2')
                    ModifyOrder();
                else if (option == '3')
                    DisplayOrder();

                Console.WriteLine();
            }
        }
    }
}
