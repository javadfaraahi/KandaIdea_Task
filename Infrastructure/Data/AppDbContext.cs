using KandaIdea_Task.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace KandaIdea_Task.Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options ) : base ( options )
        {
            
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Province> Provinces { get; set; }
        public DbSet<City> Cities { get; set; }
    }
}
