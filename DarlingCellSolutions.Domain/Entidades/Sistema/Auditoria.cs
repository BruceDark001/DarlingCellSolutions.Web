using DarlingCellSolutions.Domain.Entidades.Base;

namespace DarlingCellSolutions.Domain.Entidades.Sistema;

public class Auditoria : EntidadBase
{
    public int Id { get; set; }

    public int UsuarioId { get; set; }

    public string Tabla { get; set; } = string.Empty;

    public string Operacion { get; set; } = string.Empty;

    public string Descripcion { get; set; } = string.Empty;

    public DateTime Fecha { get; set; } = DateTime.Now;
}