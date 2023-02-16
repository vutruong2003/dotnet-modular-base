using Microsoft.AspNetCore.Mvc;
using Shared.Core.Contracts;

namespace Module.Home.Controllers;

[ApiController]
[Route("/")]
public class HomeController : ControllerBase
{

    private readonly IEnumerable<ITestService> _testServices;
    private readonly ITestService _testService;

    public HomeController(ITestService testService, IEnumerable<ITestService> testServices)
    {
        _testService = testService;
        _testServices = testServices;
    }

    [HttpGet]
    public IActionResult Get(string message = null!)
    {
        _testService.Log(message ?? "Empty Message");

        foreach(var test in _testServices)
        {
            test.Log(message ?? "Empty Message");
        }

        return Ok("Home Api");
    }
}
