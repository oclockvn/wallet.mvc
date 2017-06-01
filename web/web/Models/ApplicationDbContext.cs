using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;
using web.Entities;

namespace web.Models
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, CustomRole, int, CustomUserLogin, CustomUserRole, CustomUserClaim>
    {
        public DbSet<Wallet> Wallets { get; set; }
        public DbSet<Item> Items { get; set; }

        public ApplicationDbContext() : base("DefaultConnection")
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}