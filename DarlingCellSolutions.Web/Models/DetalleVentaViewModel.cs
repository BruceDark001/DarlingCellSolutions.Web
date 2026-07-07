namespace DarlingCellSolutions.Web.Models;

public class DetalleVentaViewModel
{
    public int ProductoId { get; set; }

    public string Producto { get; set; } = string.Empty;

    public decimal Precio { get; set; }

    public int Cantidad { get; set; }

    public decimal SubTotal { get; set; }
}