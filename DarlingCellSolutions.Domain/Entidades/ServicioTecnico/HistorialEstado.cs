using DarlingCellSolutions.Domain.Entidades.Base;

namespace DarlingCellSolutions.Domain.Entidades.ServicioTecnico;

public class HistorialEstado : EntidadBase
{
    public int Id { get; set; }

    public int OrdenServicioId { get; set; }

    public int EstadoReparacionId { get; set; }

    public DateTime Fecha { get; set; } = DateTime.Now;

    public string? Observacion { get; set; }
}