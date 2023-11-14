using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Web.Mega.Finance.Models;
using Web.Mega.Finance.Repository;

namespace Web.Mega.Finance.Controllers
{
    public class BpkbController : Controller
    {
        private string WebApiUrl = Settings.GetAppSetting("WebApiUrl");
        // GET: BpkbController
        public async Task<ActionResult> Index()
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("id"))) return RedirectToAction("Login", "Account");
            BaseRepository api = new BaseRepository(WebApiUrl);
            var result = await api.Get("api/ApiBpkb/Get");
            var masterlocation = await api.Get("api/ApiLocation/Get");
            ViewBag.masterLocation = JsonConvert.DeserializeObject<IEnumerable<ms_storage_location>>(masterlocation.data.ToString());

            IEnumerable<tr_bpkb> list = JsonConvert.DeserializeObject<IEnumerable<tr_bpkb>>(result.data.ToString());
            return View(list);
        }

        // GET: BpkbController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("id"))) return RedirectToAction("Login", "Account");
            BaseRepository api = new BaseRepository(WebApiUrl);
            var result = await api.Get("api/ApiBpkb/GetBy?Id="+ id);
            tr_bpkb data = JsonConvert.DeserializeObject<tr_bpkb>(result.data.ToString());
            return View(data);
        }

        // GET: BpkbController/Create
        public async Task<ActionResult> Create()
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("id"))) return RedirectToAction("Login", "Account");
            BaseRepository api = new BaseRepository(WebApiUrl);
            var result = await api.Get("api/ApiLocation/Get");
            ViewBag.masterLocation  = JsonConvert.DeserializeObject<IEnumerable<ms_storage_location>>(result.data.ToString());
            return View();
        }

        // POST: BpkbController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(tr_bpkb form )
        {
            try
            {
                BaseRepository api = new BaseRepository(WebApiUrl);
                form.created_by = HttpContext.Session.GetString("username");
                form.created_on = DateTime.Now; 
                var result = await api.Post("api/ApiBpkb/Post", form);
                var data = JsonConvert.DeserializeObject<tr_bpkb>(result.data.ToString());
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: BpkbController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("id"))) return RedirectToAction("Login", "Account");
            BaseRepository api = new BaseRepository(WebApiUrl);
            var result = await api.Get("api/ApiBpkb/GetBy?Id=" + id);
            tr_bpkb data = JsonConvert.DeserializeObject<tr_bpkb>(result.data.ToString());

            var masterlocation = await api.Get("api/ApiLocation/Get");
            ViewBag.masterLocation = JsonConvert.DeserializeObject<IEnumerable<ms_storage_location>>(masterlocation.data.ToString());
            return View(data);
        }

        // POST: BpkbController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(tr_bpkb form)
        {
            try
            {
                BaseRepository api = new BaseRepository(WebApiUrl);
                form.last_updated_by = HttpContext.Session.GetString("username");
                form.last_updated_on = DateTime.Now;
                var result = await api.Post("api/ApiBpkb/Update", form);
                var data  = JsonConvert.DeserializeObject<tr_bpkb>(result.data.ToString());
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: BpkbController/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("id"))) return RedirectToAction("Login", "Account");

            BaseRepository api = new BaseRepository(WebApiUrl);
            var result = await api.Get("api/ApiBpkb/GetBy?Id=" + id);
            tr_bpkb data = JsonConvert.DeserializeObject<tr_bpkb>(result.data.ToString());
            return View(data);
        }

        // POST: BpkbController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(tr_bpkb form)
        {
            try
            {
                BaseRepository api = new BaseRepository(WebApiUrl);
                var result = await api.Post("api/ApiBpkb/Delete", form);
                var data = JsonConvert.DeserializeObject<tr_bpkb>(result.data.ToString());
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
