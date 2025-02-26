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
    public class Investimentum
    {

        public string NomenClientis { get; private set; }
        public string Id { get; private set; }
        public DateTime DiesApertus { get; private set; }
        public double Balantia { get; protected set; }

        public Investimentum(string nomenClientis, string id, DateTime diesApertus, double balantia)
        {
            if (string.IsNullOrWhiteSpace(nomenClientis))
                throw new ArgumentException("Client name cannot be null or empty.", nameof(nomenClientis));
            if (string.IsNullOrWhiteSpace(id))
                throw new ArgumentException("Account ID cannot be null or empty.", nameof(id));
            if (balantia < 0)
                throw new ArgumentException("Balance cannot be negative.", nameof(balantia));

            NomenClientis = nomenClientis;
            Id = id;
            DiesApertus = diesApertus;
            Balantia = balantia;
        }

        public virtual void AutoAdepto()
        {
            Console.WriteLine("AutoAdepto in Investimentum");
        }

        public override string ToString()
        {
            return $"Client Name: {NomenClientis}, ID: {Id}, Date Acct. Created: {DiesApertus.ToShortDateString()}, Balance: {Balantia:C}";
        }

    }
}