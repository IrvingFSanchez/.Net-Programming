/*
Name: Irving F. Sanchez
Course: CPSC-23000-001 .NET Programming
School: Lewis University, Romeoville, IL
Purpose: This class defines the PokeDude model, representing a Pokémon trainer in the EF Core database.
Each trainer may have multiple PokePals (Pokémon), forming a one-to-many relationship.
*/

namespace PokeDudesApp.Models
{
    /*---+---+---+--Start of PokeDude Model Block---+---+---+--*/
    // PokeDude class represents a trainer who owns a collection of PokePals.
    public class PokeDude
    {
        public int PokeDudeId { get; set; } // Primary key

        public string? Name { get; set; } // Nickname or trainer's first name (e.g., Ash)

        public string? TrainerName { get; set; } // Full name or display name (e.g., Ash Musturd)

        public int ExperienceYears { get; set; } // Number of years the trainer has been training Pokémon

        public List<PokePal> PokePals { get; set; } = new(); // Navigation property (1-to-many relationship)
    }
    /*---+---+---+--End of PokeDude Model Block---+---+---+--*/
}
