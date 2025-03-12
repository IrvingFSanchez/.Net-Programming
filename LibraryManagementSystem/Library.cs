/*
Name: Irving F. Sanchez
Course: CPSC-23000-001 .NET Programming 
School: Lewis University, Romeoville, IL
Purpose: The Library class manages the collection of holdings (books and periodicals) and provides functionality for adding, checking out, returning, and listing holdings.
*/

/*
Note: The Library class uses a List<Holding> to store holdings and relies on the HoldingsWriter class to display holdings in a user-friendly format.
*/

using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace LibraryManagementSystem
{
    /*---+---+---+--Start of Library Class Block---+---+---+--*/
    public class Library
    {
        // List to store all holdings
        private List<Holding> _holdingsCollection = new List<Holding>();

        // Instance of HoldingsWriter for displaying holdings
        private HoldingsWriter _holdingsWriter = new HoldingsWriter();

        // Method to add a new holding to the library
        public void AddHolding(Holding holding)
        {
            if (holding == null)
            {
                throw new ArgumentNullException(nameof(holding), "Holding cannot be null.");
            }

            _holdingsCollection.Add(holding);
            Console.WriteLine($"Holding '{holding.CaptivatingTitle}' has been added to the library.");
        }

        // Method to check out a holding by its ID
        public bool CheckOut(int uniqueIdentifier)
        {
            Holding? holding = FindHoldingById(uniqueIdentifier);
            if (holding != null && !holding.IsReserved)
            {
                holding.Reserve();
                return true; // Successfully checked out
            }
            return false; // Holding not found or already checked out
        }

        // Method to return a holding by its ID
        public bool CheckIn(int uniqueIdentifier)
        {
            Holding? holding = FindHoldingById(uniqueIdentifier);
            if (holding != null && holding.IsReserved)
            {
                holding.Return();
                return true; // Successfully returned
            }
            return false; // Holding not found or already checked in
        }

        // Method to list all holdings using HoldingsWriter
        public void ListAll()
        {
            _holdingsWriter.DisplayHoldings(_holdingsCollection);
        }

        // Method to get statistics about available and checked-out holdings
        public (int Available, int CheckedOut) GetStats()
        {
            int available = 0;
            int checkedOut = 0;

            foreach (var holding in _holdingsCollection)
            {
                if (holding.IsReserved)
                {
                    checkedOut++;
                }
                else
                {
                    available++;
                }
            }

            return (available, checkedOut);
        }

        // Helper method to find a holding by its ID
        private Holding? FindHoldingById(int uniqueIdentifier)
        {
            foreach (var holding in _holdingsCollection)
            {
                if (holding.UniqueIdentifier == uniqueIdentifier)
                {
                    return holding;
                }
            }
            return null; // Holding not found
        }

        // Method to save holdings to a JSON file
        public void SaveToFile(string filePath)
        {
            var options = new JsonSerializerOptions { WriteIndented = true };
            string json = JsonSerializer.Serialize(_holdingsCollection, options);
            File.WriteAllText(filePath, json);
            Console.WriteLine($"Library data saved to {filePath}.");
        }

        // Method to load holdings from a JSON file
        public void LoadFromFile(string filePath)
        {
            if (!File.Exists(filePath))
            {
                Console.WriteLine($"File not found: {filePath}");
                return;
            }

            string json = File.ReadAllText(filePath);
            _holdingsCollection = JsonSerializer.Deserialize<List<Holding>>(json) ?? new List<Holding>();
            Console.WriteLine($"Library data loaded from {filePath}.");
        }
    }
    /*---+---+---+--End of Library Class Block---+---+---+--*/
}