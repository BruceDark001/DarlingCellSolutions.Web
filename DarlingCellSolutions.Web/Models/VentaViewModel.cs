using DarlingCellSolutions.Domain.Entidades.Ventas;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace DarlingCellSolutions.Web.Models;

public class VentaViewModel
{
    public Venta Venta { get; set; } = new();

    public List<DetalleVentaItemViewModel> Detalles { get; set; } = new();

    public IEnumerable<SelectListItem> Clientes { get; set; }
        = new List<SelectListItem>();

    public List<ProductoVentaViewModel> Productos { get; set; }
    = new();

    public IEnumerable<SelectListItem> Ordenes { get; set; }
        = new List<SelectListItem>();
}

public class DetalleVentaItemViewModel
{
    public int ProductoId { get; set; }

    public int Cantidad { get; set; }

    public decimal Precio { get; set; }

    public decimal SubTotal { get; set; }
}

public class ProductoVentaViewModel
{
    public int Id { get; set; }

    public string Nombre { get; set; } = string.Empty;

    public decimal Precio { get; set; }

    public int Stock { get; set; }
}