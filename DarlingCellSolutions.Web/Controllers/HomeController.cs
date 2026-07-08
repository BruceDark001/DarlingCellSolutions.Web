using DarlingCellSolutions.Infrastructure.Persistencia.Contexto;
using DarlingCellSolutions.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace DarlingCellSolutions.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly DarlingCellSolutionsDbContext _context;

        public HomeController(
            ILogger<HomeController> logger,
            DarlingCellSolutionsDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var productos = await _context.Productos
                .Where(p => p.Estado)
                .OrderByDescending(p => p.Id)
                .Take(8)
                .ToListAsync();

            return View(productos);
        }

        public IActionResult Servicios()
        {
            return View();
        }

        public IActionResult Nosotros()
        {
            return View();
        }

        public IActionResult Contacto()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel
            {
                RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
            });
        }
    }
}