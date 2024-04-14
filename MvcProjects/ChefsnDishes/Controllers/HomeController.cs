using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ChefsnDishes.Models;

namespace ChefsnDishes.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private ChefContext _context;
    private DishContext _contextD;

    public HomeController(ILogger<HomeController> logger, ChefContext context, DishContext contextD)
    {
        _logger = logger;
        _context = context;
        _contextD = contextD;
    }

//------------------------------- view routes ------------------------------------

    [HttpGet("")]
    public IActionResult Chefs()
    {
        List<Chef> allChefs = _context.Chefs.ToList();
        return View("Chefs", allChefs);
    }

    public IActionResult Dishes()
    {
        List<Dish> allDishes = _contextD.Dishes.ToList(); 
        return View("Dishes", allDishes);
    }

    public IActionResult AddAChef()
    {
        return View();
    }

    public IActionResult AddDish()
    {
        List<Chef> allChefs = _context.Chefs.ToList();
        ViewBag.AllChefs = allChefs;
        return View("AddDish");
    }

//------------------------------- CRUD routes ------------------------------------

    [HttpPost("chef/create")]
    public IActionResult CreateChef(Chef newChef)
    {
        if(ModelState.IsValid) {
            Console.WriteLine("newChef is valid");

            _context.Add(newChef);
            _context.SaveChanges();

            return RedirectToAction("Chefs");
        }
        else {
            Console.WriteLine("newChef is invalid");
            return View("AddAChef");
        }
    }


    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
