using DarlingCellSolutions.Application.Interfaces;
using DarlingCellSolutions.Domain.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace DarlingCellSolutions.Web.Controllers;

public class LoginController : Controller
{
    private readonly IUsuarioRepository _usuarioRepository;

    public LoginController(IUsuarioRepository usuarioRepository)
    {
        _usuarioRepository = usuarioRepository;
    }

    [HttpGet]
    public IActionResult Index()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Index(LoginDTO model)
    {
        if (!ModelState.IsValid)
            return View(model);

        var usuario = await _usuarioRepository.Login(model.Usuario, model.Password);

        if (usuario == null)
        {
            ViewBag.Error = "Usuario o contraseña incorrectos.";
            return View(model);
        }

        HttpContext.Session.SetInt32("UsuarioId", usuario.Id);
        HttpContext.Session.SetString("Nombre", usuario.Nombres);
        HttpContext.Session.SetString("Rol", usuario.Rol.Nombre);

        return RedirectToAction("Index", "Home");
    }

    public IActionResult Logout()
    {
        HttpContext.Session.Clear();
        return RedirectToAction(nameof(Index));
    }
}