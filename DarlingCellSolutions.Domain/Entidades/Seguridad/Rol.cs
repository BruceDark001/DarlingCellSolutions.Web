using DarlingCellSolutions.Domain.Entidades.Base;

namespace DarlingCellSolutions.Domain.Entidades.Seguridad;

public class Rol : EntidadBase
{
    public int Id { get; set; }

    public string Nombre { get; set; } = string.Empty;

    public string? Descripcion { get; set; }

    // Propiedades de navegación
    public ICollection<Usuario> Usuarios { get; set; } = new List<Usuario>();

    public ICollection<RolPermiso> RolesPermisos { get; set; } = new List<RolPermiso>();
}