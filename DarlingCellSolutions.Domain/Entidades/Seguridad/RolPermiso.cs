using DarlingCellSolutions.Domain.Entidades.Base;

namespace DarlingCellSolutions.Domain.Entidades.Seguridad;

public class RolPermiso : EntidadBase
{
    public int Id { get; set; }

    public int RolId { get; set; }

    public int PermisoId { get; set; }

    // Relaciones
    public Rol Rol { get; set; } = null!;

    public Permiso Permiso { get; set; } = null!;
}