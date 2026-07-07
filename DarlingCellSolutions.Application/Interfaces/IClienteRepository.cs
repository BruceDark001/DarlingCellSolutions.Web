using DarlingCellSolutions.Domain.Entidades.Clientes;

namespace DarlingCellSolutions.Application.Interfaces;

public interface IClienteRepository
{
    Task<List<Cliente>> ObtenerTodos();

    Task<Cliente?> ObtenerPorId(int id);

    Task Agregar(Cliente cliente);

    Task Actualizar(Cliente cliente);

    Task Eliminar(int id);
}