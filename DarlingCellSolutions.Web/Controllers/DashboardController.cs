using DarlingCellSolutions.Infrastructure.Persistencia.Contexto;
using DarlingCellSolutions.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DarlingCellSolutions.Web.Controllers;

public class DashboardController : Controller
{
    private readonly DarlingCellSolutionsDbContext _context;

    public DashboardController(DarlingCellSolutionsDbContext context)
    {
        _context = context;
    }
    public async Task<IActionResult> Index()
    {
        DashboardViewModel vm = new();

        vm.TotalClientes = await _context.Clientes.CountAsync();

        vm.TotalProductos = await _context.Productos.CountAsync();

        vm.TotalOrdenes = await _context.OrdenesServicio.CountAsync();

        vm.TotalVentas = await _context.Ventas.CountAsync();

        vm.IngresosTotales =
            await _context.Ventas.SumAsync(x => (decimal?)x.Total) ?? 0;

        vm.StockBajo =
            await _context.Productos.CountAsync(x => x.Stock <= x.StockMinimo);

        vm.ProductosStockBajo =
            await _context.Productos
                .Where(x => x.Stock <= x.StockMinimo)
                .OrderBy(x => x.Stock)
                .ToListAsync();

        vm.UltimasOrdenes =
            await _context.OrdenesServicio
                .OrderByDescending(x => x.Id)
                .Take(5)
                .ToListAsync();

        vm.UltimasVentas =
            await _context.Ventas
                .OrderByDescending(x => x.Id)
                .Take(5)
                .ToListAsync();

        return View(vm);
    }
}