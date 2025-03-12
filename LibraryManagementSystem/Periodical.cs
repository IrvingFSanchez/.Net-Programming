/*
Name: Irving F. Sanchez
Course: CPSC-23000-001 .NET Programming 
School: Lewis University, Romeoville, IL
Purpose: The Periodical class represents a periodical (e.g., magazine, journal) in the library. It inherits from the Holding class and adds a PublicationDate property.
*/

/*
Note: The Periodical class overrides the GetHoldingType() and ToString() methods to provide periodical-specific details.
*/

using System;

namespace LibraryManagementSystem
{
    /*---+---+---+--Start of Periodical Class Block---+---+---+--*/
    public class Periodical : Holding
    {
        // Additional property for Periodical
        public string? PublicationDate { get; set; } // Nullable property

        // Constructors
//        public Periodical() { }

        public Periodical(int uniqueIdentifier, string captivatingTitle, string enrichingDescription, string publicationDate)
            : base(uniqueIdentifier, captivatingTitle, enrichingDescription) // Call base constructor
        {
            PublicationDate = publicationDate ?? throw new ArgumentNullException(nameof(publicationDate)); // Ensure non-null
        }

        // Override GetHoldingType() to return "Periodical"
        public override string GetHoldingType()
        {
            return "Periodical";
        }

        // Override ToString() to provide a detailed description of the periodical
        public override string ToString()
        {
            return base.ToString() + $"\nType: {GetHoldingType()}\nPublication Date: {PublicationDate}";
        }
    }
    /*---+---+---+--End of Periodical Class Block---+---+---+--*/
}