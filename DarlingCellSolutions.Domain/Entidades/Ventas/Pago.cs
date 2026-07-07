using DarlingCellSolutions.Domain.Entidades.Base;
using DarlingCellSolutions.Domain.Enumeraciones;

namespace DarlingCellSolutions.Domain.Entidades.Ventas;

public class Pago : EntidadBase
{
    public int Id { get; set; }

    public int VentaId { get; set; }

    public MetodoPago MetodoPago { get; set; }

    public decimal Monto { get; set; }

    public string? Referencia { get; set; }

    public DateTime FechaPago { get; set; } = DateTime.Now;
}