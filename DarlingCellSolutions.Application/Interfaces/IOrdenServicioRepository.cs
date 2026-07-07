using DarlingCellSolutions.Domain.Entidades.ServicioTecnico;

namespace DarlingCellSolutions.Application.Interfaces;

public interface IOrdenServicioRepository
{
    Task<IEnumerable<OrdenServicio>> ObtenerTodos();

    Task<OrdenServicio?> ObtenerPorId(int id);

    Task Agregar(OrdenServicio orden);

    Task Actualizar(OrdenServicio orden);

    Task Eliminar(int id);
}