using Compras.Domain.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Compras.Infraestructure.Persistence.EntityConfiguration
{
    public class ProductoConfiguration : IEntityTypeConfiguration<Producto>
    {
        public void Configure(EntityTypeBuilder<Producto> builder)
        {
            builder.ToTable("Producto");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Id)
                .ValueGeneratedOnAdd();

            builder.Property(p => p.Descripcion)
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(p => p.FechaVencimiento)
                .IsRequired();

            builder.Property(p => p.PrecioVenta)
                .IsRequired();

            builder.Property(p => p.StockActual)
                .IsRequired();

            builder.Property(p => p.StockMinimo)
              .IsRequired();

            builder.Property(p => p.NumeroLote)
            .IsRequired();


            builder.HasOne<Proveedor>(p => p.Proveedor)
                .WithMany(p => p.Productos)
                .HasForeignKey(p => p.IdProveedor);

        }
    }
}
