/*
Name: Irving F. Sanchez
Course: CPSC-23000-001 .NET Programming 
School: Lewis University, Romeoville, IL
Purpose: The Book class represents a book in the library. It inherits from the Holding class and adds properties like YearOfCreation and CreativeAuthor.
*/

/*
Note: The Book class overrides the GetHoldingType() and ToString() methods to provide book-specific details.
*/

using System;

namespace LibraryManagementSystem
{
    /*---+---+---+--Start of Book Class Block---+---+---+--*/
    public class Book : Holding
    {
        // Additional properties for Book
        public int YearOfCreation { get; set; } // Represents the copyright year
        public string? CreativeAuthor { get; set; } // Nullable property

        // Constructors
//        public Book() { }

        public Book(int uniqueIdentifier, string captivatingTitle, string enrichingDescription, int yearOfCreation, string creativeAuthor)
            : base(uniqueIdentifier, captivatingTitle, enrichingDescription) // Call base constructor
        {
            // Validate the year of creation
            if (yearOfCreation < 1800 || yearOfCreation > 2025)
            {
                throw new ArgumentException("Year of creation must be between 1800 and 2025.");
            }

            YearOfCreation = yearOfCreation;
            CreativeAuthor = creativeAuthor ?? throw new ArgumentNullException(nameof(creativeAuthor)); // Ensure non-null
        }

        // Override GetHoldingType() to return "Book"
        public override string GetHoldingType()
        {
            return "Book";
        }

        // Override ToString() to provide a detailed description of the book
        public override string ToString()
        {
            return base.ToString() + $"\nType: {GetHoldingType()}\nYear of Creation: {YearOfCreation}\nCreative Author: {CreativeAuthor}";
        }
    }
    /*---+---+---+--End of Book Class Block---+---+---+--*/
}