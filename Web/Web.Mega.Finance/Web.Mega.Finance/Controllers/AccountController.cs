using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Reflection.Metadata;
using Web.Mega.Finance.Models;
using Web.Mega.Finance.Repository;

namespace Web.Mega.Finance.Controllers
{
    public class AccountController : Controller
    {
        private readonly ILogger<AccountController> _logger;

        private string WebApiUrl = Settings.GetAppSetting("WebApiUrl"); 

        public AccountController(ILogger<AccountController> logger)
        {
            _logger = logger;
        }

        // GET: AccountController/Create
        public ActionResult Login(string message)
        {
            ViewBag.message = string.IsNullOrEmpty(message) ? string.Empty : message;

            return View();
        }

        // POST: AccountController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(ms_user form)
        {
            try
            {
                HttpContext.Session.Clear(); 
                BaseRepository api = new BaseRepository(WebApiUrl);
                var result = await api.Post("api/ApiUser/Login", form);
                if (!result.status) {
                    return RedirectToAction("Login", "Account", new { message = result.message });
                }
                else
                {
                    ms_user detail = JsonConvert.DeserializeObject<ms_user>(result.data.ToString());
                    HttpContext.Session.SetString("id", detail.user_id.ToString());
                    HttpContext.Session.SetString("username", detail.user_name.ToString());
                    return RedirectToAction("Index", "Home");
                };

               
            }
            catch
            {
                return RedirectToAction("Login", "Account"); 
            }
        }


    }
}
