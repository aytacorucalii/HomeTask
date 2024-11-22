using Microsoft.AspNetCore.Mvc;
using PurpleBuzzApp.Contexts;
using PurpleBuzzApp.Models;
using PurpleBuzzApp.ViewModels.ContactV;

namespace PurpleBuzzApp.Controllers
{
    public class ContactController : Controller
    {
        PurpleBuzzDBContexts dbContexts;
        public ContactController(PurpleBuzzDBContexts purpleBuzzDBContexts)
        {
            dbContexts = purpleBuzzDBContexts;
        }
        public IActionResult Index()
        {
            Contact contact = new Contact()
            {
                Id=1,
                Title= "Media Contact",
                Name= "Mr. John Doe",
                PhoneNumber= 010 - 020 - 0340,
                IconUrl= "display-6 bx bx-news"

            };
            Contact contact2 = new Contact()
            {
                Id = 2,
                Title = "Technical Contact",
                Name = "Mr. John Stiles",
                PhoneNumber = 010 - 020 - 0340,
                IconUrl = "bx bx-laptop display-6"
            };
            Contact contact3 = new Contact()
            {
                Id = 3,
                Title = "Billing Contact",
                Name = "Mr. Richard Miles",
                PhoneNumber = 010 - 020 - 0340,
                IconUrl = "bx bx-money display-6"
            };
            IEnumerable<Contact> contacts = new List<Contact>() {contact,contact2,contact3};
            ContactVM vm = new ContactVM()
            {
                Contacts = contacts,
            };
            dbContexts.Add(contact2);
            dbContexts.Add(contact3);
            dbContexts.Add(contact);
            dbContexts.SaveChanges();
            return View(vm);
        }
    }
}
