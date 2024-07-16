using AspDotNetTest.Areas.Employee.Service;
using AspDotNetTest.Helper;
using AspDotNetTest.Models;
using Microsoft.AspNetCore.Mvc;

namespace AspDotNetTest.Areas.EmplSupport.Controllers;
[Area("emplsupport")]
[Route("emplsupport/profile")]
public class ProfileEmplSupportController : Controller
{
    private EmployeeReqService employeeService;
    private IWebHostEnvironment webHostEnvironment;

    public ProfileEmplSupportController(EmployeeReqService employeeService, IWebHostEnvironment webHostEnvironment)
    {
        this.employeeService = employeeService;
        this.webHostEnvironment = webHostEnvironment;
    }

    [HttpGet]
    [Route("index")]
    public IActionResult Index()
    {
        var username = HttpContext.Session.GetString("username");
        var account = employeeService.findEmplByUsername(username);
        return View("Index", account);
    }

    [HttpPost]
    [Route("index")]
    public IActionResult Index(NhanVien nhanVien, IFormFile file)
    {
        var username = HttpContext.Session.GetString("username");
        if (username != null)
        {
            var account = employeeService.findEmplByUsername(username);

            if (!string.IsNullOrEmpty(nhanVien.Password))
            {
                account.Password = BCrypt.Net.BCrypt.HashPassword(nhanVien.Password);
            }

            account.Hoten = nhanVien.Hoten;
            account.Ngaysinh = nhanVien.Ngaysinh;

            if (file != null && file.Length > 0)
            {
                var fileName = FileHelper.genarateName(file.FileName);
                var path = Path.Combine(webHostEnvironment.WebRootPath, "images", fileName);
                using (var fileStream = new FileStream(path, FileMode.Create))
                {
                    file.CopyTo(fileStream);
                }
                account.Hinhanh = fileName;
            }
            else
            {
                nhanVien.Hinhanh = account.Hinhanh;
            }

            if (employeeService.UpdateEmployee(account))
            {
                TempData["Msg"] = "Profile updated successfully!";
                return RedirectToAction("index", "ProfileEmplSupport", new { Area = "emplsupport" });
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

    [HttpPost]
    [Route("logout")]
    public IActionResult Logout()
    {
        HttpContext.Session.Remove("username");
        return RedirectToAction("index", "login");
    }
}
