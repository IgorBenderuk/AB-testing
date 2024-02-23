using AB_testing.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace AB_testing.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<ButtonColor> ButtonColors { get; set; }
        public DbSet<PurchaseProfit> PurchaseCosts { get; set; }

    }
}
