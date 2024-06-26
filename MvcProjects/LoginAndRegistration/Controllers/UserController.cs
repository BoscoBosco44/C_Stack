using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using LoginAndRegistration.Models;
using Microsoft.AspNetCore.Identity;

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

    public IActionResult Success()
    {
        return View();
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

            return RedirectToAction("Success");
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

    [HttpPost("users/success")]
    public IActionResult LoginUser(LogUser user)
    {
        if(ModelState.IsValid) {
            Console.WriteLine("Login user valid");

            User? userInDb = _context.Users.SingleOrDefault(i => i.Email == user.LogEmail);

            if(userInDb == null) {
                ModelState.AddModelError("Email", "Invalid Email / Passwordddddd");
                return View("Index");
            }

            PasswordHasher<LogUser> hasher = new PasswordHasher<LogUser>(); //initialise hasher obj

            var result = hasher.VerifyHashedPassword(user, userInDb.Password, user.LogPassword); //why var?

            if(result == 0) {
                ModelState.AddModelError("Email", "Lies Lies Lies");
                return View("Index");
            }
            else {
                HttpContext.Session.SetInt32("UserId", userInDb.UserId);
                ViewBag.UserId = HttpContext.Session.GetInt32("UserId");
                return RedirectToAction("Success");
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
