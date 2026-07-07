using DarlingCellSolutions.Domain.Entidades.Base;

namespace DarlingCellSolutions.Domain.Entidades.Seguridad;

public class Permiso : EntidadBase
{
    public int Id { get; set; }

    public string Nombre { get; set; } = string.Empty;

    public string? Descripcion { get; set; }
}