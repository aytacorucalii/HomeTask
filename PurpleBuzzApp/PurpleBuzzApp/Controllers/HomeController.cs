using Microsoft.AspNetCore.Mvc;
using PurpleBuzzApp.Models;
using PurpleBuzzApp.ViewModels.Home;

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
            AboutAs aboutAs = new AboutAs()
            {
                Id= 1,
                Title = "Our Team.",
                Description = "Experienced cardiologist with over 20 years of practice.",
                Name = "John Doe ",
                Profession = "Business Development",
                ImageUrl= "team-01.jpg"
            };
            AboutAs aboutAs2 = new AboutAs()
            {
                Id=2,
                Title = "Our Team.",
                Description = "Experienced cardiologist with over 20 years of practice.",
                Name = "Johe Doe ",
                Profession = "Media Development",
                ImageUrl = "team-02.jpg"
            };
            AboutAs aboutAs3 = new AboutAs()
            {
                Id=3,
                Title = "Our Team.",
                Description = "Experienced cardiologist with over 20 years of practice.",
                Name = "Sam ",
                Profession = "Developer",
                ImageUrl = "team-03.jpg"
            };
            IEnumerable<AboutAs> abouts = new List<AboutAs>() { aboutAs, aboutAs2, aboutAs3 };
            HomeVM vm = new HomeVM() 
            { 
                abouts = abouts
            };
            return View(vm);
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
