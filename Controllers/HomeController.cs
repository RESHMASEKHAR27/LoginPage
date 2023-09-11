using LoginPage.Data;
using LoginPage.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace LoginPage.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]

        public IActionResult Index(User user, LoginData loginData)
        {
            if (!ModelState.IsValid)
            {
                return View(user);
            }

            LoginData logindata = new LoginData();
            int id = loginData.Check(user.Username, user.Password);
            if (id == 0)
            {
                TempData["Error"] = "Invalid Credentials";
                return View(logindata);
            }

            HttpContext.Session.SetString("Log", id.ToString());
            return RedirectToAction("Privacy");

        }


        public IActionResult Privacy()
        {
            int Id = Convert.ToInt32(HttpContext.Session.GetString("Log"));
            string Name = new LoginData().select(Id);
            ViewBag.Session = Name;
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}