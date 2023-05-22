using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
//using CourseWebsite.Models;

namespace VinaOfficeWebsite.Controllers;

public class ErrorController : Controller
{
    private readonly ILogger<ErrorController> _logger;

    public ErrorController(ILogger<ErrorController> logger)
    {
        _logger = logger;
    }

    public IActionResult Page404()
    {
        return View();
    }
}

