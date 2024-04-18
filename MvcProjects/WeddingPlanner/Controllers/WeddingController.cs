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
        List<Wedding> allWeddings = _context.Weddings.Include(w => w.RsvpedGuests).ToList();
        // List<Wedding> allWeddings = _context.Weddings.ToList();
        return View("Dashboard", allWeddings);
    }


    [HttpGet("wedding/new")]
    public IActionResult NewWedding()
    {
        return View("NewWedding");
    }

    [HttpGet("wedding/{WeddingId}/view")]
    public IActionResult ViewOneWedding(int WeddingId)
    {
        Wedding? thisWedding = _context.Weddings.Include(w => w.RsvpedGuests).ThenInclude(g => g.RsvpingUser).SingleOrDefault(w => w.WeddingId == WeddingId);
        ViewBag.SessionUserId = HttpContext.Session.GetInt32("UserId");
        return View("ViewOneWedding", thisWedding);
    }


//------------------------------- CRUD routes ------------------------------------

    [HttpPost("wedding/create")]     
    public IActionResult CreateWedding(Wedding newWedding)
    {
        if(ModelState.IsValid) {
            Console.WriteLine("Wedding Model is valid");
            Console.WriteLine("Wedding Model is valid");
            newWedding.UserId = HttpContext.Session.GetInt32("UserId");
            _context.Add(newWedding);
            _context.SaveChanges();

            return RedirectToAction("Dashboard");
        }
        else {
            Console.WriteLine("Wedding Model is NOT valid");
            Console.WriteLine(ModelState);
            Console.WriteLine(newWedding.WedderOne);
            Console.WriteLine(newWedding.WedderTwo);
            Console.WriteLine(newWedding.Date);
            Console.WriteLine(newWedding.Address);
            Console.WriteLine(newWedding.UserId);

            return View("NewWedding");
        }
    }

    [HttpPost("wedding/delete")]
    public IActionResult DeleteWedding(int WeddingId) 
    {
        Wedding toDelete = _context.Weddings.SingleOrDefault(w => w.WeddingId == WeddingId);
        _context.Weddings.Remove(toDelete);
        _context.SaveChanges();

        return Dashboard();
    }



//--------------- CRUD for RSVP

    [HttpPost("rsvp/update")]
    public IActionResult AddRSVP(int WeddingId)
    {
        RSVP newRsvp = new(){WeddingId = WeddingId, UserId = (int)HttpContext.Session.GetInt32("UserId")};

        _context.Add(newRsvp);
        _context.SaveChanges();

        return Dashboard();
        // return View("Dashboard");
    }

    [HttpPost("rsvp/delete")]
    public IActionResult DeleteRsvp(int WeddingId)
    {
        RSVP toDelete = _context.RSVPs.SingleOrDefault(r => r.WeddingId == WeddingId && r.UserId == (int)HttpContext.Session.GetInt32("UserId"));
        if(toDelete == null)
            {Console.WriteLine("Wedding toDelete returned null");} //this is pointless / cant be null
        _context.RSVPs.Remove(toDelete);
        _context.SaveChanges();

        return Dashboard();
    }



//---------------




}
