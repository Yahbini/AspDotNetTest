using AspDotNetTest.Areas.Admin.Service;
using AspDotNetTest.Helper;
using AspDotNetTest.Models;
using Microsoft.AspNetCore.Mvc;

namespace AspDotNetTest.Areas.Admin.Controllers;

[Area("admin")]
[Route("admin/employee")]
public class EmployeeAdminController : Controller
{
    private EmployeeService employeeService;
    private IWebHostEnvironment webHostEnvironment;

    public EmployeeAdminController(EmployeeService employeeService, IWebHostEnvironment webHostEnvironment)
    {
        this.employeeService = employeeService;
        this.webHostEnvironment = webHostEnvironment;
    }

    [HttpGet]
    [Route("add")]
    public IActionResult Add()
    {
        var employees = new NhanVien();
        return View("Add", employees);
    }

    [HttpPost]
    [Route("add")]
    public IActionResult Add(NhanVien nhanVien, IFormFile file)
    {

        if (file != null && file.Length > 0)
        {
            var fileName = FileHelper.genarateName(file.FileName);
            var path = Path.Combine(webHostEnvironment.WebRootPath, "images", fileName);
            using (var fileStream = new FileStream(path, FileMode.Create))
            {
                file.CopyTo(fileStream);
            }
            nhanVien.Hinhanh = fileName;
        }
        else
        {
            nhanVien.Hinhanh = "no-image.png";
        }
        nhanVien.Password = BCrypt.Net.BCrypt.HashPassword(nhanVien.Password);
        if (employeeService.Create(nhanVien, file))
        {
            ViewBag.Msg = "Success";
            return View("Add", nhanVien);
        }
        else
        {
            ViewBag.Msg = "Failed";
            return View("Add", nhanVien);
        }

    }

    [HttpGet]
    [Route("list")]
    public IActionResult List(NhanVien nhanVien)
    {
        ViewBag.employees = employeeService.findAll();
        return View("List", nhanVien);
    }



}
