using DarlingCellSolutions.Application.Interfaces;
using DarlingCellSolutions.Domain.Entidades.Clientes;
using DarlingCellSolutions.Infrastructure.Persistencia.Contexto;
using Microsoft.EntityFrameworkCore;

namespace DarlingCellSolutions.Infrastructure.Persistencia.Repositorios;

public class EquipoRepository : IEquipoRepository
{
    private readonly DarlingCellSolutionsDbContext _context;

    public EquipoRepository(DarlingCellSolutionsDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Equipo>> ObtenerTodos()
    {
        return await _context.Equipos
            .Include(e => e.Cliente)
            .Include(e => e.Marca)
            .Include(e => e.TipoEquipo)
            .ToListAsync();
    }

    public async Task<Equipo?> ObtenerPorId(int id)
    {
        return await _context.Equipos
            .Include(e => e.Cliente)
            .Include(e => e.Marca)
            .Include(e => e.TipoEquipo)
            .FirstOrDefaultAsync(e => e.Id == id);
    }

    public async Task Agregar(Equipo equipo)
    {
        _context.Equipos.Add(equipo);
        await _context.SaveChangesAsync();
    }

    public async Task Actualizar(Equipo equipo)
    {
        _context.Equipos.Update(equipo);
        await _context.SaveChangesAsync();
    }

    public async Task Eliminar(int id)
    {
        var equipo = await _context.Equipos.FindAsync(id);

        if (equipo != null)
        {
            _context.Equipos.Remove(equipo);
            await _context.SaveChangesAsync();
        }
    }
}