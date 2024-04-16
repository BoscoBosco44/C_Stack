using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProductsAndCategories.Models;

namespace ProductsAndCategories.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private OneContext _context;

    public HomeController(ILogger<HomeController> logger, OneContext context)
    {
        _logger = logger;
        _context = context;
    }

//------------------------------- view routes ------------------------------------

    [HttpGet("")]
    public IActionResult Products()
    {
        List<Product> allProducts = _context.Products.ToList();
        return View("Products", allProducts);
    }

    public IActionResult Categories()
    {
        List<Category> allCategories = _context.Categories.ToList();
        return View("Categories", allCategories);
    }

//------------------------------- CRUD routes ------------------------------------

    [HttpPost("product/create")]
    public IActionResult CreateProduct(Product newProd)
    {
        if(ModelState.IsValid) {
            _context.Add(newProd);
            _context.SaveChanges();

            return RedirectToAction("Products");
        }
        else {
            return Products();
        }
    }


    [HttpPost("category/create")]
    public IActionResult CreateCategory(Category newCat)
    {
        if(ModelState.IsValid) {
            _context.Add(newCat);
            _context.SaveChanges();

            return RedirectToAction("Categories");
        }
        else {
            return Categories();
        }
    }
//----------------
    [HttpGet("product/{ProdId}")]
    public IActionResult ShowProduct(int ProdId)
    {
        //this versiont is putting thisProduct into the url
        Product? thisProduct = _context.Products.Include(c => c.CategoryAssociations).SingleOrDefault(p => p.ProductId == ProdId);
        ViewBag.allCategories = _context.Categories.ToList();
        return View("ViewAProduct", thisProduct);


        // ViewBag.thisProduct = _context.Products.Include(c => c.Categories).SingleOrDefault(p => p.ProductId == ProdId);
        // ViewBag.allCategories = _context.Categories.ToList();
        // return View("ViewAProduct");
    }


//----------------
    [HttpPost("association/new")]   //is this still restfull routing???
    public IActionResult NewAssociation(int ProdId, int CategoryId)
    {

        _context.Associations.Add(new Association(){ProductID = ProdId, CategoryId = CategoryId});
        _context.SaveChanges();
        return View();
    }




    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
