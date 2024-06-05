using Compras.Domain.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Compras.Infraestructure.Persistence.EntityConfiguration
{
    public class ProveedorConfiguration : IEntityTypeConfiguration<Proveedor>
    {
        public void Configure(EntityTypeBuilder<Proveedor> builder)
        {
            builder.ToTable("Proveedor");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Id).ValueGeneratedOnAdd();

            builder.Property(p => p.Nombre)
                .HasMaxLength(30)
                .IsRequired();

            builder.Property(p => p.Apellido)
                 .HasMaxLength(30)
                .IsRequired();

            builder.Property(p => p.Apellido).IsRequired();
            builder.Property(f => f.Telefono).IsRequired();

            builder.Property(f => f.Direccion)
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(f => f.Cuil).IsRequired();

            builder.Property(f => f.NombreEmpresa)
                .HasMaxLength(50)
                .IsRequired();
        }
    }
}
