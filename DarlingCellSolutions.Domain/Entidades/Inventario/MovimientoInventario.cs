using DarlingCellSolutions.Domain.Entidades.Base;
using DarlingCellSolutions.Domain.Enumeraciones;

namespace DarlingCellSolutions.Domain.Entidades.Inventario;

public class MovimientoInventario : EntidadBase
{
    public int Id { get; set; }

    public int ProductoId { get; set; }

    public TipoMovimientoInventario TipoMovimiento { get; set; }

    public int Cantidad { get; set; }

    public string? Motivo { get; set; }

    // Relación
    public Producto Producto { get; set; } = null!;
}