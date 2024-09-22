using Microsoft.AspNetCore.Mvc;
using Tut.Models;

namespace Tut.Controllers;

public class PersonController : Controller
{
    // Action

    public IActionResult Index()
    {
        // ViewModel

        var person = new Person()
        {
            Id = 1,
            FirstName = "John",
            LastName = "Smith",
            Age = 20
        };

        string test = "test 1";
        int num = 0;

        ViewBag.perr = person;

        //ViewData["test"] = person;

        //TempData[]

        return View(person);
    }
}
