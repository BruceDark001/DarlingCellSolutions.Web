using DarlingCellSolutions.Domain.Entidades.Base;
using DarlingCellSolutions.Domain.Enumeraciones;

namespace DarlingCellSolutions.Domain.Entidades.Ventas;

public class Venta : EntidadBase
{
    public int Id { get; set; }

    public int ClienteId { get; set; }

    public int? OrdenServicioId { get; set; }

    public TipoComprobante TipoComprobante { get; set; }

    public string NumeroComprobante { get; set; } = string.Empty;

    public decimal SubTotal { get; set; }

    public decimal Igv { get; set; }

    public decimal Total { get; set; }

    public DateTime FechaVenta { get; set; } = DateTime.Now;
}