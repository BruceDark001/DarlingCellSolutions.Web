using DarlingCellSolutions.Domain.Entidades.Base;

namespace DarlingCellSolutions.Domain.Entidades.Clientes;

public class Cliente : EntidadBase
{
    public int Id { get; set; }

    public string Dni { get; set; } = string.Empty;

    public string Nombres { get; set; } = string.Empty;

    public string Apellidos { get; set; } = string.Empty;

    public string Telefono { get; set; } = string.Empty;

    public string? Correo { get; set; }

    public string? Direccion { get; set; }

    public string? Observaciones { get; set; }

    // Relaciones
    public ICollection<Equipo> Equipos { get; set; } = new List<Equipo>();
}