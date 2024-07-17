using AspDotNetTest.Areas.Employee.Service;
using AspDotNetTest.Areas.EmplSupport.Service;
using Microsoft.AspNetCore.Mvc;

namespace AspDotNetTest.Areas.Employee.Controllers;
[Area("employee")]
[Route("employee")]
[Route("employee/dashboard")]
public class DashboardEmployeeController : Controller
{
    private EmployeeReqService employeeReqService;

    public DashboardEmployeeController(EmployeeReqService employeeReqService, RequestEmplSupportService requestEmplSupportService)
    {
        this.employeeReqService = employeeReqService;
    }

    //[Route("~/")]
    [Route("")]
    [Route("index")]
    public IActionResult Index()
    {
        var employee = HttpContext.Session.GetString("username");
        var account = employeeReqService.findEmplByUsername(employee);
        ViewBag.requests = employeeReqService.findRequestByUsername(employee);
        return View("Index");
    }


}
