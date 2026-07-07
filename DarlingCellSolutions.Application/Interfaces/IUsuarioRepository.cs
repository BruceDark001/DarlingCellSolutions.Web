using DarlingCellSolutions.Domain.Entidades.Seguridad;

namespace DarlingCellSolutions.Application.Interfaces;

public interface IUsuarioRepository
{
    Task<Usuario?> Login(string usuario, string password);
}