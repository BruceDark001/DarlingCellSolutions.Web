using DarlingCellSolutions.Domain.Entidades.Base;

namespace DarlingCellSolutions.Domain.Entidades.Clientes;

public class TipoEquipo : EntidadBase
{
    public int Id { get; set; }

    public string Nombre { get; set; } = string.Empty;

    // Relaciones
    public ICollection<Equipo> Equipos { get; set; } = new List<Equipo>();
}