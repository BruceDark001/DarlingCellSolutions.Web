using DarlingCellSolutions.Application.Interfaces;
using DarlingCellSolutions.Domain.Entidades.Inventario;
using DarlingCellSolutions.Infrastructure.Persistencia.Contexto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace DarlingCellSolutions.Web.Controllers;

public class ProductosController : Controller
{
    private readonly IProductoRepository _productoRepository;
    private readonly DarlingCellSolutionsDbContext _context;

    public ProductosController(
        IProductoRepository productoRepository,
        DarlingCellSolutionsDbContext context)
    {
        _productoRepository = productoRepository;
        _context = context;
    }

    public async Task<IActionResult> Index()
    {
        var productos = await _productoRepository.ObtenerTodos();
        return View(productos);
    }

    public async Task<IActionResult> Crear()
    {
        ViewBag.Categorias = new SelectList(
            await _context.Categorias.ToListAsync(),
            "Id",
            "Nombre");

        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Crear(Producto producto)
    {
        if (!ModelState.IsValid)
        {
            ViewBag.Categorias = new SelectList(
                await _context.Categorias.ToListAsync(),
                "Id",
                "Nombre");

            return View(producto);
        }

        await _productoRepository.Agregar(producto);

        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Editar(int id)
    {
        var producto = await _productoRepository.ObtenerPorId(id);

        if (producto == null)
            return NotFound();

        ViewBag.Categorias = new SelectList(
            await _context.Categorias.ToListAsync(),
            "Id",
            "Nombre",
            producto.CategoriaId);

        return View(producto);
    }

    [HttpPost]
    public async Task<IActionResult> Editar(Producto producto)
    {
        if (!ModelState.IsValid)
        {
            ViewBag.Categorias = new SelectList(
                await _context.Categorias.ToListAsync(),
                "Id",
                "Nombre",
                producto.CategoriaId);

            return View(producto);
        }

        await _productoRepository.Actualizar(producto);

        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Eliminar(int id)
    {
        await _productoRepository.Eliminar(id);

        return RedirectToAction(nameof(Index));
    }
}