using FuelQuoteApp_p1.EntModels.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FuelQuoteApp_p1.Models.Account
{
    public class FuelQuoteDBContext : IdentityDbContext
    {
        public FuelQuoteDBContext(DbContextOptions<FuelQuoteDBContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

        }

        public DbSet<Client> Client { get; set; }

        public DbSet<User> UsersInfo { get; set; }

        public DbSet<FuelQuoteApp_p1.EntModels.Models.Quote> FuelQuote { get; set; }

    }
}