using Microsoft.EntityFrameworkCore;
using PurpleBuzzApp.Helper;
using PurpleBuzzApp.Models;

namespace PurpleBuzzApp.Contexts
{
    public class PurpleBuzzDBContexts: DbContext
    {   public DbSet<AboutAs> AboutAs { get; set; }
        public DbSet<Contact> Contacts { get; set; }

        public PurpleBuzzDBContexts(DbContextOptions options):base(options)
        {
            
        }
    }
}
