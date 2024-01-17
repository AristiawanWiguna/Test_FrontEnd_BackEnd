using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Text.Json;
using System.Text;
using Microsoft.AspNetCore.Authorization;

using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace TestMcfMVC.Controllers
{
    
    public class LoginController : Controller
    {
        Uri baseAddress = new Uri("https://localhost:7299/api");
        private readonly HttpClient _client;

        public LoginController()
        {
            _client = new HttpClient();
            _client.BaseAddress = baseAddress;
        }

        
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Login()
        {
            ClaimsPrincipal claimUser = HttpContext.User;

            if(claimUser.Identity.IsAuthenticated )
            {
                return RedirectToAction("Index","Home");
            }

            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(string username, string password)
        {
            var loginData = new
            {
                user_name = username,
                password = password
            };

            HttpResponseMessage response = await _client.PostAsync(
               _client.BaseAddress + "/Auth/login",
               new StringContent(JsonSerializer.Serialize(loginData), Encoding.UTF8, "application/json")
           );

            string responseBody = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
            {
                List<Claim> Claims = new List<Claim>()
                {
                    new Claim(ClaimTypes.Name, username),
                    new Claim(ClaimTypes.AuthenticationInstant, responseBody),
                };

                ClaimsIdentity claimsIdentity = new ClaimsIdentity(Claims,
                    CookieAuthenticationDefaults.AuthenticationScheme);

                AuthenticationProperties properties = new AuthenticationProperties()
                {
                    AllowRefresh = true,
                };

                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                    new ClaimsPrincipal(claimsIdentity), properties);

                SetCookieValue("id_bpkb", responseBody);

                return RedirectToAction("Index","Home");
            }

            ViewData["ValidateMessage"] = "user not found";
            return View();
        }

        private void SetCookieValue(string key, string value)
        {
            // Simpan nilai dalam cookie dengan waktu kedaluwarsa yang sesuai
            var cookieOptions = new CookieOptions
            {
                Expires = DateTime.Now.AddMinutes(30), // Ganti sesuai kebutuhan
                HttpOnly = true
            };

            HttpContext.Response.Cookies.Append(key, value, cookieOptions);
        }
    }
}
