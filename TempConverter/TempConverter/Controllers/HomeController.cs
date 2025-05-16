/*
================================================================================
Name: Irving F. Sanchez
Course: CPSC-23000-001 .NET Programming
School: Lewis University, Romeoville, IL
Purpose: Handles user requests for temperature conversion in ASP.NET Core MVC.
Routes: / (Index), /Convert, /Clear, /Questions
================================================================================
*/

using Microsoft.AspNetCore.Mvc;
using TempConverter.Models;

namespace TempConverter.Controllers
{
    /*---+---+---+--Start of HomeController Block---+---+---+--*/
    public class HomeController : Controller
    {
        /*---+---+---+--Start of Index Action Block---+---+---+--*/
        // Displays the temperature conversion form (default view)
        public IActionResult Index()
        {
            // Initialize with default Celsius value
            var model = new Temperature { Scale = "C" };
            return View(model);
        }
        /*---+---+---+--End of Index Action Block---+---+---+--*/


        /*---+---+---+--Start of Convert Action Block---+---+---+--*/
        // Handles form submission (POST /Convert)
        [HttpPost]
        public IActionResult Convert(Temperature temp)
        {
            if (!temp.IsValid())
            {
                // Invalid input: Show error and reset converted value
                ModelState.AddModelError("Value", "Please enter a valid number.");
                temp.Value = double.NaN; // Clear invalid input
            }
            else
            {
                // Valid input: Perform conversion
                double convertedTemp = temp.Convert();
                ViewBag.ConvertedTemp = convertedTemp;
                ViewBag.ConvertedScale = temp.Scale == "C" ? "F" : "C";
            }

            return View("Index", temp);
        }
        /*---+---+---+--End of Convert Action Block---+---+---+--*/


        /*---+---+---+--Start of Clear Action Block---+---+---+--*/
        // Resets the form (GET /Clear)
        public IActionResult Clear()
        {
            // Return to default state (Celsius, empty value)
            return RedirectToAction("Index");
        }
        /*---+---+---+--End of Clear Action Block---+---+---+--*/


        /*---+---+---+--Start of Questions Action Block---+---+---+--*/
        // Displays the Questions page (GET /Questions)
        public IActionResult Questions()
        {
            return View();
        }
        /*---+---+---+--End of Questions Action Block---+---+---+--*/
    }
    /*---+---+---+--End of HomeController Block---+---+---+--*/
}