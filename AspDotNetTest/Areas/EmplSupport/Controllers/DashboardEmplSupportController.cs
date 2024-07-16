using AspDotNetTest.Areas.EmplSupport.Service;
using Microsoft.AspNetCore.Mvc;

namespace AspDotNetTest.Areas.EmplSupport.Controllers;

[Area("emplsupport")]
[Route("emplsupport/dashboard")]
public class DashboardEmplSupportController : Controller
{
    private RequestEmplSupportService requestService;

    public DashboardEmplSupportController(RequestEmplSupportService requestService)
    {
        this.requestService = requestService;
    }

    [Route("")]
    [Route("dashboard")]
    //[Route("~/")]
    public IActionResult Index()
    {
        ViewBag.requests = requestService.findAllRequests();
        return View();
    }
}
