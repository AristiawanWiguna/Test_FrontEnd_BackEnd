using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TestMcfMVC.Models;


using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Rendering;
using TestMcfMVC.Data;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using System.Text.Json;
using System.Text;
using Newtonsoft.Json;

namespace TestMcfMVC.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly DataContext _context;
        Uri baseAddress = new Uri("https://localhost:7299/api");
        private readonly HttpClient _client;

        public HomeController(ILogger<HomeController> logger, DataContext context)
        {
            _logger = logger;
            _context = context;
            _client = new HttpClient();
            _client.BaseAddress = baseAddress;
        }

        public IActionResult Index()
        {
            var model = new LocationModel
            {
                location_name_list = _context.ms_storage_location
                             .Select(e => new SelectListItem { Value = e.location_id.ToString(), Text = e.location_name.ToString()})
                             .ToList()
            };
            return View(model);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(
            string agreement_number, 
            string branch_id, 
            string bpkb_no, 
            DateTime bpkb_date, 
            string faktur_no, 
            DateTime faktur_date, 
            string location_id,
            string police_no,
            DateTime bpkb_date_in
            )
        {
            var bpkbData = new
            {
                agreement_number = agreement_number,
                bpkb_no = bpkb_no,
                branch_id = branch_id,
                bpkb_date = bpkb_date.ToString("yyyy-MM-dd"),
                faktur_no = faktur_no,
                faktur_date = faktur_date.ToString("yyyy-MM-dd"),
                location_id = location_id,
                police_no = police_no,
                bpkb_date_in = bpkb_date_in.ToString("yyyy-MM-dd"),
                created_by = HttpContext.Request.Cookies["id_bpkb"],
                created_on = DateTime.Now.ToString("yyyy-MM-dd"),
                last_updated_by = HttpContext.Request.Cookies["id_bpkb"],
                last_updated_on = DateTime.Now.ToString("yyyy-MM-dd"),
            };

            HttpResponseMessage response = _client.PostAsync(
               _client.BaseAddress + "/BPKB",
               new StringContent(JsonConvert.SerializeObject(bpkbData), Encoding.UTF8, "application/json")
           ).Result;

            return RedirectToAction("Index","Home");
        }

        public async Task<IActionResult> LogOut()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login","Login");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
