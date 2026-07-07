using DarlingCellSolutions.Domain.Entidades.Base;

namespace DarlingCellSolutions.Domain.Entidades.ServicioTecnico;

public class RepuestoUtilizado : EntidadBase
{
    public int Id { get; set; }

    public int OrdenServicioId { get; set; }

    public int ProductoId { get; set; }

    public int Cantidad { get; set; }

    public decimal Costo { get; set; }
}