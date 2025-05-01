/*
Name: Irving F. Sanchez
Course: CPSC-23000-001 .NET Programming
School: Lewis University, Romeoville, IL
Purpose: This class defines the Entity Framework Core DbContext for the PokeDudesApp project.
It configures the database connection and exposes DbSet properties for PokeDude and PokePal entities.
*/

using Microsoft.EntityFrameworkCore;
using PokeDudesApp.Models;

/*---+---+---+--Start of DbContext Block---+---+---+--*/
// PokeDbContext is the central class that manages database access for the PokeDudesApp.
// It inherits from EF Core's DbContext and defines the schema and connection for our database.
public class PokeDbContext : DbContext
{
    // DbSet for PokeDudes table (represents trainers)
    public DbSet<PokeDude> PokeDudes { get; set; }

    // DbSet for PokePals table (represents Pokémon)
    public DbSet<PokePal> PokePals { get; set; }

    // This method configures the connection string to use SQL Server LocalDB
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=PokeDb;Trusted_Connection=True;");
    }
}
/*---+---+---+--End of DbContext Block---+---+---+--*/
