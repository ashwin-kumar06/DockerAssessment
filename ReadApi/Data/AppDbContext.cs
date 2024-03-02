using Microsoft.EntityFrameworkCore;
using ReadApi.Models;
namespace ReadApi.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<Model> Hospitals { get; set; }
    }
}
