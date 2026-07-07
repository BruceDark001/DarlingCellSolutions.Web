using DarlingCellSolutions.Domain.Entidades.Inventario;
using DarlingCellSolutions.Domain.Entidades.ServicioTecnico;
using DarlingCellSolutions.Domain.Entidades.Ventas;

namespace DarlingCellSolutions.Web.Models;

public class DashboardViewModel
{
    public int TotalClientes { get; set; }

    public int TotalProductos { get; set; }

    public int TotalOrdenes { get; set; }

    public int TotalVentas { get; set; }

    public decimal IngresosTotales { get; set; }

    public int StockBajo { get; set; }

    public List<Producto> ProductosStockBajo { get; set; } = new();

    public List<OrdenServicio> UltimasOrdenes { get; set; } = new();

    public List<Venta> UltimasVentas { get; set; } = new();
}