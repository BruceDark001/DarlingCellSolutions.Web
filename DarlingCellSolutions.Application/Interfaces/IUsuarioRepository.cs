using DarlingCellSolutions.Domain.Entidades.Seguridad;

namespace DarlingCellSolutions.Application.Interfaces;

public interface IUsuarioRepository
{
    Task<IEnumerable<Usuario>> ObtenerTodos();

    Task<Usuario?> ObtenerPorId(int id);

    Task Agregar(Usuario usuario);

    Task Actualizar(Usuario usuario);

    Task Eliminar(int id);

    Task<Usuario?> Login(string usuario, string password);
}