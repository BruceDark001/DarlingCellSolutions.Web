using DarlingCellSolutions.Application.Interfaces;
using DarlingCellSolutions.Domain.Entidades.Ventas;
using DarlingCellSolutions.Infrastructure.Persistencia.Contexto;
using DarlingCellSolutions.Web.Filters;
using DarlingCellSolutions.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace DarlingCellSolutions.Web.Controllers;

[SessionAuthorize]
public class VentasController : Controller
{
    private readonly IVentaRepository _ventaRepository;
    private readonly DarlingCellSolutionsDbContext _context;

    public VentasController(
        IVentaRepository ventaRepository,
        DarlingCellSolutionsDbContext context)
    {
        _ventaRepository = ventaRepository;
        _context = context;
    }

    public async Task<IActionResult> Index()
    {
        var ventas = await _ventaRepository.ObtenerTodas();
        return View(ventas);
    }

    public async Task<IActionResult> Crear()
    {
        VentaViewModel vm = new();

        vm.Venta.NumeroComprobante = "BOL-" + DateTime.Now.Ticks.ToString().Substring(10);
        vm.Venta.FechaVenta = DateTime.Now;

        vm.Clientes = await _context.Clientes
            .Select(c => new SelectListItem
            {
                Value = c.Id.ToString(),
                Text = c.Nombres + " " + c.Apellidos
            })
            .ToListAsync();

        vm.Ordenes = await _context.OrdenesServicio
            .Select(o => new SelectListItem
            {
                Value = o.Id.ToString(),
                Text = o.NumeroOrden
            })
            .ToListAsync();

        vm.Productos = await _context.Productos
            .Where(p => p.Stock > 0)
            .Select(p => new ProductoVentaViewModel
            {
                Id = p.Id,
                Nombre = p.Nombre,
                Precio = p.PrecioVenta,
                Stock = p.Stock
            })
            .ToListAsync();

        return View(vm);
    }

    [HttpPost]
    public async Task<IActionResult> Crear(VentaViewModel model)
    {
        if (!ModelState.IsValid)
        {
            model.Clientes = await _context.Clientes
                .Select(c => new SelectListItem
                {
                    Value = c.Id.ToString(),
                    Text = c.Nombres + " " + c.Apellidos
                })
                .ToListAsync();

            model.Ordenes = await _context.OrdenesServicio
                .Select(o => new SelectListItem
                {
                    Value = o.Id.ToString(),
                    Text = o.NumeroOrden
                })
                .ToListAsync();

            model.Productos = await _context.Productos
                .Where(p => p.Stock > 0)
                .Select(p => new ProductoVentaViewModel
                {
                    Id = p.Id,
                    Nombre = p.Nombre,
                    Precio = p.PrecioVenta,
                    Stock = p.Stock
                })
                .ToListAsync();

            return View(model);
        }

        var detalles = new List<DetalleVenta>();

        foreach (var d in model.Detalles)
        {
            detalles.Add(new DetalleVenta
            {
                ProductoId = d.ProductoId,
                Cantidad = d.Cantidad,
                PrecioUnitario = d.Precio,
                SubTotal = d.SubTotal
            });
        }

        await _ventaRepository.GuardarVentaCompleta(model.Venta, detalles);

        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Eliminar(int id)
    {
        await _ventaRepository.Eliminar(id);
        return RedirectToAction(nameof(Index));
    }
}