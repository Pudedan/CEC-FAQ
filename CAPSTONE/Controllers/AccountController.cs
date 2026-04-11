using Microsoft.AspNetCore.Mvc;
using CAPSTONE.Models;

namespace CAPSTONE.Controllers
{
    public class AccountController : Controller
    {
        private static AdminUser admin = new AdminUser
        {
            Username = "admin",
            Password = "1234"
        };

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(AdminUser user)
        {
            if (user.Username == admin.Username && user.Password == admin.Password)
            {
                HttpContext.Session.SetString("User", user.Username!);
                return RedirectToAction("Admin", "FAQ");
            }

            ViewBag.Error = "Invalid username or password";
            return View();
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }


    }
}