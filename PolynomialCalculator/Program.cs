/*
Name: Irving F. Sanchez
Course: CPSC-23000-001 .NET Programming 
School: Lewis University, Romeoville, IL
Purpose: Polynomial Calculator -- Calculates the values of polynomial functions of up to degree 3 over a specified domain
*/

/*Note: I put a ton of comments in my code for personal use, I add notes to help me understand what
I'm doing and why I'm doing it.I'm not sure if this is a good practice or not, but I'm doing it for now.*/

/*SIDENOTE: I copied some blocks of code from my ShapeCalculator project, I did this because I wanted to keep the same style of coding and I wanted to save time.*/

using System; //Similar to other import statements in other languages this imports the System namespace, which essentially contains fundamental classes and base classes

namespace PolynomialCalculator
{
    class Program
    {
        static void Main(string[] args)
        {


            /*---+---+---+--Banner Block---+---+---+--*/
            //Format Copied from my last assignment (ShapeCalculator)
            string asterisk = "*";
            string text = "Polynomial Calculator V1.0";
            int bannerWidth = 65; //Sets the total width of the banner i'm trying to make

            string topLine = new string(asterisk[0], bannerWidth); //Creates a string of asterisks that is the same length as the bannerWidth
            int padding = (bannerWidth - text.Length) / 2; //This will calculate the padding needed to ensure the text is centered between the asterisks and looks clean
            string centerText = text.PadLeft(padding + text.Length).PadRight(bannerWidth); //This is going to center the text between the asterisks
            string bottomLine = topLine;

            Console.WriteLine(topLine);
            Console.WriteLine(centerText);
            Console.WriteLine(bottomLine);
            Console.WriteLine();            
            /*---+---+---+--End of Banner Block---+---+---+--*/


            /*---+---+---+--Start of Description Block---+---+---+--*/
            string description = "This tool helps you calculate the values of cubic,quadratic, linear,and constant polynomials over a specified domain. You will enter the coefficients of the polynomial along with the min and max x-values of the domain. The tool will then calculate the values of the polynomial over the domain.";
            // This will wrap the description to fit within the banner width--giving more control over the look of the description
            string[] wrappedDescription = WrapText(description, bannerWidth);

            foreach (string line in wrappedDescription)
            {
                Console.WriteLine(line);
            }
            Console.WriteLine();
            /*---+---+---+--End of Description Block---+---+---+--*/



            /*---+---+---+--Start of WrapText Method Block---+---+---+--*/
            // This method is used to wrap text to fit within a specified width
            static string[] WrapText(string text, int width)
            //There has got to be a better way to format this description.......DR. KLUMP if you see this could you suggest a better way to format paragraphs
            {
                string[] words = text.Split(' ');
                string line = "";
                System.Collections.Generic.List<string> lines = new System.Collections.Generic.List<string>();

                foreach (string word in words)
                {
                    if ((line + word).Length > width)
                    {
                        lines.Add(line.Trim());
                        line = "";
                    }
                    line += word + " ";
                }
                if (!string.IsNullOrEmpty(line))
                {
                    lines.Add(line.Trim());
                }
                return lines.ToArray();
            }
            /*---+---+---+--End of WrapText Method Block---+---+---+--*/



            /*---+---+---+--Start of Main Loop Block---+---+---+--*/
            int polyNumero = 1; // Here I'm just tracking the number of polynomials entered
            bool perseverareCalculating = true; // Just tells whether the program will cointinue to run or not

            // Main Loop: Here we keep running until the user decides to stop
            while (perseverareCalculating)
            {
                Console.WriteLine($"Please enter the details for the polynomial number {polyNumero}."); // Just a prompt to the user

                // Here we need to get the degree of the polynomial
                int degree = GetDegree();

                // Here we need to get the coefficients of the polynomial
                double[] coefficients = GetCoefficients(degree); // We use double because we want to be able to handle decimal values

                // Here we need to get the domain of the polynomial (basically the x-values)
                int minX = GetMinX();
                int maxX = GetMaxX(minX);

                // Just to make sure, we need a way of swapping minX and maxX if minX is greater than maxX
                if (minX > maxX)
                {
                    int temp = minX;
                    minX = maxX;
                    maxX = temp;
                }

                // Here we display the polynomial and the value over its domain
                Console.WriteLine($"The Polynomial over the domain {minX} to {maxX} is:");

                Console.WriteLine("   x |          f(x)");

                // Here we loop through the domain and calculate the polynomial value for each x
                for (int x = minX; x <= maxX; x++)
                {
                    double y = PolyCalculate(coefficients, x);
                    Console.WriteLine($"{x,3} | {y,12:F2}");
                    // SUPER IMPORTANT TO REMEMBER: 12 specifices min width of field, F2 specifies 2 decimal places, x,3 specifies min width of field
                }

                // Here we ask the user if they want to continue
                Console.Write("\nWould You like to continue calculating polynomials? (Y/N): ");
                string response = Console.ReadLine().ToUpper(); // We convert to uppercase to make it easier to check
                if (response != "Y")
                {
                    perseverareCalculating = false;
                }
                else
                {
                    polyNumero++;
                }
            }
            /*---+---+---+--End of Main Loop Block---+---+---+--*/


            /*---+---+---+--Start of End Message Block---+---+---+--*/
            // Here we just display an end message
            Console.WriteLine("\nThat was crazy fun I bet you got dizzy ( ͡ಥʖ ͡ಥ)\n ");
            /*---+---+---+--End of End Message Block---+---+---+--*/
        }


