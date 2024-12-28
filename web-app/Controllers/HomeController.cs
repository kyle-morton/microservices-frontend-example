using System.Diagnostics;
using System.Formats.Asn1;
using Microsoft.AspNetCore.Mvc;
using web_app.Models;
using web_app.Services;
using web_app.ViewModels;

namespace web_app.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IExampleService _exService;

    public HomeController(ILogger<HomeController> logger, IExampleService exService)
    {
        _logger = logger;
        _exService = exService;
    }

    public async Task<IActionResult> Index()
    {
        var posts = await _exService.GetPosts();
        return View(new IndexViewModel(posts));
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
