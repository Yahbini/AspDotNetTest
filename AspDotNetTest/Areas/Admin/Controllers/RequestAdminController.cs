using AspDotNetTest.Areas.Admin.Service;
using AspDotNetTest.Models;
using Microsoft.AspNetCore.Mvc;

namespace AspDotNetTest.Areas.Admin.Controllers;
[Area("admin")]
[Route("admin/request")]
public class RequestAdminController : Controller
{
    private RequestService requestService;
    private EmployeeService employeeService;

    public RequestAdminController(RequestService requestService, EmployeeService employeeService)
    {
        this.requestService = requestService;
        this.employeeService = employeeService;
    }

    [HttpGet]
    [Route("list")]
    public IActionResult List(YeuCau yeuCau)
    {
        ViewBag.requests = requestService.findAll();
        return View("List", yeuCau);
    }

    [HttpGet]
    [Route("details/{id}")]
    public IActionResult Details(int id)
    {
        var request = requestService.findById(id);
        ViewBag.employees = employeeService.findAll();
        return View("Details", request);
    }

    [HttpPost]
    [Route("details/{id}")]
    public IActionResult Details(int id, string empHandles)
    {
        var request = requestService.findById(id);

        request.ManvXuly = empHandles;

        ViewBag.employees = employeeService.findAll();

        if (requestService.UpdateRequest(request))
        {
            return RedirectToAction("dashboard", "dashboard", new { area = "admin" });
        }
        else
        {
            ViewBag.Msg = "Failed";
            return View("Details", request);
        }

    }

    [HttpGet]
    [Route("employee/{username}")]
    public IActionResult Index(string username)
    {
        var employee = employeeService.GetEmployeeByUsername(username);
        var requests = requestService.findReqByUsername(username);
        ViewBag.Employee = employee;
        ViewBag.Requests = requests;
        return View("Index");
    }
}
