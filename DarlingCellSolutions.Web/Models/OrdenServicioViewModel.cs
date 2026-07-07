using DarlingCellSolutions.Domain.Entidades.ServicioTecnico;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace DarlingCellSolutions.Web.Models;

public class OrdenServicioViewModel
{
    public OrdenServicio Orden { get; set; } = new();

    public IEnumerable<SelectListItem> Clientes { get; set; }
        = new List<SelectListItem>();

    public IEnumerable<SelectListItem> Equipos { get; set; }
        = new List<SelectListItem>();

    public IEnumerable<SelectListItem> Tecnicos { get; set; }
        = new List<SelectListItem>();

    public IEnumerable<SelectListItem> Estados { get; set; }
        = new List<SelectListItem>();
}