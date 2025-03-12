/*
Name: Irving F. Sanchez
Course: CPSC-23000-001 .NET Programming 
School: Lewis University, Romeoville, IL
Purpose: The Holding class is the base class for all library holdings. It provides common properties and methods for books and periodicals.
*/

/*
Note: The Holding class includes properties like ID, title, description, and checkout status, as well as methods for checking out and returning holdings.
*/

using System;

namespace LibraryManagementSystem
{
    /*---+---+---+--Start of Holding Class Block---+---+---+--*/
    public abstract class Holding
    {
        //Properties that will be used throughout
        public int UniqueIdentifier { get; set; } //This will represent the unique ID
        public string CaptivatingTitle { get; set; } //This will represent the title of the holding
        public string EnrichingDescription { get; set; } //This will represent the description of the holding
        public bool IsReserved { get; set; } //This will represent the checkout status of the holding

        //Important Constructor for Holding
        public Holding(int uniqueIdentifier, string captivatingTitle, string enrichingDescription)
        {
            UniqueIdentifier = uniqueIdentifier;
            CaptivatingTitle = captivatingTitle;
            EnrichingDescription = enrichingDescription;
            IsReserved = false;
        }

        //Important Methods for Holding
        public void Reserve()
        {

            if (!IsReserved)
            {
                IsReserved = true;
                Console.WriteLine($"The holding '{CaptivatingTitle}' has been reserved.");
            }
            else
            {
                Console.WriteLine($"The holding '{CaptivatingTitle}' is already reserved.");
            }
        }

        public void Return()
        {
            if (IsReserved)
            {
                IsReserved = false;
                Console.WriteLine($"The holding '{CaptivatingTitle}' has been returned.");
            }
            else
            {
                Console.WriteLine($"The holding '{CaptivatingTitle}' is not currently reserved.");
            }
        }

        //Abstract method that is implemented by subclasses
        public abstract string GetHoldingType();
        //Here we override the ToString() to provide a detailed description of the holding
        public override string ToString()
        {
            return $"ID: {UniqueIdentifier}\nTitle: {CaptivatingTitle}\nDescription: {EnrichingDescription}\nStatus: {(IsReserved ? "Reserved" : "Available")}";
        }
    }
}