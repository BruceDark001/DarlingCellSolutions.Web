using System.ComponentModel.DataAnnotations.Schema;
using DarlingCellSolutions.Domain.Entidades.Base;
using DarlingCellSolutions.Domain.Entidades.Clientes;
using DarlingCellSolutions.Domain.Entidades.Seguridad;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace DarlingCellSolutions.Domain.Entidades.ServicioTecnico;

public class OrdenServicio : EntidadBase
{
    public int Id { get; set; }

    public string NumeroOrden { get; set; } = string.Empty;

    public int ClienteId { get; set; }

    public int EquipoId { get; set; }

    public int TecnicoId { get; set; }

    public int EstadoReparacionId { get; set; }

    public string FallaReportada { get; set; } = string.Empty;

    public string? Diagnostico { get; set; }

    public string? SolucionAplicada { get; set; }

    public decimal CostoManoObra { get; set; }

    public decimal CostoRepuestos { get; set; }

    public decimal TotalCobrado { get; set; }

    public DateTime FechaIngreso { get; set; }

    public DateTime? FechaEntregaEstimada { get; set; }
    public DateTime? FechaEntregaReal { get; set; }

    public string? Observaciones { get; set; }

    // Relaciones

    [ValidateNever]
    [NotMapped]
    public Cliente? Cliente { get; set; }

    [ValidateNever]
    [NotMapped]
    public Equipo? Equipo { get; set; }

    [ValidateNever]
    [NotMapped]
    public Usuario? Tecnico { get; set; }

    [ValidateNever]
    [NotMapped]
    public EstadoReparacion? EstadoReparacion { get; set; }
}