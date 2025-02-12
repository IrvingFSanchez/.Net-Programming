/*
Name: Irving F. Sanchez
Course: CPSC-23000-001 .NET Programming 
School: Lewis University, Romeoville, IL
Purpose: Create a storefront program that allows the user to purchase items from a store from a list of items and prices in Storefront.txt
*/

/*Note: I put a ton of comments in my code for personal use, I add notes to help me understand what
I'm doing and why I'm doing it.I'm not sure if this is a good practice or not, but I'm doing it for now.*/

using System; //Similar to other import statements in other languages this imports the System namespace, which essentially contains fundamental classes and base classes

using System.Collections.Generic; // This import is for using collections for Dictionary and Lists
using System.IO; // This import is for using file input/output
using System.Linq; // This import is for using LINQ queries like sorting and filtering

namespace Storefront // Defining the namespace to organize the code
{
    class Program // Here i'm just defining the main class of the program
    {
        static void Main(string[] args) // Per usual this is the main entry point of the program
        {
            //NOTE: This Banner block I copied from my previous code, no point in reinventing the wheel
            // --also I did a program similar to this in my Computer Engineering class.


                    /*---+---+---+--Banner Block---+---+---+--*/
            //Here I will print the heading of the application (what users initially will see) and the initial questions to the user
            string asterisk = "*";
            string text = "Storefront V1.0";
            int bannerWidth = 50; //Sets the total width of the banner i'm trying to make

            string topLine = new string(asterisk[0], bannerWidth); //Creates a string of asterisks that is the same length as the bannerWidth
            int padding = (bannerWidth - text.Length) / 2; //This will calculate the padding needed to ensure the text is centered between the asterisks and looks clean
            string centerText = text.PadLeft(padding + text.Length).PadRight(bannerWidth); //This is going to center the text between the asterisks
            string bottomLine = topLine;

            Console.WriteLine(topLine);
            Console.WriteLine(centerText);
            Console.WriteLine(bottomLine);
            Console.WriteLine();            
            /*---+---+---+--End of Banner Block---+---+---+--*/



            /*---+---+---+--Start of File Input Block---+---+---+--*/

            // Automatically reads the inventory file named "Storefront.txt" that I named myself for the program to read
            string filePath = "Storefront.txt";
            // Here I want to create dictionaries that stores the inventory and the user's cart. Kind of reminds me of amazons shopping cart within their in person store
            Dictionary<string, double> inventory = new Dictionary<string, double>();
            Dictionary<string, int> cart = new Dictionary<string, int>();

            // Here I want the program to load the inventory from the file
            try
            {
                string[] lines = File.ReadAllLines(filePath);
                foreach (string line in lines)
                {
                    string[] parts = line.Split('\t');
                    if (parts.Length == 2) // This ensures the line has exactly two parts (Wich signifies the item name and the price of the item)
                    {
                        string itemName = parts[0];
                        double itemPrice = double.Parse(parts[1]);
                        inventory[itemName] = itemPrice;
                    }
                }
            }
            // Note keeping track of the curly brackets sucks
            catch (Exception ex)
            {   // To handle file reading errors we will return this console message
                Console.WriteLine("Error reading inventory file: " + ex.Message);
                return; // If for some reason there is an error the program will stop and exit, i can update this later to instead ask for the correct file
            }
            /*---+---+---+--End of File Input Block---+---+---+--*/



            /*---+---+---+--Start of Shopping Loop Block---+---+---+--*/
            // Here I want to create a loop that will allow the user to shop until they decide to quit
            while (true)
            {
                // Here I want to print the inventory to the user including their prices
                Console.WriteLine("What would you like to buy?\n");
                foreach (var item in inventory)
                {
                    Console.WriteLine($"{item.Key.PadRight(20)} ${item.Value:F2}");
                }


                //Here I want to ask the user to enter an item name or 'quit' to end the program
                Console.Write("\nEnter an item name or 'quit' to end: ");
                string itemName = Console.ReadLine().ToLower(); // This will convert the user's input to lowercase to ensure it matches the inventory
                if (itemName == "quit")
                {
                    break; // If the user types quit the program will break out of the loop and end
                }
                // Next I'd like to ensure the item indeed exists in the inventory
                if (inventory.ContainsKey(itemName))
                {
                    int quantity;
                    while (true)
                    {
                        // Here I want to ask the user to enter the quantity of the item they want to buy
                        Console.Write("Enter the quantity: ");
                        if (int.TryParse(Console.ReadLine(), out quantity) && quantity > 0) // This will ensure the user enters a valid quantity and that it is a positive integer
                        {
                            break; // If the user enters a valid quantity the program will break out of the loop
                        }
                        else
                        {
                            Console.WriteLine("Invalid quantity. Please enter a positive integer.");
                        }
                    }
                    // Here I want to add the item to the user's cart or update quantity if it already exists
                    if (cart.ContainsKey(itemName))
                    {
                        cart[itemName] += quantity;
                    }
                    else
                    {
                        cart[itemName] = quantity;
                    }
                    // To confirm the item was added to the cart I will print the cart to the user
                    Console.WriteLine($"You added {quantity} {itemName} to your cart.");
                }
                else
                {
                    // If the user enters an invalid item name I will print this message to notify them the item doesn't exist
                    Console.WriteLine("\nSorry mate, we don't carry that item we aren't Cosco. Try again.\n");
                }
            }
            /*---+---+---+--End of Shopping Loop Block---+---+---+--*/



            /*---+---+---+--Start of Checkout Block---+---+---+--*/
            // Here I want to print the user's cart and calculate the total price
            Console.WriteLine("\nYour cart:");
            double totalCost = 0;

            // Here I want to sort the cart by item name and display each item with its total cost
            foreach (var item in cart.OrderBy(i => i.Key))
            {
                double itemTotal = inventory[item.Key] * item.Value;
                Console.WriteLine($"{item.Key.PadRight(20)} {item.Value} - ${itemTotal:F2}");
                totalCost += itemTotal;
            }

            // Here I want to print the total cost of the user's cart
            Console.WriteLine($"Total cost: ${totalCost:F2}");
            Console.WriteLine("\nThank you for shopping with us!\n");
            /*---+---+---+--End of Checkout Block---+---+---+--*/
        }
    }
}

// NOTE: I just realized I automatically had the file load up instead of the user inputting the name of the file. 
// The name of the file is called Storefront.txt and it is in the same directory as the program but i also put it in the bin/debug/netx.x folder just in case