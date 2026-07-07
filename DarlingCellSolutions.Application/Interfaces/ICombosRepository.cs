using DarlingCellSolutions.Domain.Entidades.Clientes;
using DarlingCellSolutions.Domain.Entidades.Seguridad;
using DarlingCellSolutions.Domain.Entidades.ServicioTecnico;

namespace DarlingCellSolutions.Application.Interfaces;

public interface ICombosRepository
{
    Task<IEnumerable<Cliente>> ObtenerClientes();

    Task<IEnumerable<Equipo>> ObtenerEquipos();

    Task<IEnumerable<Usuario>> ObtenerUsuarios();

    Task<IEnumerable<EstadoReparacion>> ObtenerEstados();
}