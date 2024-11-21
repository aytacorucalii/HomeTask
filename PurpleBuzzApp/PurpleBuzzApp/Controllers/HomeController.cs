using Microsoft.AspNetCore.Mvc;

namespace PurpleBuzzApp.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult About()
        {
            return View();
        }
        public IActionResult Work()
        {
            return View();
        }
        public IActionResult Pricing()
        {
            return View();
        }

    }
}
