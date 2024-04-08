using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using SessionWorkshop.Models;

namespace SessionWorkshop.Controllers;





public class HomeController : Controller
{

    

    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        HttpContext.Session.SetString("UserName", "belle");

        return View();
    }

    public IActionResult CountPg()
    {
        // string LocalVar = HttpContext.Session.GetString("UserName");
        return View();
    }

    //---------------------------------------------------------------

    [HttpPost("Process")]
    public IActionResult Process(string NameVar)
    {
        HttpContext.Session.SetString("UserName", NameVar);
        HttpContext.Session.SetInt32("num", 22);

        return View("CountPg");
    }
    //--------

    [HttpPost("AddOne")]
    public IActionResult AddOne() 
    {
        int? var = HttpContext.Session.GetInt32("num");
        HttpContext.Session.SetInt32("num", (int)var + 1);

        return View("CountPg");
    }
    //--------

    [HttpPost("SubOne")]
    public IActionResult SubOne() 
    {
        int? var = HttpContext.Session.GetInt32("num");
        HttpContext.Session.SetInt32("num", (int)var - 1);

        return View("CountPg");
    }
    //--------

    [HttpPost("X2")]
    public IActionResult X2() 
    {
        int? var = HttpContext.Session.GetInt32("num");
        HttpContext.Session.SetInt32("num", (int)var * 2);

        return View("CountPg");
    }
    //--------

    [HttpPost("AddRand")]
    public IActionResult AddRand() 
    {
        int? var = HttpContext.Session.GetInt32("num");

        Random rand = new Random();

        HttpContext.Session.SetInt32("num", (int)var + rand.Next(0, 10));

        return View("CountPg");
    }


    [HttpPost("Logout")]
    public IActionResult Logout()
    {
        HttpContext.Session.Clear();
        return View("Index");
    }




    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
