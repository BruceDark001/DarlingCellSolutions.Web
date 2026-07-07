using DarlingCellSolutions.Domain.Entidades.Inventario;

namespace DarlingCellSolutions.Application.Interfaces;

public interface IProductoRepository
{
    Task<IEnumerable<Producto>> ObtenerTodos();
    Task<Producto?> ObtenerPorId(int id);
    Task Agregar(Producto producto);
    Task Actualizar(Producto producto);
    Task Eliminar(int id);
}