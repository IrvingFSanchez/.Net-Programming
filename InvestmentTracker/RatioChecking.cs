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

using System;

namespace InvestmentTracker
{
    public class RatioChecking : Investimentum
    {

        private const double PoenaOverdraft = 25.00;

        public RatioChecking(string nomenClientis, string id, DateTime diesApertus, double balantia) : base(nomenClientis, id, diesApertus, balantia)
        { // NOTE: I looked this up and I don't understand why the double curly brackets are here with nothing in them. If you see this, could you answer this question for me?
        } // This was weird.

        public void Deponere(double quantitas)
        {
            if (quantitas > 0)
            {
                Balantia += quantitas;
                Console.WriteLine($"Deposited {quantitas:C}. New balance: {Balantia:C}");
            }
            else
            {
                Console.WriteLine("Deposit amount must be greater than zero.");
            }
        }

        public void Retrahere(double quantitas)
        {
            if (quantitas > 0 && quantitas <= Balantia)
            {
                Balantia -= quantitas;
                Console.WriteLine($"Withdrawal of {quantitas:C} successful. New balance: {Balantia:C}");
            }
            else if (quantitas > Balantia)
            {
                Balantia -= (quantitas + PoenaOverdraft);
                Console.WriteLine($"Overdraft! {PoenaOverdraft:C} fee charged. New balance: {Balantia:C}");
            }
            else
            {
                Console.WriteLine("Withdrawal amount must be greater than zero and less than or equal to the balance.");
            }
        }

        public override void AutoAdepto()
        {
            if (Balantia < 0)
            {
                Balantia -= PoenaOverdraft;
                Console.WriteLine($"Overdraft! {PoenaOverdraft:C} fee charged. New balance: {Balantia:C}");
            }
            else 
            {
                Console.WriteLine("No overdraft fee applied. Balance is positive.");
            }
        }

    }
}