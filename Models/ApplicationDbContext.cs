using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace SoftGnet.Models
{
    
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
    
        public DbSet<Users> Users { get; set; } = default!;
        public DbSet<Drivers> Drivers { get; set; } = default!;
        public DbSet<Vehicles> Vehicles { get; set; } = default!;
        public DbSet<RoutesModel> RoutesModel { get; set; } = default!;
        public DbSet<Schedules> Schedules { get; set; } = default!;

    }
}