using DarlingCellSolutions.Domain.Entidades.Clientes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DarlingCellSolutions.Infrastructure.Persistencia.Configuraciones;

public class ClienteConfiguration : IEntityTypeConfiguration<Cliente>
{
    public void Configure(EntityTypeBuilder<Cliente> builder)
    {
        // Nombre de la tabla
        builder.ToTable("Clientes");

        // Clave primaria
        builder.HasKey(c => c.Id);

        // Propiedades
        builder.Property(c => c.Dni)
               .HasMaxLength(8)
               .IsRequired();

        builder.Property(c => c.Nombres)
               .HasMaxLength(100)
               .IsRequired();

        builder.Property(c => c.Apellidos)
               .HasMaxLength(100)
               .IsRequired();

        builder.Property(c => c.Telefono)
               .HasMaxLength(20)
               .IsRequired();

        builder.Property(c => c.Correo)
               .HasMaxLength(100);

        builder.Property(c => c.Direccion)
               .HasMaxLength(250);

        builder.Property(c => c.Observaciones)
               .HasMaxLength(500);

        // Índice único
        builder.HasIndex(c => c.Dni)
               .IsUnique();
    }
}