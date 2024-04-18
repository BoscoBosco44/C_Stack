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
        Product? thisProduct = _context.Products.Include(p => p.CategoryAssociations).ThenInclude(a => a.Category).SingleOrDefault(p => p.ProductId == ProdId);
        
                                //get all categories, include prodcutAssociations, return where(prodId != prodAsso)
        ViewBag.allCategories = _context.Categories.Include(c => c.ProductAssociations).Where(c => !c.ProductAssociations.Any(a => a.ProductID == ProdId));
        return View("ViewAProduct", thisProduct);

    }

    [HttpGet("category/{catID}")]
    public IActionResult ShowCategory(int catID)
    {
        Category? thisCategory = _context.Categories.Include(c => c.ProductAssociations).ThenInclude(a => a.Product).SingleOrDefault(c => c.CategorytId == catID);
        ViewBag.ProductsToAdd = _context.Products.Include(p => p.CategoryAssociations).Where(p => !p.CategoryAssociations.Any(a => a.CategoryId == catID));

        return View("ViewACategory", thisCategory);
    
    }


//----------------
    [HttpPost("association/new")]   
    public IActionResult NewAssociation(int ProdId, int CategoryId)
    {

        _context.Associations.Add(new Association(){ProductID = ProdId, CategoryId = CategoryId});
        _context.SaveChanges();
        return RedirectToAction("Products");
    }




    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
