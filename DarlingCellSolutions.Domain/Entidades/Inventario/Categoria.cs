using DarlingCellSolutions.Domain.Entidades.Base;

namespace DarlingCellSolutions.Domain.Entidades.Inventario;

public class Categoria : EntidadBase
{
    public int Id { get; set; }

    public string Nombre { get; set; } = string.Empty;

    public string? Descripcion { get; set; }

    // Relaciones
    public ICollection<Producto> Productos { get; set; } = new List<Producto>();
}