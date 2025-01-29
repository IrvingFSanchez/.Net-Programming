/*
Name: Irving F. Sanchez
Course: .NET Programming
School: Lewis University, Romeoville, IL
Purpose: Calculate the volume of a cube and sphere
*/

/*Note: I put a ton of comments in my code for personal use, I add notes to help me understand what
I'm doing and why I'm doing it.I'm not sure if this is a good practice or not, but I'm doing it for now.*/

using System; //Similar to other import statements in other languages this imports the System namespace, which essentially contains fundamental classes and base classes

namespace ShapeCalculator //Defines the name space to organize the code accordingly
{
    class Program //This just defines the main class of the program
    {
        static void Main(string[] args) //The entry point of this program, basically the meat of the code goes inside here
        {


            /*Banner*/
            //Here I will print the heading of the application (what users initially will see) and the initial questions to the user
            string asterisk = "*";
            string text = "Shape Calculator V1.0";
            int bannerWidth = 50; //Sets the total width of the banner i'm trying to make

            string topLine = new string(asterisk[0], bannerWidth); //Creates a string of asterisks that is the same length as the bannerWidth
            int padding = (bannerWidth - text.Length) / 2; //This will calculate the padding needed to ensure the text is centered between the asterisks and looks clean
            string centerText = text.PadLeft(padding + text.Length).PadRight(bannerWidth); //This is going to center the text between the asterisks
            string bottomLine = topLine;

            Console.WriteLine(topLine);
            Console.WriteLine(centerText);
            Console.WriteLine(bottomLine);
            Console.WriteLine();
            /*End Banner*/


            /*Calculating Cube Volume*/
            //Here I will ask the user to enter the dimensions of the cube but also handle invalid inputs
            Console.WriteLine("First, Let's deal with the cube.");
            Console.Write("What is the width?" );
            string widthInput = Console.ReadLine(); //Declares a variable named lengthInput of type string and assigns it the value of the user input

            double width;
            while (!double.TryParse(widthInput, out width)) //To ensure valid inputs this will keep asking user for a valid input until it is properly provided
            {
                Console.WriteLine("Invalid input. Please enter a proper value for the width. ");
                Console.Write("What is the width? ");
                widthInput = Console.ReadLine();
            }

            Console.Write("What is the length? ");
            string lengthInput = Console.ReadLine();

            double length;
            while (!double.TryParse(lengthInput, out length))
            {
                Console.WriteLine("Invalid input. Please enter a proper value for the length. ");
                Console.Write("What is the length? ");
                lengthInput = Console.ReadLine();
            }

            Console.Write("What is the height? ");
            string heightInput = Console.ReadLine();

            double height;
            while (!double.TryParse(heightInput, out height))
            {
                Console.WriteLine("Invalid input. Please enter a proper value for the height. ");
                Console.Write("What is the height? ");
                heightInput = Console.ReadLine();
            }

            double cubeVolume = width * length * height; //variable and calculation to determine the volume of the cube

            Console.WriteLine($"The cube's volume is: {cubeVolume}"); //Prints out the volume of the cube
            Console.WriteLine();
            /*End Calculating Cube Volume*/


            /*Calculating Sphere Volume*/
            //Here I will ask the user to enter the radius of the sphere
            Console.WriteLine("Now, Let's deal with the sphere.");
            Console.WriteLine("What is the radius? ");
            string radiusInput = Console.ReadLine();

            double radius;
            while (!double.TryParse(radiusInput, out radius))
            {
                Console.WriteLine("Invalid input. Please enter a proper value for the radius. ");
                Console.WriteLine("What is the radius? ");
                radiusInput = Console.ReadLine();
            }

            /*Fourth Point*/
            //Here we are going to calculate the volume of the sphere using the formula: volume = 4/3 * pi * radius^3 and then print it out
            double sphereVolume = (4.0 / 3.0) * Math.PI * Math.Pow(radius, 3); //Math.PI is a constant that represents the value of pi and Math.Pow is used to raise a number to a power

            //Here we will display the volume of the sphere while formatting it with 3 decomial places
            Console.WriteLine($"The spheres volume is: {sphereVolume:F3}");
            Console.WriteLine();

            /*Fifth Point*/
            //Here we will calculate the total volume of the cube and sphere
            double totalVolume = cubeVolume + sphereVolume;

            //Here we will display the total volume of the cube and sphere while formatting it with 3 decomial places
            Console.WriteLine($"The total volume of the cube and sphere is: {totalVolume:F3}");
            Console.WriteLine();

            /*Sixth Point*/
            //End Program with a thank you message
            Console.WriteLine("Thank you for using this program.");
            Console.WriteLine();

        }
    }
}
