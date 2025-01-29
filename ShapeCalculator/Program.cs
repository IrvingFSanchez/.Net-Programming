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

            /*First Point*/
            //Here I will print the heading of the application (what users initially will see)
            Console.WriteLine("------------------------");//Console.Write is similar to print in a lot of other languages
            Console.WriteLine("Shape Volume Calculator V1.0"); //Prints out the title of the program
            Console.WriteLine("------------------------");
            Console.WriteLine(); //Prints out a blank line

            //Here I will ask the user to enter the dimensions of the cube
            Console.WriteLine("First, Let's deal with the cube.");
            Console.Write("What is the width?" );
            double width = double.Parse(Console.ReadLine());//Double declaries variable named width of type double (like a # w/ decimal). double.parse converts string into a double

            Console.Write("What is the length? ");
            double length = double.Parse(Console.ReadLine());

            Console.Write("What is the height? ");
            double height = double.Parse(Console.ReadLine());

            /*Second Point*/
            //Here we are going to calculate the volume of the cube using the formula: volume = width * length * height and then print it out
            double cubeVolume = width * length * height;

            //Here we will display the volume of the cube while formatting it with 3 decomial places
            Console.WriteLine($"The cubes volume is: {cubeVolume:F3}"); //The F3 formats the # to 3 decimal places and $ before the string is used to insert the value of the variable cubeVolume
            Console.WriteLine();

            /*Third Point*/
            //Here I will ask the user to enter the radius of the sphere
            Console.WriteLine("Now, Let's deal with the sphere.");
            Console.WriteLine("What is the radius? ");
            double radius = double.Parse(Console.ReadLine());

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
            Console.WriteLine("Thank you for using this program.") ;


        }
    }
}
