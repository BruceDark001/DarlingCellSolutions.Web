using Microsoft.AspNetCore.Mvc;

namespace DarlingCellSolutions.Web.Controllers;

public class DashboardController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}