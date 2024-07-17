using AspDotNetTest.Areas.Admin.Service;
using AspDotNetTest.Areas.Employee.Service;
using AspDotNetTest.Helper;
using AspDotNetTest.Models;
using Microsoft.AspNetCore.Mvc;

namespace AspDotNetTest.Areas.Admin.Controllers;

[Area("admin")]
[Route("admin/employee")]
public class EmployeeAdminController : Controller
{
    private EmployeeService employeeService;
    private EmployeeReqService employeeReqService;
    private IWebHostEnvironment webHostEnvironment;

    public EmployeeAdminController(EmployeeService employeeService, EmployeeReqService employeeReqService, IWebHostEnvironment webHostEnvironment)
    {
        this.employeeService = employeeService;
        this.webHostEnvironment = webHostEnvironment;
        this.employeeReqService = employeeReqService;
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
        if (!employeeService.IsEmplExist(nhanVien.Username))
        {
            ModelState.AddModelError("Username", "Username already exists");
        }

        if (ModelState.IsValid)
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
        else
        {
            return View("Add", nhanVien);
        }


    }

    // employee detail
    [HttpGet]
    [Route("index/{username}")]
    public IActionResult Index(string username)
    {
        var employee = employeeReqService.findEmplByUsername(username);
        ViewBag.Employee = employee;
        return View("Index", employee);

    }

    [HttpPost]
    [Route("index/{username}")]
    public IActionResult Index(string username, NhanVien nhanVien, IFormFile file)
    {
        var employee = employeeReqService.findEmplByUsername(username);

        if (employee != null)
        {
            if (!string.IsNullOrEmpty(nhanVien.Password))
            {
                employee.Password = BCrypt.Net.BCrypt.HashPassword(nhanVien.Password);
            }

            employee.Hoten = nhanVien.Hoten;
            employee.Ngaysinh = nhanVien.Ngaysinh;
            employee.Kichhoat = nhanVien.Kichhoat;

            if (file != null && file.Length > 0)
            {
                var fileName = FileHelper.genarateName(file.FileName);
                var path = Path.Combine(webHostEnvironment.WebRootPath, "images", fileName);
                using (var fileStream = new FileStream(path, FileMode.Create))
                {
                    file.CopyTo(fileStream);
                }
                employee.Hinhanh = fileName;
            }
            else
            {
                nhanVien.Hinhanh = employee.Hinhanh;
            }

            employee.Quyen = nhanVien.Quyen;

            if (employeeReqService.UpdateEmployee(employee))
            {
                TempData["Msg"] = "Success";
                return View("Index", employee);
            }
            else
            {
                TempData["Msg"] = "Failed";
                return View("Index", employee);
            }

        }
        else
        {
            return View("Index");
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
