using Compras.Domain.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Compras.Infraestructure.Persistence.EntityConfiguration
{
    public class OrdenCompraConfiguration : IEntityTypeConfiguration<OrdenDeCompra>
    {
        public void Configure(EntityTypeBuilder<OrdenDeCompra> builder)
        {
            builder.ToTable("OrdenDeCompra");

            builder.HasKey(o => o.Id);

            builder.Property(o => o.Id)
                .ValueGeneratedOnAdd();

            builder.Property(o => o.Descripcion)
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(o => o.Fecha)
                .IsRequired()
                .HasDefaultValueSql("GETDATE()");

            builder.HasOne<Proveedor>(o => o.Proveedor)
                .WithMany(p => p.OrdenesDeCompra)
                .HasForeignKey(o => o.IdProveedor);
        }
    }
}
