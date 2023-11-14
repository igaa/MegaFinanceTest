using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;
using Web.Mega.Finance.Models;
using Web.Mega.Finance.Repository;

namespace Web.Mega.Finance.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private string WebApiUrl = Settings.GetAppSetting("WebApiUrl");

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            if(string.IsNullOrEmpty(HttpContext.Session.GetString("id"))) return RedirectToAction("Login", "Account");

            return RedirectToAction("Index", "Bpkb"); 
            
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}