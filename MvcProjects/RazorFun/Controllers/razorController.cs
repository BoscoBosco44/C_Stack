using Microsoft.AspNetCore.Mvc;

namespace RazorFunNamespace.Controllers;

public class razorController : Controller {
    [HttpGet]
    [Route("")]
    public ViewResult Index() {
        return View("thisIsAView");
    }
}