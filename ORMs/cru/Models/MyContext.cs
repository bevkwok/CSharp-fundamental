using Microsoft.EntityFrameworkCore;

namespace cru.Models
{
    public class MyContext : DbContext
    {
        public MyContext(DbContextOptions options) : base(options) {}

        public DbSet<Dishes> Dishes {get; set;}
    }
}