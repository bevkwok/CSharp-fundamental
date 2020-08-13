using Microsoft.EntityFrameworkCore;
namespace login_n_registration.Models
{
    public class MyContext : DbContext
    {
        public MyContext(DbContextOptions options) : base(options) { }

        public DbSet<User> login_n_registration {get; set;}
    }
}