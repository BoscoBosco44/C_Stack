using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using CRUDelicious.Models;
namespace CRUDelicious.Controllers;

public class HomeController : Controller
{    
    private readonly ILogger<HomeController> _logger;
    private DishContext _context;         
    public HomeController(ILogger<HomeController> logger, DishContext context)    
    {        
        _logger = logger;
        _context = context;    
    }         

//------------------------------- view routes ------------------------------------

    public IActionResult Index()
    {
        ViewBag.AllDishes = _context.Dishes.ToList();

        return View();
    }

    public IActionResult AddDishPg()
    {
        return View();
    }

    public IActionResult ViewDish(int DishId)
    {
        ViewBag.ThisDish = _context.Dishes.FirstOrDefault(i => i.DishId == DishId);

        return View("ViewOneDish");
    }

//------------------------------- CRUD routes ------------------------------------
//---------- Create
    [HttpPost("dishes/create")]
    public IActionResult CreateDish(Dish newDish)
    {
        Console.WriteLine(newDish.Name);
        Console.WriteLine(newDish.Chef);
        Console.WriteLine(newDish.Calories);
        Console.WriteLine(newDish.Tastiness);
        if(ModelState.IsValid){
            Console.WriteLine("newDish Valid: Adding Dish");
            _context.Add(newDish);
            _context.SaveChanges();
            return RedirectToAction("Index"); //why dose this need to be redirectToAction and not View()
        }
        else {
            Console.WriteLine("newDish failed Validation");
            return View("AddDishPg");
        }
    }
//---------- Edit
[HttpGet("dishes/{DishId}/edit")]
public IActionResult EditDish(int DishId)
{
    Dish? DishToEdit = _context.Dishes.FirstOrDefault(i => i.DishId == DishId);

    if(DishToEdit != null) {
        Console.WriteLine("Success");
        return View("EditDishPg", DishToEdit);
    }
    else{
        Console.WriteLine("DishToEdit returned NULL. DishId: ", DishId);
        return NotFound();
    }
}
//---------- Update
[HttpPost("dishes/{DishId}/update")]
public IActionResult UpdateDish(Dish newDish, int DishId)
{
    Dish? OldDish = _context.Dishes.FirstOrDefault(i => i.DishId == DishId);

    if(ModelState.IsValid)
    {
        OldDish.Name = newDish.Name;
        OldDish.Chef = newDish.Chef;
        OldDish.Tastiness = newDish.Tastiness;
        OldDish.Calories = newDish.Calories;
        OldDish.Description = newDish.Description;

        OldDish.UpdatedAt = DateTime.Now;
        _context.SaveChanges();
        
        return RedirectToAction("ViewDish", OldDish);
    }
    else
        return View("EditDish", OldDish);
}
//---------- Delete
    [HttpPost("dishes/{DishId}/destroy")]
    public IActionResult DeleteDish(int DishId)
    {
        Dish? DishToDelete = _context.Dishes.SingleOrDefault(i => i.DishId == DishId);
        if(DishToDelete != null) {
            Console.WriteLine("DishToDelete not null");
            //def should check if dishToDelete exists
            _context.Dishes.Remove(DishToDelete);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        else {
            Console.WriteLine("DishToDelete is null");
            return View();

        }


    }


    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
