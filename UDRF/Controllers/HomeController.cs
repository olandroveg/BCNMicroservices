using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using UDRF.Models;
using UDRF.Services.IdNRFService;
using UDRF.Services.NRFService;
using UDRF.Services.TokenService;
using UDRF.Utility;

namespace UDRF.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly ITokenRequestService _tokenService;
    private readonly INRFService _nRFService;
    private readonly IIdNRFService _idNRFService;

    public HomeController(ILogger<HomeController> logger, ITokenRequestService tokenService,
        INRFService nRFService, IIdNRFService idNRFService)
    {
        _logger = logger;
        _tokenService = tokenService;
        _nRFService = nRFService;
        _idNRFService = idNRFService;
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
        var incomeNF = _nRFService.ConformNFDto();
        var nfId = await _nRFService.RegisterNF(token, incomeNF);
        try
        {
            await _idNRFService.AddOrUpdate(new IDinNRF
            {
                Id = nfId
            });
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
        }
        
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

