using Microsoft.AspNetCore.Mvc;
using PurpleBuzzApp.Models;

namespace PurpleBuzzApp.Controllers
{
    public class ContactController : Controller
    {
        public IActionResult Index()
        {
            Contact contact = new Contact() { Id = 1, MediaContact = "Media Contact", MediaName = "Mr. John Doe", MediaNumber = 010 - 020 - 0340 };
            Contact contact1 = new Contact() { Id = 2, BillingContact = "Billing Contact", BillingName = "Mr. Richard Miles", BillingNumber = 0100200340 };
            ICollection<Contact> contacts = new List<Contact>() {  contact,contact1 };
            return View();
        }
    }
}
