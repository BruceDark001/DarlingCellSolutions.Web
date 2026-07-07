using DarlingCellSolutions.Application.Interfaces;
using DarlingCellSolutions.Domain.Entidades.Clientes;
using DarlingCellSolutions.Infrastructure.Persistencia.Contexto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace DarlingCellSolutions.Web.Controllers;

public class EquiposController : Controller
{
    private readonly IEquipoRepository _equipoRepository;
    private readonly DarlingCellSolutionsDbContext _context;

    public EquiposController(
        IEquipoRepository equipoRepository,
        DarlingCellSolutionsDbContext context)
    {
        _equipoRepository = equipoRepository;
        _context = context;
    }

    // LISTAR
    public async Task<IActionResult> Index()
    {
        var equipos = await _equipoRepository.ObtenerTodos();
        return View(equipos);
    }

    // CREAR
    public async Task<IActionResult> Crear()
    {
        await CargarCombos();
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Crear(Equipo equipo)
    {
        if (!ModelState.IsValid)
        {
            await CargarCombos();
            return View(equipo);
        }

        await _equipoRepository.Agregar(equipo);

        TempData["Success"] = "Equipo registrado correctamente.";

        return RedirectToAction(nameof(Index));
    }

    // EDITAR
    public async Task<IActionResult> Editar(int id)
    {
        var equipo = await _equipoRepository.ObtenerPorId(id);

        if (equipo == null)
            return NotFound();

        await CargarCombos();

        return View(equipo);
    }

    [HttpPost]
    public async Task<IActionResult> Editar(Equipo equipo)
    {
        if (!ModelState.IsValid)
        {
            await CargarCombos();
            return View(equipo);
        }

        await _equipoRepository.Actualizar(equipo);

        TempData["Success"] = "Equipo actualizado correctamente.";

        return RedirectToAction(nameof(Index));
    }

    // ELIMINAR
    public async Task<IActionResult> Eliminar(int id)
    {
        await _equipoRepository.Eliminar(id);

        TempData["Success"] = "Equipo eliminado correctamente.";

        return RedirectToAction(nameof(Index));
    }

    private async Task CargarCombos()
    {
        ViewBag.Clientes = new SelectList(
            await _context.Clientes.ToListAsync(),
            "Id",
            "Nombres");

        ViewBag.Marcas = new SelectList(
            await _context.Marcas.ToListAsync(),
            "Id",
            "Nombre");

        ViewBag.TiposEquipo = new SelectList(
            await _context.TiposEquipo.ToListAsync(),
            "Id",
            "Nombre");
    }
}