using Microsoft.EntityFrameworkCore;

namespace net_core_web.Model
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Friend> Friends { get; set; }
    }
}