        /*---+---+---+--Start of GetDegree Method Block---+---+---+--*/
        // This method is used to get the degree of the polynomial from the user
        static int GetDegree()
        {
            int degree;
            while (true)
            {
                Console.Write("Enter the degree of the polynomial: ");
                // Here we need to ensure that the input is an integer between 0 and 3 to represent cubic, quadratic, linear, and constant polynomials
                if (int.TryParse(Console.ReadLine(), out degree) && degree >= 0 && degree <= 3)
                {
                    return degree;
                }
                Console.WriteLine("Invalid input. Please enter a proper value for the degree. It must be between 0 and 3.\n (╯ ͡•. ͡•)╯┻━┻ ");
            }
        }
        /*---+---+---+--End of GetDegree Method Block---+---+---+--*/


        /*---+---+---+--Start of GetCoefficients Method Block---+---+---+--*/
        // This method is used to get the coefficients of the polynomial from the user
        static double[] GetCoefficients(int degree)
        {
            double[] coefficients = new double[degree + 1]; // Array to store the coefficients
            for (int i = degree; i >= 0; i--) // SUPER IMPORTANT NOTE this look goes from the highest degree to the lowest degree
            {
                while (true)
                {
                    Console.Write($"Enter the coefficient for x^{i}: ");
                    // To ensure that the input is a number we take care of errors by using TryParse
                    if (double.TryParse(Console.ReadLine(), out coefficients[i]))
                    {
                        break; // Breaks out of the loop if the input is valid
                    }
                    Console.WriteLine("The coefficient must be a number. Please enter a proper value.\n (╯ ͡•. ͡•)╯┻━┻ ");
                }
            }
            return coefficients;
        }
        /*---+---+---+--End of GetCoefficients Method Block---+---+---+--*/


        /*---+---+---+--Start of GetMinX Method Block---+---+---+--*/
        // This method is used to get the minimum x-value of the domain from the user
        static int GetMinX()
        {
            int minX;
            while (true)
            {
                Console.Write("Enter min x value: ");
                // Here we need to ensure that the input is an integer
                if (int.TryParse(Console.ReadLine(), out minX))
                {
                    return minX; // This will return the value if it is valid
                }
                Console.WriteLine("Invalid input. Please enter a proper value for the min x value.\n (╯ ͡•. ͡•)╯┻━┻ ");
            }
        }
        /*---+---+---+--End of GetMinX Method Block---+---+---+--*/


        /*---+---+---+--Start of GetMaxX Method Block---+---+---+--*/
        // This is basically the same as GetMinX but we need to ensure that the max x-value is greater than the min x-value
        static int GetMaxX(int minX)
        {
            int maxX;
            while (true)
            {
                Console.Write("Enter max x value: ");
                // Here we need to ensure that the input is an integer
                if (int.TryParse(Console.ReadLine(), out maxX))
                {
                    if (maxX > minX)
                    {
                        return maxX; // This will return the value if it is valid    
                    }
                    else
                    {
                        Console.WriteLine("Invalid input. Please enter a proper value for the max x value.\n (╯ ͡•. ͡•)╯┻━┻ ");    
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a proper value for the max x value.\n (╯ ͡•. ͡•)╯┻━┻ ");
                }
                
            }
        }
        /*---+---+---+--End of GetMaxX Method Block---+---+---+--*/


        /*---+---+---+--Start of PolyCalculate Method Block---+---+---+--*/
        // This method is used to calculate the value of the polynomial at a given x-value
        static double PolyCalculate(double[] coefficients, int x)
        {
            double result = 0;
            // This will loop through the coefficients and calculate the value of the polynomial
            for (int i = 0; i < coefficients.Length; i++)
            {
                result += coefficients[i] * Math.Pow(x, i);
            }
            return result; // This will return the result of the calculation
        }
        /*---+---+---+--End of PolyCalculate Method Block---+---+---+--*/


    }

}


/* ---+---+---+--For users wanting to run this project there are a few steps required to run this project: ---+---+---+-- */

/* 

   1. Download and Install the .NET SDK https://dotnet.microsoft.com/en-us/download
   2. Clone the repository to your local machine
   3. For visual studio code ensure you have the C# extension installed
   4. Open the project in Visual Studio Code
   5. Open the terminal in Visual Studio Code
   6. Navigate to the project folder
   7. Run the command "dotnet run" in the terminal

   for future reference in case you didn't build the project yet you can run the command "dotnet build" to build the project before running it. Before step 7. 
   but in this case I alread built the project
   
   
*/