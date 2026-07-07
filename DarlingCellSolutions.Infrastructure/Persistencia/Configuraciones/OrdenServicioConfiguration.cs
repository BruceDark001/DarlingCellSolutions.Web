using DarlingCellSolutions.Domain.Entidades.ServicioTecnico;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DarlingCellSolutions.Infrastructure.Persistencia.Configuraciones;

public class OrdenServicioConfiguration : IEntityTypeConfiguration<OrdenServicio>
{
    public void Configure(EntityTypeBuilder<OrdenServicio> builder)
    {
        builder.ToTable("OrdenesServicio");

        builder.HasKey(x => x.Id);

        builder.HasOne(x => x.Cliente)
            .WithMany()
            .HasForeignKey(x => x.ClienteId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(x => x.Equipo)
            .WithMany()
            .HasForeignKey(x => x.EquipoId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(x => x.Tecnico)
            .WithMany()
            .HasForeignKey(x => x.TecnicoId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(x => x.EstadoReparacion)
            .WithMany()
            .HasForeignKey(x => x.EstadoReparacionId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}