using DarlingCellSolutions.Domain.Entidades.Base;

namespace DarlingCellSolutions.Domain.Entidades.Sistema;

public class Notificacion : EntidadBase
{
    public int Id { get; set; }

    public int UsuarioId { get; set; }

    public string Titulo { get; set; } = string.Empty;

    public string Mensaje { get; set; } = string.Empty;

    public bool Leida { get; set; }
}