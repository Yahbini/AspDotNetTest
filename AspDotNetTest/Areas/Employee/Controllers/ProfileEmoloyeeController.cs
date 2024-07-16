using AspDotNetTest.Areas.Employee.Service;
using AspDotNetTest.Models;
using Microsoft.AspNetCore.Mvc;

namespace AspDotNetTest.Areas.Employee.Controllers;
[Area("employee")]
[Route("employee/profile")]
public class ProfileEmoloyeeController : Controller
{
    private EmployeeReqService employeeReqService;

    public ProfileEmoloyeeController(EmployeeReqService employeeReqService)
    {
        this.employeeReqService = employeeReqService;
    }

    [HttpGet]
    [Route("index")]
    public IActionResult Index()
    {
        var username = HttpContext.Session.GetString("username");
        var account = employeeReqService.findEmplByUsername(username);
        return View("Index", account);
    }

    [HttpPost]
    [Route("index")]
    public IActionResult Index(NhanVien nhanVien)
    {
        var username = HttpContext.Session.GetString("username");
        if (username != null)
        {
            var account = employeeReqService.findEmplByUsername(username);

            if (!string.IsNullOrEmpty(nhanVien.Password))
            {
                account.Password = BCrypt.Net.BCrypt.HashPassword(nhanVien.Password);
            }

            account.Hoten = nhanVien.Hoten;
            account.Ngaysinh = nhanVien.Ngaysinh;
            account.Hinhanh = nhanVien.Hinhanh;

            if (employeeReqService.UpdateEmployee(account))
            {
                TempData["Msg"] = "Profile updated successfully!";
                return RedirectToAction("index", "profile", new { Area = "employee" });
            }
            else
            {
                TempData["Msg"] = "Failed to update profile";
                return View("Index", account);
            }
        }
        else
        {
            return RedirectToAction("login", "account");
        }

    }
}
