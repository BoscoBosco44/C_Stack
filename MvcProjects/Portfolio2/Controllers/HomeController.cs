using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Portfolio2.Models;

namespace Portfolio2.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index() //Index() == html being displayed
    {
        User newUser = new User() //create instace of model and return that to a view
        {
            FirstName = "Nichole",
            LastName = "King"
        };
        return View(newUser);
    }

     all our other controller code
    [HttpGet("")]
    public IActionResult Index()
    {
        ViewBag.MyNum = 9;
        // The myViewModelNum variable will hold our information for our ViewModel
        int myViewModelNum = 12;
        // We then take our myViewModelNum variable (NOT the ViewBag) and pass it into our View
        return View(myViewModelNum);
    }







    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
