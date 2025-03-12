/*
Name: Irving F. Sanchez
Course: CPSC-23000-001 .NET Programming 
School: Lewis University, Romeoville, IL
Purpose: The HoldingsWriter class is responsible for formatting and displaying holdings in a user-friendly way.
*/

/*
Note: The HoldingsWriter class is used by the Library class to print the list of holdings, separating checked-out and available items.
*/

using System;
using System.Collections.Generic;

namespace LibraryManagementSystem
{
    /*---+---+---+--Start of HoldingsWriter Class Block---+---+---+--*/
    public class HoldingsWriter
    {
        // Method to display holdings in a formatted way
        public void DisplayHoldings(List<Holding> holdings)
        {
            Console.WriteLine("\n📚 Library Holdings:");
            Console.WriteLine("Checked Out Holdings:");
            bool hasCheckedOut = false;

            foreach (var holding in holdings)
            {
                if (holding.IsReserved)
                {
                    Console.WriteLine(holding.ToString());
                    Console.WriteLine(new string('-', 40)); // Separator line
                    hasCheckedOut = true;
                }
            }

            if (!hasCheckedOut)
            {
                Console.WriteLine("No holdings are checked out.");
            }

            Console.WriteLine("\nAvailable Holdings:");
            bool hasAvailable = false;

            foreach (var holding in holdings)
            {
                if (!holding.IsReserved)
                {
                    Console.WriteLine(holding.ToString());
                    Console.WriteLine(new string('-', 40)); // Separator line
                    hasAvailable = true;
                }
            }

            if (!hasAvailable)
            {
                Console.WriteLine("No holdings are available.");
            }
        }
    }
    /*---+---+---+--End of HoldingsWriter Class Block---+---+---+--*/
}