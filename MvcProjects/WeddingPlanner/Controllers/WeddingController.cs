using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using WeddingPlanner.Models;
using Microsoft.EntityFrameworkCore;

namespace WeddingPlanner.Controllers;

[SessionCheck] //will apply sessionCheck to every route
public class WeddingController : Controller
{
    private readonly ILogger<WeddingController> _logger;
    private MyContext _context;

    public WeddingController(ILogger<WeddingController> logger, MyContext context)
    {
        _logger = logger;
        _context = context;
    }

//------------------------------- view routes ------------------------------------

    [HttpGet("dashboard")]
    public IActionResult Dashboard()
    {
    //     List<Wedding> allWeddings = _context.Weddings.Include(w => w.RsvpedGuests).ThenInclude(a => a.RsvpingUser).Where(w => w.)
        List<Wedding> allWeddings = _context.Weddings.ToList();
        return View("Dashboard", allWeddings);
    }


    [HttpGet("wedding/new")]
    public IActionResult NewWedding()
    {
        return View("NewWedding");
    }


//------------------------------- CRUD routes ------------------------------------

    [HttpPost("wedding/create")]
    public IActionResult CreateWedding(Wedding newWedding)
    {
        if(ModelState.IsValid) {
            _context.Add(newWedding);
            _context.SaveChanges();

            return RedirectToAction("Dashboard");
        }
        else {
            return View("NewWedding");
        }
    }



//---------------




}
