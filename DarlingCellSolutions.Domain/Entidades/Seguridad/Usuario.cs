using DarlingCellSolutions.Domain.Entidades.Base;

namespace DarlingCellSolutions.Domain.Entidades.Seguridad;

public class Usuario : EntidadBase
{
    public int Id { get; set; }

    public string Nombres { get; set; } = string.Empty;

    public string Apellidos { get; set; } = string.Empty;

    public string Dni { get; set; } = string.Empty;

    public string Telefono { get; set; } = string.Empty;

    public string Correo { get; set; } = string.Empty;

    public string NombreUsuario { get; set; } = string.Empty;

    public string PasswordHash { get; set; } = string.Empty;

    public int RolId { get; set; }

    // Relación
    public Rol Rol { get; set; } = null!;
}