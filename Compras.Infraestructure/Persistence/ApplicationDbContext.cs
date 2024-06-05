using Compras.Domain.Entidades;
using Compras.Infraestructure.Persistence.EntityConfiguration;
using Microsoft.EntityFrameworkCore;

namespace Compras.Infraestructure.Persistence
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Producto> Productos { get; set; }
        public DbSet<Proveedor> Proveedores { get; set; }
        public DbSet<OrdenDeCompra> OrdenesCompras { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new ProductoConfiguration());
            builder.ApplyConfiguration(new ProveedorConfiguration());
            builder.ApplyConfiguration(new OrdenCompraConfiguration());
            builder.ApplyConfiguration(new OrdenProductoConfiguration());

        }
    }
}
