using AspDotNetTest.Areas.Admin.Service;
using Microsoft.AspNetCore.Mvc;

namespace AspDotNetTest.Areas.Admin.Controllers;

[Area("admin")]
[Route("admin")]
[Route("admin/dashboard")]
public class DashboardAdminController : Controller
{
    private RequestService requestService;

    public DashboardAdminController(RequestService requestService)
    {
        this.requestService = requestService;
    }

    //[Route("~/")]
    [Route("")]
    [Route("dashboard")]
    public IActionResult Index()
    {

        ViewBag.requests = requestService.findAll();
        return View();
    }

    [Route("logout")]
    public IActionResult Logout()
    {
        HttpContext.Session.Remove("username");
        return RedirectToAction("index", "login");
    }
}
