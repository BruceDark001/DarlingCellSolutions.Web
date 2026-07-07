namespace DarlingCellSolutions.Domain.Entidades.Base;

public abstract class EntidadBase
{
    public DateTime FechaCreacion { get; set; } = DateTime.Now;

    public DateTime? FechaModificacion { get; set; }

    public string? UsuarioCreacion { get; set; }

    public string? UsuarioModificacion { get; set; }

    public bool Estado { get; set; } = true;
}