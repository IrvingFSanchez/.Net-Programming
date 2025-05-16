/*
================================================================================
Name: Irving F. Sanchez
Course: CPSC-23000-001 .NET Programming
School: Lewis University, Romeoville, IL
Purpose: Temperature conversion model for ASP.NET Core MVC.
Handles Celsius/Fahrenheit conversions, validation, and rounding.
================================================================================
*/

using System;

namespace TempConverter.Models
{
    /*---+---+---+--Start of Temperature Class Block---+---+---+--*/
    public class Temperature
    {
        /*---+---+---+--Start of Properties Block---+---+---+--*/
        // The numerical temperature value (e.g., 32, -40, 98.6)
        public double Value { get; set; }

        // Temperature scale ("C" for Celsius (default) or "F" for Fahrenheit)
        public string Scale { get; set; } = "C";
        /*---+---+---+--End of Properties Block---+---+---+--*/


        /*---+---+---+--Start of Conversion Logic Block---+---+---+--*/
        // This converts between Celsius and Fahrenheit, rounding to 3 decimal places
        public double Convert()
        {
            if (Scale == "C")
            {
                // Celsius → Fahrenheit: (C × 9/5) + 32
                return Math.Round((Value * 9 / 5) + 32, 3);
            }
            else
            {
                // Fahrenheit → Celsius: (F − 32) × 5/9
                return Math.Round((Value - 32) * 5 / 9, 3);
            }
        }
        /*---+---+---+--End of Conversion Logic Block---+---+---+--*/


        /*---+---+---+--Start of Validation Logic Block---+---+---+--*/
        // Checks if:
        // 1. Value is a valid number (not NaN)
        // 2. Scale is "C" or "F"
        public bool IsValid()
        {
            return !double.IsNaN(Value) && (Scale == "C" || Scale == "F");
        }
        /*---+---+---+--End of Validation Logic Block---+---+---+--*/
    }
    /*---+---+---+--End of Temperature Class Block---+---+---+--*/
}