using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using UDRF.Models;
using UDRF.Services.TokenService;
using UDRF.Utility;

namespace UDRF.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly ITokenRequestService _tokenService;

    public HomeController(ILogger<HomeController> logger, ITokenRequestService tokenService)
    {
        _logger = logger;
        _tokenService = tokenService;
    }

    private async Task<string> GetToken()
    {
        var tokenValue = "";
        var bcnUsername = StaticConfigurationManager.AppSetting["AccessUsers:user"];
        var bcnPassword = StaticConfigurationManager.AppSetting["AccessUsers:pass"];
        if (bcnUsername != "" && bcnPassword != "")
            tokenValue = await _tokenService.ManageToken(bcnUsername, bcnPassword);
        return tokenValue;
    }
    public async Task< IActionResult> Index()
    {
        var token = await GetToken();

        //var api1Name = StaticConfigurationManager.AppSetting["PublicApi:api1:name"];
        //var api1Desc = StaticConfigurationManager.AppSetting["PublicApi:api1:descrip"];
        //var api1Add = StaticConfigurationManager.AppSetting["PublicApi:api1:address"];

        return View();
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

