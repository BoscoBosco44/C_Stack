using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using BeltExam.Models;
using Microsoft.EntityFrameworkCore;

namespace BeltExam.Controllers;

public class UserController : Controller
{
    private readonly ILogger<UserController> _logger;
    private MyContext _context;

    public UserController(ILogger<UserController> logger, MyContext context)
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

    public IActionResult Success()
    {
        return View();
    }

    [HttpGet("user/accountInfo")]
    public IActionResult ViewAccountInfo()
    {
        int? userId = HttpContext.Session.GetInt32("UserId");
        Console.WriteLine($"UserId: {userId}");
        User? thisUser = _context.Users.Include(u => u.CouponInteractions).Include(u => u.CouponsCreated).ThenInclude(a => a.UsersWhoUsedThisCoupon).SingleOrDefault(u => u.UserId == userId);
        Console.WriteLine($"thisUser: {thisUser.CouponInteractions.Count}");
        return View("AccountInfo", thisUser);
    }


//------------------------------- CRUD routes ------------------------------------

    [HttpPost("users/create")]
    public IActionResult RegisterUser(User newUser)
    {
        if(ModelState.IsValid) {
            Console.WriteLine("New Use Valid: adding users");

            PasswordHasher<User> hasher = new();
            newUser.Password = hasher.HashPassword(newUser, newUser.Password); //overrideing newUser's password with a hashed vertion
            _context.Add(newUser);
            _context.SaveChanges();
            
            HttpContext.Session.SetInt32("UserId", newUser.UserId); //"loggin in" users
            HttpContext.Session.SetString("Username", newUser.Username); //set user name in session


            return RedirectToAction("Dashboard", "Coupon");
        }
        else
            return View("Index");

    }



//---------------

    [HttpPost("logout")]
    public IActionResult Logout()
    {
        HttpContext.Session.Clear();
        return View("Index");
    }

//---------------

    [HttpPost("users/success")] //for logging in
    public IActionResult LoginUser(LogUser user)
    {
        if(ModelState.IsValid) {
            Console.WriteLine("Login user valid");

            User? userInDb = _context.Users.SingleOrDefault(u => u.Email == user.LogEmail);

            // Console.WriteLine($"UserId from DB {userInDb.UserId}"); //this breaks everything if email dose not exist

            if(userInDb == null) {
                ModelState.AddModelError("LogPassword", "Invalid Email / Password");
                return View("Index");
            }

            PasswordHasher<LogUser> hasher = new PasswordHasher<LogUser>(); //initialise hasher obj

            var result = hasher.VerifyHashedPassword(user, userInDb.Password, user.LogPassword); //why var?

            if(result == 0) {
                ModelState.AddModelError("LogEmail", "Lies Lies Lies (Incorect email/password)");
                return View("Index");
            }
            else {
                HttpContext.Session.SetInt32("UserId", userInDb.UserId); //set UserId in session
                HttpContext.Session.SetString("Username", userInDb.Username); //set user name in session

                int? userId = HttpContext.Session.GetInt32("UserId");
                Console.WriteLine($"UserId in session (from user controller): {userId}");

                return RedirectToAction("Dashboard", "Coupon");
            }


        } 
        else {
            Console.WriteLine("LogUser invalid");
            return View("Index");
        }
    }



    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
