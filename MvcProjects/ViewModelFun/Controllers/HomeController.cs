using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ViewModelFun.Models;

namespace ViewModelFun.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    [HttpGet("")]
    public IActionResult Index()
    {
        string ViewModelStr = "pssssst, have a nice day, in seacret";
        // int test = 6;
        return View("Index", ViewModelStr);
    }

    public IActionResult Numbers()
    {
        List<int> nums = [1,44,234,5,67,35,373,];
        return View("Numbers", nums);
    }

    [HttpGet("User")]
    public IActionResult User()
    {
        User newUser = new User()
        {
            FirstName = "Paul",
            LastName = "Bosco"
        };
        return View(newUser);
    }

    [HttpGet("Users")]
    public IActionResult Users()
    {
        List<User> users = [];
        User newUser = new User()
        {
            FirstName = "Paul",
            LastName = "Bosco"
        };
        User newUser2 = new User()
        {
            FirstName = "Sofi",
            LastName = "Bosco"
        };        
        User newUser3 = new User()
        {
            FirstName = "Mary",
            LastName = "Bosco"
        };
        users.Add(newUser);
        users.Add(newUser2);
        users.Add(newUser3);

        return View(users);
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
