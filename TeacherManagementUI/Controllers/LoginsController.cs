using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace TeacherManagementUI.Controllers
{
    [Authorize] 
    public class LoginsController : Controller
    {
        public IActionResult Index()
        {
            var token = HttpContext.Session.GetString("AuthToken");
            if (string.IsNullOrEmpty(token))
            {
                return RedirectToAction("Login", "Account");
            }

            return View();
        }
    }
}
