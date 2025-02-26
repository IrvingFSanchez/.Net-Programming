/*
Name: Irving F. Sanchez
Course: CPSC-23000-001 .NET Programming 
School: Lewis University, Romeoville, IL
Purpose: This program will implement an object-orientated investment tracker emphasizing encapsulation, inheritance, and polymorphism.
*/

/*
Note: This class represents a Certificate of Deposit (CD) account with the intrest rate
*/

using System;

namespace InvestmentTracker

{
    public class CertificatumDepositi : Investimentum
    {
        public double InterestRate { get; }

        public CertificatumDepositi(string nomenClientis, string id, DateTime diesApertus, double balantia, double interestRate) : base(nomenClientis, id, diesApertus, balantia)
        {
            if (interestRate < 0)
                throw new ArgumentException("Interest rate cannot be negative.", nameof(interestRate));

            InterestRate = interestRate;
        }

        public override void AutoAdepto()
        {
            double usura = Balantia * InterestRate; // usuera is latin for interest
            Balantia += usura;
            Console.WriteLine($"Interest of {usura:C} added. New balance: {Balantia:C}");
        }

        public override string ToString()
        {
            return $"{base.ToString()}, Interest Rate: {InterestRate:P}";
        }
    }
}