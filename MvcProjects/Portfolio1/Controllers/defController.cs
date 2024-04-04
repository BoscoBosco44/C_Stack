using Microsoft.AspNetCore.Mvc;

namespace Portfolio1Namespace.Controllers;

public class DefController : Controller {

    [HttpGet]
    [Route("")]
    public ViewResult Index() {
        return View("home");
    }

    //----------------

    [HttpGet]
    [Route("projects")]
    public string Projects() {
        return "These are my projects";
    }

    //---------------

    [HttpGet]
    [Route("contact")]
    public string Contact() {
        return "This is my contact info";
    }
}