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
    public IActionResult Process(Survey newSurvey)
    {
        if(ModelState.IsValid) {
        // if(1 == 1) {
            return View("Results", newSurvey);
        }
        else {
            Console.WriteLine(newSurvey.Name);
            Console.WriteLine(newSurvey.Location);
            Console.WriteLine(newSurvey.FavLang);
            return View("Index");
        }




        // Survey newSurvey = new Survey()
        // {
        //     Name = Name,
        //     Location = Location,
        //     FavLang = fl,
        //     Comment = c
        // };

        // Console.WriteLine(Name);
        // Console.WriteLine(Location);
        // Console.WriteLine(fl);
        // Console.WriteLine(c);

        // ViewBag.name = Name;
        // ViewBag.Location = Location;
        // ViewBag.fl = fl;
        // ViewBag.c = c;

        // return View("Results");
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
