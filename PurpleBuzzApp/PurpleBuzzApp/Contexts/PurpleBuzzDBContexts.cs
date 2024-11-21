using Microsoft.EntityFrameworkCore;
using PurpleBuzzApp.Helper;
using PurpleBuzzApp.Models;

namespace PurpleBuzzApp.Contexts
{
    public class PurpleBuzzDBContexts: DbContext
    {   public DbSet<AboutAs> AboutAs { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(SqlHelper.GetConnectionString());
            base.OnConfiguring(optionsBuilder);
        }
    }
}
