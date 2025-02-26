/*
Name: Irving F. Sanchez
Course: CPSC-23000-001 .NET Programming 
School: Lewis University, Romeoville, IL
Purpose: This program will implement an object-orientated investment tracker emphasizing encapsulation, inheritance, and polymorphism.
*/

/*
Note: The basis of the program will provide users a way to manage checking accounts and CDs, with features like deposits, withdrawals, auto-adjustments, and account summaries.
*/

// Many of my resources on C# programming come from (https://learn.microsoft.com/en-us/dotnet/csharp/)

using System; // This ensures the importing the System namespace for Console class
using Figgle; // This ensures the importing the Figgle namespace for ASCII art that will represent the banner for this program
using System.Collections.Generic;

namespace InvestmentTracker // Latin for money portfolio; thought it'd be a cool name to use for the namespace and I like using Latin naming conventions
{
    class Program
    {
        static void Main(string[] args)
        {



            /*---+---+---+--Start of Welcome Banner Block---+---+---+--*/
            // In this block, we are using the Figgle library to create an ASCII art banner for this program
            // (https://github.com/drewnoakes/figgle) and (https://learn.microsoft.com/en-us/dotnet/api/system.console.foregroundcolor?view=net-9.0)
            Console.ForegroundColor = ConsoleColor.Cyan;

            string bannerText = "Investment Tracker v1.0";
            string asciiBanner = FiggleFonts.Standard.Render(bannerText);
            int consoleWidth = Console.WindowWidth;

            string[] asciiLines = asciiBanner.Split('\n');
            string[] textLines =
            {
                "Welcome to Investment Tracker v1.0!",
                "This tool will help you manage your investments, both CDs and checking accounts.",
                "CDs accrue interest and checking accounts can have overdraft fees."
            };

            string border = new string('*', consoleWidth - 2);

            Console.WriteLine(border);

            // This will Print ASCII art with centering which is so annoying to do in C# but we got it
            foreach (string line in asciiLines)
            {
                PrintCentered(line, consoleWidth);
            }

            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Yellow;

            Console.WriteLine(border);

            // This will Print additional text with centering
            foreach (string line in textLines)
            {
                PrintCentered(line, consoleWidth);
            }

            Console.WriteLine(border);
            Console.ResetColor();

            /*---+---+---+--End of Welcome Banner Block---+---+---+--*/



            /*---+---+---+--Start of User Input Block---+---+---+--*/
            // In this block, we ask the user for their name and validate the input 
            // (https://learn.microsoft.com/en-us/dotnet/api/system.string.isnullorwhitespace?view=net-9.0) 
            // (https://learn.microsoft.com/en-us/dotnet/api/system.console.readline?view=net-9.0)
            Console.Write("Please enter your name: ");
            string nomenClients = Console.ReadLine() ?? " "; // Nomen clients is Latin for client name

            // Ensure the user doesn't input an empty string or a string with only white spaces
            while (string.IsNullOrWhiteSpace(nomenClients)) // Fixed Typo Here
            {
                Console.WriteLine("Error. Please enter a valid name.");
                Console.Write("Please enter your name: ");
                nomenClients = Console.ReadLine() ?? " ";
            }

            Console.WriteLine($"Welcome {nomenClients}, let's get started!\n");
            /*---+---+---+--End of User Input Block---+---+---+--*/



            /*---+---+---+--Start of Account Creation Block---+---+---+--*/
            // Here we create a checking account and a CD account for the user.
            Console.WriteLine("At this bank, you have one checking account and one CD account.");
            Console.WriteLine("Let's start by creating your checking account.\n");



            /*---+---+---+--Checking Account Creation Block---+---+---+--*/
            Console.WriteLine("Checking Account Creation: ");

            // Here we ask for Checking Account ID
            Console.Write("Please enter your checking account ID: ");
            string checkingID = Console.ReadLine() ?? " ";

            // Ensure the user doesn't input an empty string or a string with only white spaces
            while (string.IsNullOrWhiteSpace(checkingID))
            {
                Console.WriteLine("Error. Account ID can't be empty.");
                Console.Write("Enter the account ID: ");
                checkingID = Console.ReadLine() ?? " ";
            }

            // Here we ask when the account was opened. 
            Console.Write("Please enter the date the account was opened in the format (MM/DD/YYYY): ");
            DateTime checkingDateOpened;
            while (!DateTime.TryParse(Console.ReadLine(), out checkingDateOpened))
            {
                Console.WriteLine("Error. Please enter a valid date (MM/DD/YYYY).");
                Console.Write("Enter the date the account was opened: ");
            }

            // Here we ask for the starting balance of the checking account
            Console.Write("Please enter the starting balance of the checking account: ");
            double checkingBalance;
            while (!double.TryParse(Console.ReadLine(), out checkingBalance) || checkingBalance < 0)
            {
                Console.WriteLine("Error. Please enter a valid balance.");
                Console.Write("Enter the starting balance for the checking account: ");
            }

            // Here we create a checking account object
            // RatioChecking is essentially latin "ratio" for checking
            Console.WriteLine("Checking account created successfully!\n");
            RatioChecking checkingAccount = new RatioChecking(nomenClients, checkingID, checkingDateOpened, checkingBalance);
            Console.WriteLine("Checking account created successfully!\n");

            // We want to check for overdraft fees for the checking account
            if (checkingAccount.Balantia < 0)
            {
                Console.WriteLine("Ouch! Your checking account balance is negative. An overdraft fee will be applied.");
            }
            /*---+---+---+--End of Checking Account Creation Block---+---+---+--*/



            /*---+---+---+--CD Account Creation Block---+---+---+--*/
            Console.WriteLine("Now, let's create your CD Account. ");

            // Here we ask for CD Account ID
            Console.Write("Please enter your CD account ID: ");
            string cdID = Console.ReadLine() ?? " ";

            // Ensure the user doesn't input an empty string or a string with only white spaces
            while (string.IsNullOrWhiteSpace(cdID))
            {
                Console.WriteLine("Error. Account ID can't be empty.");
                Console.Write("Enter the account ID: ");
                cdID = Console.ReadLine() ?? " ";
            }

            // Here we ask when the account was opened.
            Console.Write("Please enter the date the account was opened in the format (MM/DD/YYYY): ");
            DateTime cdDateOpened;
            while (!DateTime.TryParse(Console.ReadLine(), out cdDateOpened))
            {
                Console.WriteLine("Error. Please enter a valid date (MM/DD/YYYY).");
                Console.Write("Enter the date the account was opened: ");
            }

            // Here we ask for the starting balance of the CD account
            Console.Write("Please enter the starting balance of the CD account: ");
            double cdBalance;
            while (!double.TryParse(Console.ReadLine(), out cdBalance) || cdBalance < 0)
            {
                Console.WriteLine("Error. Please enter a valid balance.");
                Console.Write("Enter the starting balance for the CD account: ");
            }

            // Here we ask for the interest rate of the CD account
            Console.Write("Please enter the interest rate for the CD account (e.g., 0.09 for 9%): ");
            double interestRate;
            while (!double.TryParse(Console.ReadLine(), out interestRate) || interestRate < 0)
            {
                Console.WriteLine("Error. Please enter a valid interest rate.");
                Console.Write("Enter the interest rate for the CD account (e.g., 0.09 for 9%): ");
            }

            // Here we create a CD account object
            // CertificatumDepositi is essentially latin "certificatum" for certificate and "depositi" for deposit
            CertificatumDepositi cdAccount = new CertificatumDepositi(nomenClients, cdID, cdDateOpened, cdBalance, interestRate);
            Console.WriteLine("CD account created successfully!\n");

            /*---+---+---+--End of CD Account Creation Block---+---+---+--*/



            /*---+---+---+--Start of Menu Block---+---+---+--*/
            // In this block, we will display the menu options for the user to interact with their accounts (pretty much used from my last project ADHDPlanner)
            List<Investimentum> accounts = new List<Investimentum> { checkingAccount, cdAccount }; // Here I want to store accounts in a list for polymorphism

            bool exitProgram = false;
            while (!exitProgram) // Funny wording for while we don't exit the program lol
            {
                Console.WriteLine("\nPlease select an option from the menu below: ");
                Console.WriteLine("1. Deposit to Checking Account");
                Console.WriteLine("2. Withdraw from Checking Account");
                Console.WriteLine("3. Auto-Adjust Accounts");
                Console.WriteLine("4. View Account Summaries");
                Console.WriteLine("5. Exit Program");

                Console.Write("Enter your choice: ");
                string choice = Console.ReadLine() ?? " ";

                switch (choice)
                {
                    case "1":
                        Console.Write("Enter the amount you'd like to deposit (##.##): ");
                        double depositAmount;
                        while (!double.TryParse(Console.ReadLine(), out depositAmount) || depositAmount < 0)

                        {
                            Console.WriteLine("Error. Please enter a valid deposit amount.");
                            Console.Write("Enter the amount you'd like to deposit: ");
                        }
                        checkingAccount.Deponere(depositAmount);
                        break;

                    case "2":
                        Console.Write("Enter the amount you'd like to withdraw (##.##): ");
                        double withdrawAmount;
                        while (!double.TryParse(Console.ReadLine(), out withdrawAmount) || withdrawAmount < 0)
                        {
                            Console.WriteLine("Error. Please enter a valid withdrawal amount.");
                            Console.Write("Enter the amount you'd like to withdraw: ");
                        }
                        checkingAccount.Retrahere(withdrawAmount);
                        break;

                    case "3":
                        // Here we want to auto-adjust the accounts which is super cool and an implementation of seeing (Polymorphism) in action
                        Console.WriteLine("Auto-Adjust Accounts for your Accounts: ");
                        foreach (var account in accounts)
                        {
                            account.AutoAdepto(); // This is Latin for auto-adjust and here Polymorphism calls AutoAdepto method based on account type
                        }
                        Console.WriteLine("Accounts auto-adjusted successfully!");
                        break;

                    case "4":
                        // Here we want to view account summaries for the user
                        Console.WriteLine("Account Summaries: ");
                        foreach (var account in accounts)
                        {
                            Console.WriteLine(account.ToString()); // Here we call the ToString method for each account in the list
                        }
                        break;

                    case "5":
                        // Here we want to exit the program
                        exitProgram = true;
                        Console.WriteLine("\nThank you for using Investment Tracker v1.0. Goodbye!");
                        break;

                    default:
                        // Here we want to handle invalid input from the user
                        Console.WriteLine("Error. Please enter a valid choice (1-5).");
                        break;
                }
            }
            /*---+---+---+--End of Menu Block---+---+---+--*/



        }

        /// Prints the given text centered within the console window width.
        static void PrintCentered(string text, int width)
        {
            text = text.TrimEnd(); // Remove trailing spaces to ensure clean centering
            int padding = Math.Max((width - text.Length) / 2, 0);
            Console.WriteLine(new string(' ', padding) + text);
        }
    }
}
