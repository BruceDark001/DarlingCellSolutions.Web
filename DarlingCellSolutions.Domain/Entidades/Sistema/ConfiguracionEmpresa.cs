using DarlingCellSolutions.Domain.Entidades.Base;

namespace DarlingCellSolutions.Domain.Entidades.Configuracion;

public class ConfiguracionEmpresa : EntidadBase
{
    public int Id { get; set; }

    public string RazonSocial { get; set; } = string.Empty;

    public string Ruc { get; set; } = string.Empty;

    public string Direccion { get; set; } = string.Empty;

    public string Telefono { get; set; } = string.Empty;

    public string Correo { get; set; } = string.Empty;

    public string? Logo { get; set; }
}