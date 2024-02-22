using Microsoft.EntityFrameworkCore;

namespace AB_testing.Data
{
    public class AppdbContext : DbContext
    {
        public AppdbContext(DbContextOptions options) : base(options)
        {
        }
    }
}
