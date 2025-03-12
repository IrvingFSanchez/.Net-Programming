/*
Name: Irving F. Sanchez
Course: CPSC-23000-001 .NET Programming 
School: Lewis University, Romeoville, IL
Purpose: The main program for the Library Management System. It tests the Holding, Book, Periodical, Library, and HoldingsWriter classes.
*/

using System;
using Figgle; // Library For ASCII art

namespace LibraryManagementSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            /*---+---+---+--Start of Welcome Banner Block---+---+---+--*/
            // Render the ASCII art
            string bannerText = "Library Management System v1.0";
            string asciiBanner = FiggleFonts.Standard.Render(bannerText);
            int consoleWidth = Console.WindowWidth;

            string[] asciiLines = asciiBanner.Split('\n');
            string[] textLines =
            {
                "Welcome to Library Management System v1.0!",
                "This tool helps you manage a library's collections.",
                "Please use the menu to choose what you want to do."
            };

            // Print the border in White
            Console.ForegroundColor = ConsoleColor.White;
            string border = new string('*', consoleWidth - 2);
            Console.WriteLine(border);

            // Print the ASCII art in Red
            Console.ForegroundColor = ConsoleColor.Magenta;
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

            // Create a library instance
            Library library = new Library();

            // Main menu loop
            bool exitProgram = false;
            while (!exitProgram)
            {
                /*---+---+---+--Start of Menu Block---+---+---+--*/
                Console.WriteLine("\nPlease select an option from the menu below:");
                Console.WriteLine("1. List holdings");
                Console.WriteLine("2. Add a book");
                Console.WriteLine("3. Add a periodical");
                Console.WriteLine("4. Reserve a holding");
                Console.WriteLine("5. Return a holding");
                Console.WriteLine("6. See statistics");
                Console.WriteLine("7. Save library");
                Console.WriteLine("8. Load library");
                Console.WriteLine("9. Quit");

                Console.Write("Enter the number of your choice: ");
                string? choice = Console.ReadLine();

                switch (choice)
                {
                    case "1": // List holdings
                        library.ListAll();
                        break;

                    case "2": // Add a book
                        AddBook(library);
                        break;

                    case "3": // Add a periodical
                        AddPeriodical(library);
                        break;

                    case "4": // Reserve a holding
                        ReserveHolding(library);
                        break;

                    case "5": // Return a holding
                        ReturnHolding(library);
                        break;

                    case "6": // See statistics
                        var stats = library.GetStats();
                        Console.WriteLine($"\n📊 Library Statistics:\nAvailable: {stats.Available}\nChecked Out: {stats.CheckedOut}");
                        break;

                    case "7": // Save library
                        Console.Write("Enter the file path to save to: ");
                        string? saveFilePath = Console.ReadLine();
                        if (!string.IsNullOrWhiteSpace(saveFilePath))
                        {
                            library.SaveToFile(saveFilePath);
                        }
                        else
                        {
                            Console.WriteLine("Invalid file path.");
                        }
                        break;

                    case "8": // Load library
                        Console.Write("Enter the file path to load from: ");
                        string? loadFilePath = Console.ReadLine();
                        if (!string.IsNullOrWhiteSpace(loadFilePath))
                        {
                            library.LoadFromFile(loadFilePath);
                        }
                        else
                        {
                            Console.WriteLine("Invalid file path.");
                        }
                        break;

                    case "9": // Quit
                        exitProgram = true;
                        Console.WriteLine("\nThank you for using the Library Management System. Goodbye!");
                        break;

                    default:
                        Console.WriteLine("Invalid choice. Please enter a number between 1 and 9.");
                        break;
                }
                /*---+---+---+--End of Menu Block---+---+---+--*/
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

        /*---+---+---+--Start of AddBook Method Block---+---+---+--*/
        /// Helper method to add a book to the library
        static void AddBook(Library library)
        {
            Console.Write("Enter ID Number: ");
            string? idInput = Console.ReadLine();
            if (!int.TryParse(idInput, out int id))
            {
                Console.WriteLine("Invalid ID. Please enter a valid number.");
                return;
            }

            Console.Write("Enter Title: ");
            string? title = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(title))
            {
                Console.WriteLine("Title cannot be empty.");
                return;
            }

            Console.Write("Enter Description: ");
            string? description = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(description))
            {
                Console.WriteLine("Description cannot be empty.");
                return;
            }

            Console.Write("Enter Copyright Year: ");
            string? yearInput = Console.ReadLine();
            if (!int.TryParse(yearInput, out int year) || year < 1800 || year > 2025)
            {
                Console.WriteLine("Invalid year. Please enter a year between 1800 and 2025.");
                return;
            }

            Console.Write("Enter Author: ");
            string? author = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(author))
            {
                Console.WriteLine("Author cannot be empty.");
                return;
            }

            Book book = new Book(id, title, description, year, author);
            library.AddHolding(book);
        }
        /*---+---+---+--End of AddBook Method Block---+---+---+--*/

        /*---+---+---+--Start of AddPeriodical Method Block---+---+---+--*/
        /// Helper method to add a periodical to the library
        static void AddPeriodical(Library library)
        {
            Console.Write("Enter ID Number: ");
            string? idInput = Console.ReadLine();
            if (!int.TryParse(idInput, out int id))
            {
                Console.WriteLine("Invalid ID. Please enter a valid number.");
                return;
            }

            Console.Write("Enter Title: ");
            string? title = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(title))
            {
                Console.WriteLine("Title cannot be empty.");
                return;
            }

            Console.Write("Enter Description: ");
            string? description = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(description))
            {
                Console.WriteLine("Description cannot be empty.");
                return;
            }

            Console.Write("Enter Publication Date: ");
            string? date = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(date))
            {
                Console.WriteLine("Publication date cannot be empty.");
                return;
            }

            Periodical periodical = new Periodical(id, title, description, date);
            library.AddHolding(periodical);
        }
        /*---+---+---+--End of AddPeriodical Method Block---+---+---+--*/

        /*---+---+---+--Start of ReserveHolding Method Block---+---+---+--*/
        /// Helper method to reserve a holding
        static void ReserveHolding(Library library)
        {
            Console.Write("Enter the ID Number of the holding to reserve: ");
            string? idInput = Console.ReadLine();
            if (!int.TryParse(idInput, out int id))
            {
                Console.WriteLine("Invalid ID. Please enter a valid number.");
                return;
            }

            if (library.CheckOut(id))
            {
                Console.WriteLine("Holding has been checked out.");
            }
            else
            {
                Console.WriteLine("Unable to check out the holding. It may already be checked out or not found.");
            }
        }
        /*---+---+---+--End of ReserveHolding Method Block---+---+---+--*/

        /*---+---+---+--Start of ReturnHolding Method Block---+---+---+--*/
        /// Helper method to return a holding
        static void ReturnHolding(Library library)
        {
            Console.Write("Enter the ID Number of the holding to return: ");
            string? idInput = Console.ReadLine();
            if (!int.TryParse(idInput, out int id))
            {
                Console.WriteLine("Invalid ID. Please enter a valid number.");
                return;
            }

            if (library.CheckIn(id))
            {
                Console.WriteLine("Holding has been checked in.");
            }
            else
            {
                Console.WriteLine("Unable to check in the holding. It may already be checked in or not found.");
            }
        }
        /*---+---+---+--End of ReturnHolding Method Block---+---+---+--*/
    }
}

//Uh....why is my project not pushing to GitHub? I'm not sure what's going on. I'm going to try to push it again.