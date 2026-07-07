using DarlingCellSolutions.Domain.Entidades.Ventas;

namespace DarlingCellSolutions.Application.Interfaces;

public interface IVentaRepository
{
    Task<IEnumerable<Venta>> ObtenerTodas();

    Task<Venta?> ObtenerPorId(int id);

    Task Agregar(Venta venta);

    Task Actualizar(Venta venta);

    Task Eliminar(int id);

    Task GuardarVentaCompleta(
        Venta venta,
        List<DetalleVenta> detalles);
}