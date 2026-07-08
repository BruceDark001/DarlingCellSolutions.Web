using DarlingCellSolutions.Application.Interfaces;
using DarlingCellSolutions.Domain.Entidades.Clientes;
using DarlingCellSolutions.Domain.Entidades.Seguridad;
using DarlingCellSolutions.Domain.Entidades.ServicioTecnico;
using DarlingCellSolutions.Infrastructure.Persistencia.Contexto;
using DarlingCellSolutions.Web.Filters;
using DarlingCellSolutions.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace DarlingCellSolutions.Web.Controllers;

[SessionAuthorize]
public class OrdenesServicioController : Controller
{
    private readonly IOrdenServicioRepository _repository;
    private readonly DarlingCellSolutionsDbContext _context;

    public OrdenesServicioController(
        IOrdenServicioRepository repository,
        DarlingCellSolutionsDbContext context)
    {
        _repository = repository;
        _context = context;
    }

    public async Task<IActionResult> Index()
    {
        var lista = await _repository.ObtenerTodos();
        return View(lista);
    }

    public async Task<IActionResult> Crear()
    {
        var vm = new OrdenServicioViewModel();

        vm.Orden.NumeroOrden = "OS-" + DateTime.Now.Ticks.ToString().Substring(10);

        vm.Clientes = await _context.Clientes
            .Select(x => new SelectListItem
            {
                Value = x.Id.ToString(),
                Text = x.Nombres + " " + x.Apellidos
            }).ToListAsync();

        vm.Equipos = await _context.Equipos
            .Select(x => new SelectListItem
            {
                Value = x.Id.ToString(),
                Text = x.Modelo
            }).ToListAsync();

        vm.Tecnicos = await _context.Usuarios
            .Select(x => new SelectListItem
            {
                Value = x.Id.ToString(),
                Text = x.Nombres + " " + x.Apellidos
            }).ToListAsync();

        vm.Estados = await _context.EstadosReparacion
            .Select(x => new SelectListItem
            {
                Value = x.Id.ToString(),
                Text = x.Nombre
            }).ToListAsync();

        return View(vm);
    }
    [HttpPost]
    public async Task<IActionResult> Crear(OrdenServicioViewModel model)
    {
        if (!ModelState.IsValid)
        {
            foreach (var error in ModelState)
            {
                foreach (var e in error.Value.Errors)
                {
                    Console.WriteLine($"{error.Key} -> {e.ErrorMessage}");
                }
            }

            model.Clientes = await _context.Clientes
                .Select(c => new SelectListItem
                {
                    Value = c.Id.ToString(),
                    Text = c.Nombres + " " + c.Apellidos
                }).ToListAsync();

            model.Equipos = await _context.Equipos
                .Select(e => new SelectListItem
                {
                    Value = e.Id.ToString(),
                    Text = e.Modelo
                }).ToListAsync();

            model.Tecnicos = await _context.Usuarios
                .Select(u => new SelectListItem
                {
                    Value = u.Id.ToString(),
                    Text = u.Nombres + " " + u.Apellidos
                }).ToListAsync();

            model.Estados = await _context.EstadosReparacion
                .Select(e => new SelectListItem
                {
                    Value = e.Id.ToString(),
                    Text = e.Nombre
                }).ToListAsync();

            return View(model);
        }

        model.Orden.FechaIngreso = DateTime.Now;

        await _repository.Agregar(model.Orden);

        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Editar(int id)
    {
        var orden = await _repository.ObtenerPorId(id);

        if (orden == null)
            return NotFound();

        return View(orden);
    }

    [HttpPost]
    public async Task<IActionResult> Editar(OrdenServicio orden)
    {
        if (!ModelState.IsValid)
            return View(orden);

        await _repository.Actualizar(orden);

        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Eliminar(int id)
    {
        await _repository.Eliminar(id);

        return RedirectToAction(nameof(Index));
    }
}