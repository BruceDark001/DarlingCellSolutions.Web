using DarlingCellSolutions.Domain.Entidades.Base;
using DarlingCellSolutions.Domain.Entidades.Inventario;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace DarlingCellSolutions.Domain.Entidades.Ventas;

public class DetalleVenta : EntidadBase
{
    public int Id { get; set; }

    public int VentaId { get; set; }

    public int ProductoId { get; set; }

    public int Cantidad { get; set; }

    public decimal PrecioUnitario { get; set; }

    public decimal SubTotal { get; set; }

    [ValidateNever]
    public Venta Venta { get; set; } = null!;

    [ValidateNever]
    public Producto Producto { get; set; } = null!;
}