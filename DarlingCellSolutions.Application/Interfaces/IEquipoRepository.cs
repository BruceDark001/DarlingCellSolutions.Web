using DarlingCellSolutions.Domain.Entidades.Clientes;

namespace DarlingCellSolutions.Application.Interfaces;

public interface IEquipoRepository
{
    Task<IEnumerable<Equipo>> ObtenerTodos();

    Task<Equipo?> ObtenerPorId(int id);

    Task Agregar(Equipo equipo);

    Task Actualizar(Equipo equipo);

    Task Eliminar(int id);
}