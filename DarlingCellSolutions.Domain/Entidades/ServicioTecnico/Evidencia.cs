using DarlingCellSolutions.Domain.Entidades.Base;
using DarlingCellSolutions.Domain.Enumeraciones;

namespace DarlingCellSolutions.Domain.Entidades.ServicioTecnico;

public class Evidencia : EntidadBase
{
    public int Id { get; set; }

    public int OrdenServicioId { get; set; }

    public string RutaArchivo { get; set; } = string.Empty;

    public TipoArchivo TipoArchivo { get; set; }

    public string? Descripcion { get; set; }
}