using Microsoft.AspNetCore.Mvc;

namespace AspDotNetTest.Areas.EmplSupport.Controllers;
[Area("emplsupport")]
[Route("emplsupport/profile")]
public class ProfileEmplSupportController : Controller
{
    [Route("index")]
    public IActionResult Index()
    {
        return View();
    }
}
