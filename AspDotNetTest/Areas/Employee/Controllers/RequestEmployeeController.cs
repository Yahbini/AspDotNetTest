using AspDotNetTest.Areas.Admin.Service;
using AspDotNetTest.Areas.Employee.Service;
using AspDotNetTest.Models;
using Microsoft.AspNetCore.Mvc;

namespace AspDotNetTest.Areas.Employee.Controllers;
[Area("employee")]
[Route("employee/request")]
public class RequestEmployeeController : Controller
{
    private EmployeeReqService employeeReqService;
    private RequestService requestService;

    public RequestEmployeeController(EmployeeReqService employeeReqService, RequestService requestService)
    {
        this.employeeReqService = employeeReqService;
        this.requestService = requestService;
    }

    [HttpGet]
    [Route("add")]
    public IActionResult Add()
    {
        ViewBag.employees = employeeReqService.findAllEmpl();
        ViewBag.priorities = employeeReqService.findPriority();

        return View("Add");


    }

    [HttpPost]
    [Route("add")]
    public IActionResult Add(YeuCau request)
    {
        ViewBag.employees = employeeReqService.findAllEmpl();
        ViewBag.priorities = employeeReqService.findPriority();

        if (employeeReqService.Create(request))
        {
            ViewBag.Msg = "Create Request Successfully";
            return RedirectToAction("index", "dashboardemployee", new { area = "employee" });
        }
        else
        {
            ViewBag.Msg = "Request Creation Unsuccessful";
            return View("Add");
        }


    }

    [HttpGet]
    [Route("index/{id}")]
    public IActionResult Index(int id)
    {
        var request = employeeReqService.findRequestByID(id);
        ViewBag.priorities = employeeReqService.findPriority();
        return View("Index", request);
    }

    [HttpPost]
    [Route("index/{id}")]
    public IActionResult Index(int id, YeuCau yeuCau)
    {
        var request = employeeReqService.findRequestByID(id);
        ViewBag.priorities = employeeReqService.findPriority();

        request.Tieude = yeuCau.Tieude;
        request.Noidung = yeuCau.Noidung;
        request.Ngaygui = yeuCau.Ngaygui;
        request.Madouutien = yeuCau.Madouutien;

        if (requestService.UpdateRequest(request))
        {

            return RedirectToAction("index", "dashboard", new { area = "employee" });
        }
        else
        {
            ViewBag.Msg = "Failed";
            return View("Index");
        }


    }
}
