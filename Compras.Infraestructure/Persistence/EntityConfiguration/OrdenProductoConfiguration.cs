using Compras.Domain.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Compras.Infraestructure.Persistence.EntityConfiguration
{
    public class OrdenProductoConfiguration : IEntityTypeConfiguration<OrdenProducto>
    {
        public void Configure(EntityTypeBuilder<OrdenProducto> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).ValueGeneratedOnAdd();

            builder.HasOne(ordenCompra => ordenCompra.Producto)
                .WithMany(producto => producto.OrdenProductos)
                .HasForeignKey(ordenCompra => ordenCompra.IdProducto)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(ordenCompra => ordenCompra.OrdenCompra)
                .WithMany(orden => orden.OrdenProductos)
                .HasForeignKey(ordenCompra => ordenCompra.IdOrdenCompra)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Property(x => x.Cantidad).IsRequired();
        }
    }
}
