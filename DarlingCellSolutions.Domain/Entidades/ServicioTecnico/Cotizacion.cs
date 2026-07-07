using DarlingCellSolutions.Domain.Entidades.Base;
using DarlingCellSolutions.Domain.Enumeraciones;

namespace DarlingCellSolutions.Domain.Entidades.ServicioTecnico;

public class Cotizacion : EntidadBase
{
    public int Id { get; set; }

    public int OrdenServicioId { get; set; }

    public decimal Monto { get; set; }

    public string Descripcion { get; set; } = string.Empty;

    public EstadoCotizacion EstadoCotizacion { get; set; } = EstadoCotizacion.Pendiente;

    public DateTime Fecha { get; set; } = DateTime.Now;
}