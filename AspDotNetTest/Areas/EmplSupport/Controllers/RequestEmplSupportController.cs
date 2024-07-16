using AspDotNetTest.Areas.EmplSupport.Service;
using Microsoft.AspNetCore.Mvc;

namespace AspDotNetTest.Areas.EmplSupport.Controllers;

[Area("emplsupport")]
[Route("emplsupport/request")]
public class RequestEmplSupportController : Controller
{
    private RequestEmplSupportService requestService;

    public RequestEmplSupportController(RequestEmplSupportService requestService)
    {
        this.requestService = requestService;
    }


}
