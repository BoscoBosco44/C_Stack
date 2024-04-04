using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using DojoSurvey.Models;

namespace DojoSurvey.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Result()
    {
        return View("Results");
    }

    [HttpPost("Process")]
    public IActionResult Process(string Name, string Location, string fl, string c)
    {
        Console.WriteLine(Name);
        Console.WriteLine(Location);
        Console.WriteLine(fl);
        Console.WriteLine(c);

        ViewBag.name = Name;
        ViewBag.Location = Location;
        ViewBag.fl = fl;
        ViewBag.c = c;

        return View("Results");
    }

    [HttpGet("GoHome")]
    public IActionResult GoHome()
    {
        Console.WriteLine("Going home toto");
        return View("Index");
    }







    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
