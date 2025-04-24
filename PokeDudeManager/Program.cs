/*
Name: Irving F. Sanchez  
Course: CPSC-23000-001 .NET Programming  
School: Lewis University, Romeoville, IL  
Purpose: This program allows users to manage their own team of digital companions known as "PokeDudes" using CRUD operations.  
It demonstrates SQL database interaction in a .NET console application, providing an educational, Pokémon-inspired experience.
*/

/*
Note: Inspired by Pokémon and designed for hands-on learning, this app helps reinforce database concepts such as adding, viewing, updating, and deleting records through a text-based menu system.
*/

using System; // Provides core .NET functions like Console
using Microsoft.Data.SqlClient; // For SQL Server connectivity
using PokeDudeManager.Models; // Our PokeDude model
using PokeDudemanager.Data; // Our database helper class
using Figgle; // Library For ASCII art

namespace PokeDudemanager
{
    class Program
    {
        static void Main()
        {
            /*---+---+---+--Start of Connection String Block---+---+---+--*/
            // This connection string points to our SQL Server and database
            string connectionString = "Server=localhost\\SQLEXPRESS;Database=PokeServer;Integrated Security=True;TrustServerCertificate=True;";
            /*---+---+---+--End of Connection String Block---+---+---+--*/


            /*---+---+---+--Start of Welcome Banner Block---+---+---+--*/
            // Render the ASCII art
            string bannerText = "Hello! PokeDude! ";
            string asciiBanner = FiggleFonts.Standard.Render(bannerText);
            int consoleWidth = Console.WindowWidth;

            string[] asciiLines = asciiBanner.Split('\n');
            string[] textLines =
            {
                "Welcome to the PokeDude Network Manager!",
                "This tool helps you manage the PokeDude's you've captured.",
                "Please use the menu to choose what you want to do."
            };

            // Print the border in White
            Console.ForegroundColor = ConsoleColor.White;
            string border = new string('*', consoleWidth - 2);
            Console.WriteLine(border);

            // Print the ASCII art in Red
            Console.ForegroundColor = ConsoleColor.Green;
            foreach (string line in asciiLines)
            {
                PrintCentered(line, consoleWidth);
            }

            // Print the border in White
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(border);

            // Print the welcome message in Blue
            Console.ForegroundColor = ConsoleColor.Blue;
            foreach (string line in textLines)
            {
                PrintCentered(line, consoleWidth);
            }

            // Print the border in White
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(border);

            // Reset the text color to default
            Console.ResetColor();
            /*---+---+---+--End of Welcome Banner Block---+---+---+--*/


            /*---+---+---+--Start of Main Program Loop Block---+---+---+--*/
            // This block contains the main menu and handles user input
            using (PokeDB pokeDB = new PokeDB(connectionString))
            {
                while (true)
                {
                    Console.WriteLine("\nPOKEDUDE NETWORK MANAGER");
                    Console.WriteLine("1. Discover a PokeDude");
                    Console.WriteLine("2. Explore PokeDudes");
                    Console.WriteLine("3. Re-describe a PokeDude");
                    Console.WriteLine("4. Release a PokeDude");
                    Console.WriteLine("5. Reset PokeServer");
                    Console.WriteLine("6. Exit");
                    Console.Write("Choose an action: ");

                    if (!int.TryParse(Console.ReadLine(), out int choice))
                    {
                        Console.WriteLine("⚠️ Please enter a number between 1 and 6.");
                        continue;
                    }

                    switch (choice)
                    {
                        /*---+---+---+--Start of Discover Block (Create)---+---+---+--*/
                        case 1:
                            Console.Write("\nEnter the name of your newly discovered PokeDude (e.g., firedude, chandude): ");
                            string name = Console.ReadLine() ?? string.Empty;
                            Console.Write("Type (e.g., Fighting, Fire, Water, Psychic): ");
                            string type = Console.ReadLine() ?? string.Empty;
                            Console.Write("Gender (e.g., Male or Female): ");
                            string gender = Console.ReadLine() ?? string.Empty;
                            Console.Write("Location (e.g., Mexico City, Detroit, Chicago): ");
                            string location = Console.ReadLine() ?? string.Empty;

                            PokeDude newPokeDude = new PokeDude(name, type, gender, location, DateTime.Now);
                            pokeDB.AddDude(newPokeDude);
                            Console.WriteLine("✅ PokeDude discovered!");
                            break;
                        /*---+---+---+--End of Discover Block---+---+---+--*/


                        /*---+---+---+--Start of Explore Block (Read)---+---+---+--*/
                        case 2:
                            var allPokeDudes = pokeDB.GetAllPokeDudes();
                            if (allPokeDudes.Count == 0)
                            {
                                Console.WriteLine("📭 No PokeDudes found.");
                                break;
                            }
                            foreach (var pokeDude in allPokeDudes)
                            {
                                Console.WriteLine("-------------------");
                                Console.WriteLine($"🆔 ID: {pokeDude.PokeDudeID}");
                                Console.WriteLine($"🧢 Name: {pokeDude.Name}");
                                Console.WriteLine($"🔥 Type: {pokeDude.Type}");
                                Console.WriteLine($"⚧ Gender: {pokeDude.Gender}");
                                Console.WriteLine($"📍 Location: {pokeDude.Location}");
                                Console.WriteLine($"📅 Discovered: {pokeDude.DiscoveryDate:yyyy-MM-dd}");
                            }
                            break;
                        /*---+---+---+--End of Explore Block---+---+---+--*/


                        /*---+---+---+--Start of Update Block---+---+---+--*/
                        case 3:
                            Console.Write("\nEnter ID of the PokeDude to re-describe: ");
                            if (!int.TryParse(Console.ReadLine(), out int updateId))
                            {
                                Console.WriteLine("⚠️ Invalid ID format.");
                                break;
                            }
                            Console.Write("New name: ");
                            name = Console.ReadLine() ?? string.Empty;
                            Console.Write("New type: ");
                            type = Console.ReadLine() ?? string.Empty;
                            Console.Write("New gender: ");
                            gender = Console.ReadLine() ?? string.Empty;
                            Console.Write("New location: ");
                            location = Console.ReadLine() ?? string.Empty;

                            PokeDude updatedPokeDude = new PokeDude(name, type, gender, location, DateTime.Now);
                            if (pokeDB.UpdatePokeDude(updateId, updatedPokeDude))
                                Console.WriteLine("✅ PokeDude updated.");
                            else
                                Console.WriteLine("❌ PokeDude not found.");
                            break;
                        /*---+---+---+--End of Update Block---+---+---+--*/


                        /*---+---+---+--Start of Delete Block (Single)---+---+---+--*/
                        case 4:
                            Console.Write("\nEnter ID of the PokeDude to release: ");
                            if (!int.TryParse(Console.ReadLine(), out int deleteId))
                            {
                                Console.WriteLine("⚠️ Invalid ID format.");
                                break;
                            }
                            if (pokeDB.ReleasePokeDude(deleteId))
                                Console.WriteLine("🕊️ PokeDude released!");
                            else
                                Console.WriteLine("❌ PokeDude not found.");
                            break;
                        /*---+---+---+--End of Delete Block (Single)---+---+---+--*/


                        /*---+---+---+--Start of Delete Block (All)---+---+---+--*/
                        case 5:
                            pokeDB.ReleaseAllPokeDudes();
                            Console.WriteLine("🚨 PokeServer has been reset. All PokeDudes released!");
                            break;
                        /*---+---+---+--End of Delete Block (All)---+---+---+--*/


                        /*---+---+---+--Start of Exit Block---+---+---+--*/
                        case 6:
                            Console.WriteLine("👋 Exiting the PokeDude Network Manager. See ya!\n");
                            Environment.Exit(0);
                            break;
                        /*---+---+---+--End of Exit Block---+---+---+--*/


                        default:
                            Console.WriteLine("❓ Invalid option. Please choose a number from 1 to 6.");
                            break;
                    }

                }
            }


            /*---+---+---+--Start of PrintCentered Method Block---+---+---+--*/
            /// Prints the given text centered within the console window width.
            static void PrintCentered(string text, int width)
            {
                text = text.TrimEnd(); // Remove trailing spaces to ensure clean centering
                int padding = Math.Max((width - text.Length) / 2, 0);
                Console.WriteLine(new string(' ', padding) + text);
            }
            /*---+---+---+--End of PrintCentered Method Block---+---+---+--*/


            /*---+---+---+--End of Main Program Loop Block---+---+---+--*/
        }
    }
}
