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
        public DbSet<Routes> Routes { get; set; } = default!;
        
        // public DbSet<Users> Users { get; set; }
        // public DbSet<Cliente> Clientes { get; set; }
        // public DbSet<Proveedor> Proveedores { get; set; }
    }
}