using DarlingCellSolutions.Domain.Entidades.Base;

namespace DarlingCellSolutions.Domain.Entidades.ServicioTecnico;

public class Garantia : EntidadBase
{
    public int Id { get; set; }

    public int OrdenServicioId { get; set; }

    public DateTime FechaInicio { get; set; }

    public DateTime FechaFin { get; set; }

    public string? Observaciones { get; set; }
}