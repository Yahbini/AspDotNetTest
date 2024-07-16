using AspDotNetTest.Service;
using Microsoft.AspNetCore.Mvc;

namespace AspDotNetTest.Controllers;

[Route("account")]
public class LoginController : Controller
{
    private LoginService loginService;

    public LoginController(LoginService loginService)
    {
        this.loginService = loginService;
    }

    [HttpGet]
    [Route("~/")]
    [Route("")]
    [Route("login")]
    public IActionResult Index()
    {
        return View();
    }

    [HttpPost]
    [Route("login")]
    public IActionResult Index(string username, string password)
    {
        var account = loginService.Login(username, password);
        if (account != null)
        {
            HttpContext.Session.SetString("username", username);

            if (account.Quyen == 3)
            {
                return RedirectToAction("index", "dashboardadmin", new { Area = "admin" });
            }
            else if (account.Quyen == 1)
            {
                return RedirectToAction("index", "dashboardemployee", new { Area = "employee" });
            }
            else if (account.Quyen == 2)
            {
                return RedirectToAction("index", "dashboardemplsupport", new { Area = "emplsupport" });
            }

        }

        TempData["Msg"] = "Failed";
        return View("Index");

    }
}
