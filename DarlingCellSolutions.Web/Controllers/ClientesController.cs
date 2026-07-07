using DarlingCellSolutions.Application.Interfaces;
using DarlingCellSolutions.Domain.Entidades.Clientes;
using Microsoft.AspNetCore.Mvc;

namespace DarlingCellSolutions.Web.Controllers;

public class ClientesController : Controller
{
    private readonly IClienteRepository _clienteRepository;

    public ClientesController(IClienteRepository clienteRepository)
    {
        _clienteRepository = clienteRepository;
    }

    // LISTAR
    public async Task<IActionResult> Index()
    {
        var clientes = await _clienteRepository.ObtenerTodos();
        return View(clientes);
    }

    // DETALLES
    public async Task<IActionResult> Detalles(int id)
    {
        var cliente = await _clienteRepository.ObtenerPorId(id);

        if (cliente == null)
            return NotFound();

        return View(cliente);
    }

    // CREAR
    public IActionResult Crear()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Crear(Cliente cliente)
    {
        if (!ModelState.IsValid)
            return View(cliente);

        await _clienteRepository.Agregar(cliente);

        TempData["Success"] = "Cliente registrado correctamente.";

        return RedirectToAction(nameof(Index));
    }

    // EDITAR
    public async Task<IActionResult> Editar(int id)
    {
        var cliente = await _clienteRepository.ObtenerPorId(id);

        if (cliente == null)
            return NotFound();

        return View(cliente);
    }

    [HttpPost]
    public async Task<IActionResult> Editar(Cliente cliente)
    {
        if (!ModelState.IsValid)
            return View(cliente);

        await _clienteRepository.Actualizar(cliente);

        TempData["Success"] = "Cliente actualizado correctamente.";

        return RedirectToAction(nameof(Index));
    }

    // ELIMINAR
    public async Task<IActionResult> Eliminar(int id)
    {
        await _clienteRepository.Eliminar(id);

        TempData["Success"] = "Cliente eliminado correctamente.";

        return RedirectToAction(nameof(Index));
    }
}