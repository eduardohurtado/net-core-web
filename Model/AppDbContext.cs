using Microsoft.EntityFrameworkCore;

namespace net_core_web.Model
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Friend> Friends { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Friend>().HasData(new Friend
            {
                Id = 1,
                Name = "Test SQL",
                City = Province.Buenaventura,
                Email = "test@test.com"
            }
            );
        }
    }
}