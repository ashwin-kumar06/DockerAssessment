using Microsoft.EntityFrameworkCore;
using UpdateApi.Models;
namespace UpdateApi.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<Model> Hospitals { get; set; }
    }
}
