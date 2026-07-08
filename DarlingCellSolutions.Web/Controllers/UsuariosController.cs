using DarlingCellSolutions.Application.Interfaces;
using DarlingCellSolutions.Domain.Entidades.Seguridad;
using DarlingCellSolutions.Infrastructure.Persistencia.Contexto;
using DarlingCellSolutions.Web.Filters;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace DarlingCellSolutions.Web.Controllers;

[SessionAuthorize]
public class UsuariosController : Controller
{
    private readonly IUsuarioRepository _repository;
    private readonly DarlingCellSolutionsDbContext _context;

    public UsuariosController(
        IUsuarioRepository repository,
        DarlingCellSolutionsDbContext context)
    {
        _repository = repository;
        _context = context;
    }

    public async Task<IActionResult> Index()
    {
        return View(await _repository.ObtenerTodos());
    }

    public async Task<IActionResult> Crear()
    {
        ViewBag.Roles = await _context.Roles
            .Select(x => new SelectListItem
            {
                Value = x.Id.ToString(),
                Text = x.Nombre
            }).ToListAsync();

        return View(new Usuario());
    }

    [HttpPost]
    public async Task<IActionResult> Crear(Usuario usuario)
    {
        if (!ModelState.IsValid)
        {
            ViewBag.Roles = await _context.Roles
                .Select(x => new SelectListItem
                {
                    Value = x.Id.ToString(),
                    Text = x.Nombre
                }).ToListAsync();

            return View(usuario);
        }

        await _repository.Agregar(usuario);

        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Editar(int id)
    {
        var usuario = await _repository.ObtenerPorId(id);

        if (usuario == null)
            return NotFound();

        ViewBag.Roles = await _context.Roles
            .Select(x => new SelectListItem
            {
                Value = x.Id.ToString(),
                Text = x.Nombre
            }).ToListAsync();

        return View(usuario);
    }

    [HttpPost]
    public async Task<IActionResult> Editar(Usuario usuario)
    {
        if (!ModelState.IsValid)
        {
            ViewBag.Roles = await _context.Roles
                .Select(x => new SelectListItem
                {
                    Value = x.Id.ToString(),
                    Text = x.Nombre
                }).ToListAsync();

            return View(usuario);
        }

        await _repository.Actualizar(usuario);

        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Eliminar(int id)
    {
        await _repository.Eliminar(id);

        return RedirectToAction(nameof(Index));
    }
}