using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using DarlingCellSolutions.Domain.Entidades.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DarlingCellSolutions.Domain.Entidades.Inventario;

public class Producto : EntidadBase
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Ingrese la categoría")]
    public int CategoriaId { get; set; }

    [Required(ErrorMessage = "Ingrese el código")]
    [StringLength(50)]
    public string Codigo { get; set; } = string.Empty;

    [Required(ErrorMessage = "Ingrese el nombre")]
    [StringLength(150)]
    public string Nombre { get; set; } = string.Empty;

    [StringLength(300)]
    public string? Descripcion { get; set; }

    [Required(ErrorMessage = "Ingrese el precio de compra")]
    [Range(0.01, 999999)]
    public decimal PrecioCompra { get; set; }

    [Required(ErrorMessage = "Ingrese el precio de venta")]
    [Range(0.01, 999999)]
    public decimal PrecioVenta { get; set; }

    [Required(ErrorMessage = "Ingrese el stock")]
    [Range(0, 999999)]
    public int Stock { get; set; }

    [Required(ErrorMessage = "Ingrese el stock mínimo")]
    [Range(0, 999999)]
    public int StockMinimo { get; set; }

    // Relaciones (no se validan desde el formulario)
    [ValidateNever]
    public Categoria? Categoria { get; set; }

    [ValidateNever]
    public ICollection<MovimientoInventario> Movimientos { get; set; } = new List<MovimientoInventario>();
}