using DarlingCellSolutions.Domain.Entidades.Base;

namespace DarlingCellSolutions.Domain.Entidades.Clientes;

public class Equipo : EntidadBase
{
    public int Id { get; set; }

    public int ClienteId { get; set; }

    public int MarcaId { get; set; }

    public int TipoEquipoId { get; set; }

    public string Modelo { get; set; } = string.Empty;

    public string? NumeroSerie { get; set; }

    public string? IMEI { get; set; }

    public string? Color { get; set; }

    public string? PatronBloqueo { get; set; }

    public string? Observaciones { get; set; }

    // Relaciones
    public Cliente Cliente { get; set; } = null!;

    public Marca Marca { get; set; } = null!;

    public TipoEquipo TipoEquipo { get; set; } = null!;
}