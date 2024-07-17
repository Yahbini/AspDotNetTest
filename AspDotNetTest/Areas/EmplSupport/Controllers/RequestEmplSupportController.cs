using AspDotNetTest.Areas.Admin.Service;
using AspDotNetTest.Areas.Employee.Service;
using Microsoft.AspNetCore.Mvc;

namespace AspDotNetTest.Areas.EmplSupport.Controllers;

[Area("emplsupport")]
[Route("emplsupport/request")]
public class RequestEmplSupportController : Controller
{
    private RequestService requestService;
    private EmployeeReqService employeeReqService;
    public RequestEmplSupportController(RequestService requestService, EmployeeReqService employeeReqService)
    {
        this.requestService = requestService;
        this.employeeReqService = employeeReqService;
    }

    [HttpGet]
    [Route("index/{id}")]
    public IActionResult Index(int id)
    {
        var request = requestService.findById(id);
        return View("Index", request);
    }
}
