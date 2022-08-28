using ManagerRecords.Model;
using Microsoft.EntityFrameworkCore;

namespace ManagerRecords.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<Recordes> Recordes { get; set; }
    }
}
