using DarlingCellSolutions.Application.Interfaces;
using DarlingCellSolutions.Domain.Entidades.Clientes;
using DarlingCellSolutions.Domain.Entidades.Seguridad;
using DarlingCellSolutions.Domain.Entidades.ServicioTecnico;
using DarlingCellSolutions.Infrastructure.Persistencia.Contexto;
using Microsoft.EntityFrameworkCore;

namespace DarlingCellSolutions.Infrastructure.Persistencia.Repositorios;

public class CombosRepository : ICombosRepository
{
    private readonly DarlingCellSolutionsDbContext _context;

    public CombosRepository(DarlingCellSolutionsDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Cliente>> ObtenerClientes()
    {
        return await _context.Clientes
            .OrderBy(c => c.Nombres)
            .ToListAsync();
    }

    public async Task<IEnumerable<Equipo>> ObtenerEquipos()
    {
        return await _context.Equipos
            .Include(e => e.Cliente)
            .Include(e => e.Marca)
            .OrderBy(e => e.Modelo)
            .ToListAsync();
    }

    public async Task<IEnumerable<Usuario>> ObtenerUsuarios()
    {
        return await _context.Usuarios
            .OrderBy(u => u.Nombres)
            .ToListAsync();
    }

    public async Task<IEnumerable<EstadoReparacion>> ObtenerEstados()
    {
        return await _context.EstadosReparacion
            .OrderBy(e => e.Id)
            .ToListAsync();
    }
}