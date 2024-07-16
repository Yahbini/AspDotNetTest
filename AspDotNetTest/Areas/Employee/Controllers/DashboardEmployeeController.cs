using AspDotNetTest.Areas.Employee.Service;
using Microsoft.AspNetCore.Mvc;

namespace AspDotNetTest.Areas.Employee.Controllers;
[Area("employee")]
[Route("employee")]
[Route("employee/dashboard")]
public class DashboardEmployeeController : Controller
{
    private EmployeeReqService employeeReqService;

    public DashboardEmployeeController(EmployeeReqService employeeReqService)
    {
        this.employeeReqService = employeeReqService;
    }

    //[Route("~/")]
    [Route("")]
    [Route("index")]
    public IActionResult Index()
    {
        ViewBag.requests = employeeReqService.findAllRequest();

        return View("Index");
    }


}
