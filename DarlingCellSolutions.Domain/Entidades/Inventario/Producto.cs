using DarlingCellSolutions.Domain.Entidades.Base;

namespace DarlingCellSolutions.Domain.Entidades.Inventario;

public class Producto : EntidadBase
{
    public int Id { get; set; }

    public int CategoriaId { get; set; }

    public string Codigo { get; set; } = string.Empty;

    public string Nombre { get; set; } = string.Empty;

    public string? Descripcion { get; set; }

    public decimal PrecioCompra { get; set; }

    public decimal PrecioVenta { get; set; }

    public int Stock { get; set; }

    public int StockMinimo { get; set; }

    // Relaciones
    public Categoria Categoria { get; set; } = null!;

    public ICollection<MovimientoInventario> Movimientos { get; set; } = new List<MovimientoInventario>();
}