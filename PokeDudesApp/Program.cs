/*
Name: Irving F. Sanchez
Course: CPSC-23000-001 .NET Programming
School: Lewis University, Romeoville, IL
Purpose: A console-based Pokémon trainer and Pokémon management simulation built using Entity Framework Core.
This application demonstrates database modeling, migrations, async LINQ queries, and development best practices.
*/

using Microsoft.EntityFrameworkCore;
using PokeDudesApp.Models;

internal class Program
{
    private static async Task Main(string[] args)
    {
        using var context = new PokeDbContext();

        /*---+---+---+--Start of Seeding Block---+---+---+--*/
        // If no trainers exist in the database, populate it with default data (Ash, Misty, and their PokePals).
        if (!await context.PokeDudes.AnyAsync())
        {
            var ash = new PokeDude { Name = "Ash", TrainerName = "Ash Musturd", ExperienceYears = 3 };
            var misty = new PokeDude { Name = "Misty", TrainerName = "Misty Williams", ExperienceYears = 2 };

            // Add sample Pokémon for each trainer
            context.PokePals.AddRange(
                new PokePal { Name = "Pikachu", Type = "Electric", Level = 25, PokeDude = ash },
                new PokePal { Name = "Charizard", Type = "Fire", Level = 50, PokeDude = ash },
                new PokePal { Name = "Starmie", Type = "Water", Level = 30, PokeDude = misty },
                new PokePal { Name = "Gyarados", Type = "Water", Level = 45, PokeDude = misty },
                new PokePal { Name = "Bulbasaur", Type = "Grass", Level = 20, PokeDude = ash },
                new PokePal { Name = "Squirtle", Type = "Water", Level = 15, PokeDude = misty },
                new PokePal { Name = "Jigglypuff", Type = "Normal", Level = 10, PokeDude = ash },
                new PokePal { Name = "Meowth", Type = "Normal", Level = 12, PokeDude = misty },
                new PokePal { Name = "Pidgey", Type = "Flying", Level = 18, PokeDude = ash },
                new PokePal { Name = "Psyduck", Type = "Water", Level = 22, PokeDude = misty },
                new PokePal { Name = "Onix", Type = "Rock", Level = 35, PokeDude = ash },
                new PokePal { Name = "Goldeen", Type = "Water", Level = 28, PokeDude = misty },
                new PokePal { Name = "Snorlax", Type = "Normal", Level = 40, PokeDude = ash },
                new PokePal { Name = "Lapras", Type = "Water", Level = 50, PokeDude = misty },
                new PokePal { Name = "Machamp", Type = "Fighting", Level = 45, PokeDude = ash },
                new PokePal { Name = "Golem", Type = "Rock", Level = 55, PokeDude = misty },
                new PokePal { Name = "Gengar", Type = "Ghost", Level = 60, PokeDude = ash },
                new PokePal { Name = "Haunter", Type = "Ghost", Level = 50, PokeDude = misty },
                new PokePal { Name = "Ditto", Type = "Normal", Level = 30, PokeDude = ash },
                new PokePal { Name = "Eevee", Type = "Normal", Level = 20, PokeDude = misty },
                new PokePal { Name = "Mewtwo", Type = "Psychic", Level = 70, PokeDude = ash },
                new PokePal { Name = "Gardevoir", Type = "Psychic", Level = 65, PokeDude = misty },
                new PokePal { Name = "Lucario", Type = "Fighting", Level = 55, PokeDude = ash },
                new PokePal { Name = "Togekiss", Type = "Fairy", Level = 50, PokeDude = misty },
                new PokePal { Name = "Dragonite", Type = "Dragon", Level = 80, PokeDude = ash },
                new PokePal { Name = "Gardevoir", Type = "Psychic", Level = 65, PokeDude = misty },
                new PokePal { Name = "Scyther", Type = "Bug", Level = 40, PokeDude = ash },
                new PokePal { Name = "Tyranitar", Type = "Rock", Level = 75, PokeDude = misty },
                new PokePal { Name = "Zapdos", Type = "Electric", Level = 90, PokeDude = ash },
                new PokePal { Name = "Articuno", Type = "Ice", Level = 85, PokeDude = misty }
            );

            await context.SaveChangesAsync();
        }
        /*---+---+---+--End of Seeding Block---+---+---+--*/

        /*---+---+---+--Start of Queries Block---+---+---+--*/

        // Query 1: Retrieve all trainers
        var allDudes = await context.PokeDudes.ToListAsync();
        Console.WriteLine("All PokeDudes:");
        allDudes.ForEach(d => Console.WriteLine($"{d.Name} - {d.TrainerName}"));

        // Query 2: Ask user how many Pokémon to display
        Console.Write("\nHow many PokePals to retrieve? ");
        if (int.TryParse(Console.ReadLine(), out int num))
        {
            var somePals = await context.PokePals.Take(num).ToListAsync();
            Console.WriteLine($"First {num} PokePals:");
            somePals.ForEach(p => Console.WriteLine($"{p.Name} ({p.Type})"));
        }

        // Query 3: Find first Ghost-type Pokémon
        var firstGhostPal = await context.PokePals.FirstOrDefaultAsync(p => p.Type == "Ghost");
        Console.WriteLine("\nFirst Ghost-type PokePal:");
        Console.WriteLine(firstGhostPal?.Name ?? "No Ghost-types found.");

        // Query 4: Sort Pokémon by level ascending and name descending
        var sortedPals = await context.PokePals.OrderBy(p => p.Level).ThenByDescending(p => p.Name).ToListAsync();
        Console.WriteLine("\nPokePals sorted by Level (asc) and Name (desc):");
        sortedPals.ForEach(p => Console.WriteLine($"{p.Name} (Lvl: {p.Level})"));

        // Query 5: Filter strong Water-type Pokémon (Level > 30)
        var strongWaterPals = await context.PokePals
            .Where(p => p.Type == "Water" && p.Level > 30)
            .Select(p => new { p.Name, p.Type, p.Level })
            .ToListAsync();
        Console.WriteLine("\nStrong Water-type PokePals (Level > 30):");
        strongWaterPals.ForEach(p => Console.WriteLine($"{p.Name} ({p.Type}, Lvl: {p.Level})"));

        // Query 6: Join PokeDudes with PokePals and display trainer + Pokémon info
        var teamData = await context.PokeDudes
            .SelectMany(d => d.PokePals, (d, p) => new { Trainer = d.TrainerName, PalName = p.Name, Type = p.Type })
            .OrderBy(t => t.Trainer)
            .ToListAsync();
        Console.WriteLine("\nTrainers and their PokePals (sorted by Trainer):");
        teamData.ForEach(t => Console.WriteLine($"{t.Trainer} -> {t.PalName} ({t.Type})"));

        // Query 7: Group Pokémon by Type and return average level
        var avgLevelByType = await context.PokePals
            .GroupBy(p => p.Type)
            .Select(g => new { Type = g.Key, AvgLevel = g.Average(p => p.Level) })
            .ToListAsync();
        Console.WriteLine("\nAverage Level by Type:");
        avgLevelByType.ForEach(x => Console.WriteLine($"{x.Type}: {x.AvgLevel:F1}"));

        // Query 8: Custom - Count of Pokémon and strongest per trainer
        var palsPerTrainer = await context.PokeDudes
            .Select(d => new
            {
                Trainer = d.TrainerName,
                PalCount = d.PokePals.Count,
                StrongestLevel = d.PokePals.Max(p => p.Level)
            })
            .ToListAsync();
        Console.WriteLine("\nPokePals per Trainer (with strongest level):");
        palsPerTrainer.ForEach(t => Console.WriteLine($"{t.Trainer}: {t.PalCount} Pals, Strongest: Lvl {t.StrongestLevel}"));

        /*---+---+---+--End of Queries Block---+---+---+--*/
    }
}
