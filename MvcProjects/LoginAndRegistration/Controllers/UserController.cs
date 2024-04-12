using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using LoginAndRegistration.Models;

namespace LoginAndRegistration.Controllers;

public class UserController : Controller
{
    private readonly ILogger<UserController> _logger;
    private UserContext _context;

    public UserController(ILogger<UserController> logger, UserContext context)
    {
        _logger = logger;
        _context = context;
    }

//------------------------------- view routes ------------------------------------

    [HttpGet("")] //need to specify when "home" is not in HomeController
    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }


//------------------------------- CRUD routes ------------------------------------

    // [HttpPost("newUser/create")]
    // public IActionResult RegisterUser(User newUser)
    // {
    //     if(ModelState.IsValid) {
    //         Console.WriteLine("New Use Valid: adding users");
            
    //     }
    // }



    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
