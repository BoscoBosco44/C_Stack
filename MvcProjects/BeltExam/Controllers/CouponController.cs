using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using BeltExam.Models;
using Microsoft.EntityFrameworkCore;

namespace BeltExam.Controllers;


[SessionCheck] //will apply sessionCheck to every route
public class CouponController : Controller
{
    private readonly ILogger<UserController> _logger;
    private MyContext _context;

    public CouponController(ILogger<UserController> logger, MyContext context)
    {
        _logger = logger;
        _context = context;
    }

//------------------------------- view routes ------------------------------------

    [HttpGet("dashboard")]
    public IActionResult Dashboard()
    {
        List<Coupon> allCoupons = _context.Coupons.Include(c => c.UsersWhoUsedThisCoupon).Include(c => c.CouponCreator).ToList();
        return View("Dashboard", allCoupons);
    }

    [HttpGet("coupon/new")]
    public IActionResult NewCoupon()
    {
        return View("NewCoupon");
    }



//------------------------------- CRUD routes ------------------------------------

    [HttpPost("coupon/create")]
    public IActionResult CreateCoupon(Coupon newCoupon)
    {
        if(ModelState.IsValid) {
            newCoupon.UserId = HttpContext.Session.GetInt32("UserId");
            _context.Add(newCoupon);
            _context.SaveChanges();

            return RedirectToAction("Dashboard");
        }
        else {
            return View("NewCoupon");
        }
    }




//--------------- CRUD for SharedCoupons

    [HttpPost("sharedCoupons/create")]
    public IActionResult AddCouponRelation(int CouponId)
    {
        SharedCoupon newRelation = new(){CouponId = CouponId, UserId = (int)HttpContext.Session.GetInt32("UserId")};

        _context.Add(newRelation);
        _context.SaveChanges();

        return Dashboard();
    }



//---------------



//---------------







}
