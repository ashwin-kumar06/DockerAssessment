using Microsoft.EntityFrameworkCore;
using CreateApi.Models;

namespace CreateApi.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<Model> Hospitals { get; set; }
    }
}
