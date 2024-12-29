using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using TeacherManagementUI.Dto.UserDto;
using TeacherManagementUI.Helpers;
using TeacherManagementApi.Security; // Token sınıfını kullanmak için gerekli

namespace TeacherManagementUI.Controllers
{
    public class AccountController : Controller
    {
        private readonly HttpClient _client = HttpClientIstance.CreateClient();

        public IActionResult Register()
        {
            return View();
        }

        // POST: Register
        [HttpPost]
        public async Task<IActionResult> Register(RegisterDto registerDto)
        {
            if (!ModelState.IsValid)
            {
                return View(registerDto);
            }

            // API'ye POST isteği gönder
            var response = await _client.PostAsJsonAsync("Authentications/Register", registerDto);
            if (response.IsSuccessStatusCode)
            {
                // Kayıt başarılı
                return RedirectToAction("Login");
            }
            else
            {
                var errorContent = await response.Content.ReadAsStringAsync();
                ViewBag.ErrorMessage = errorContent; // Hata mesajını ViewBag'e gönder
                return View(registerDto);
            }
        }

        public IActionResult Login()
        {
            return View();
        }

        // POST: Login
        [HttpPost]
        public async Task<IActionResult> Login(LoginDto loginDto)
        {
            if (!ModelState.IsValid)
            {
                return View(loginDto);
            }

            // API'ye POST isteği gönder
            var response = await _client.PostAsJsonAsync("Authentications/Login", loginDto);
            if (response.IsSuccessStatusCode)
            {
                // API'den dönen Token nesnesini al
                var token = await response.Content.ReadFromJsonAsync<Token>();

                // AccessToken'ı Session'da sakla
                if (token != null)
                {
                    HttpContext.Session.SetString("AuthToken", token.AccessToken);
                }

                // Başarılı giriş sonrası LoginsController'a yönlendiriyoruz
                return RedirectToAction("Index", "Logins");
            }

            // Hata durumunda
            ViewBag.ErrorMessage = "Giriş başarısız. Kullanıcı adı veya şifre yanlış.";
            return View(loginDto);
        }

        // Logout işlemi
        [Authorize]
        [HttpPost("Logout")]
        public async Task<IActionResult> Logout()
        {
            // API'ye Logout isteği gönder
            var response = await _client.PostAsync("Authentications/Logout", null);
            if (response.IsSuccessStatusCode)
            {
                // Token veya session'ı temizle
                HttpContext.Session.Remove("AuthToken");
                return RedirectToAction("Login");
            }

            // Eğer API başarısız olursa
            ViewBag.ErrorMessage = "Çıkış işlemi başarısız oldu.";
            return RedirectToAction("Index", "Home");
        }
    }
}
