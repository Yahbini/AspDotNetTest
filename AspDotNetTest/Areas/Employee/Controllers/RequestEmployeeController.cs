using AspDotNetTest.Areas.Employee.Service;
using AspDotNetTest.Models;
using Microsoft.AspNetCore.Mvc;

namespace AspDotNetTest.Areas.Employee.Controllers;
[Area("employee")]
[Route("employee/request")]
public class RequestEmployeeController : Controller
{
    private EmployeeReqService employeeReqService;

    public RequestEmployeeController(EmployeeReqService employeeReqService)
    {
        this.employeeReqService = employeeReqService;
    }


    [Route("add")]
    public IActionResult Add(YeuCau request)
    {
        ViewBag.employees = employeeReqService.findAllEmpl();
        ViewBag.priorities = employeeReqService.findPriority();

        if (employeeReqService.Create(request))
        {
            ViewBag.Msg = "Success";
            return View("Add");
        }
        else
        {
            ViewBag.Msg = "Failed";
            return View("Add", request);
        }


    }

}
