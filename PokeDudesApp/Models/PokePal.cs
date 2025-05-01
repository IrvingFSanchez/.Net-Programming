/*
Name: Irving F. Sanchez
Course: CPSC-23000-001 .NET Programming
School: Lewis University, Romeoville, IL
Purpose: This class defines the PokePal model, representing an individual Pokémon in the EF Core database.
Each PokePal is associated with one PokeDude (trainer), forming a many-to-one relationship.
*/

namespace PokeDudesApp.Models
{
    /*---+---+---+--Start of PokePal Model Block---+---+---+--*/
    // PokePal class represents a single Pokémon with attributes like name, type, level, and its trainer ID.
    public class PokePal
    {
        public int PokePalId { get; set; } // Primary key

        public string? Name { get; set; } // Name of the Pokémon (e.g., Pikachu)

        public string? Type { get; set; } // Element type (e.g., Fire, Water, Electric)

        public int Level { get; set; } // Power level of the Pokémon

        public int PokeDudeId { get; set; } // Foreign key to link to its trainer

        public PokeDude? PokeDude { get; set; } // Navigation property (many-to-one)
    }
    /*---+---+---+--End of PokePal Model Block---+---+---+--*/
}
