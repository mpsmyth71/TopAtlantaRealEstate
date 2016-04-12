using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Data.Entity;

namespace TopAtlantaRealEstate.Models
{
    public class TopAtlantaContext : IdentityDbContext<TopAtlantaUser>
    {
        public TopAtlantaContext()
        {
            Database.EnsureCreated();
        }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Email> Emails { get; set; }
        public DbSet<Phone> Phones { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connString = Startup.Configuration["Data:TopAtlantaConnection:ConnectionString"];
            optionsBuilder.UseSqlServer(connString);
            base.OnConfiguring(optionsBuilder);
        }
    }
}
