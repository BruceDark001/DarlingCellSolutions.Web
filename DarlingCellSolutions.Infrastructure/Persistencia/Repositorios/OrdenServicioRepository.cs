using DarlingCellSolutions.Application.Interfaces;
using DarlingCellSolutions.Domain.Entidades.ServicioTecnico;
using DarlingCellSolutions.Infrastructure.Persistencia.Contexto;
using Microsoft.EntityFrameworkCore;

namespace DarlingCellSolutions.Infrastructure.Persistencia.Repositorios;

public class OrdenServicioRepository : IOrdenServicioRepository
{
    private readonly DarlingCellSolutionsDbContext _context;

    public OrdenServicioRepository(DarlingCellSolutionsDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<OrdenServicio>> ObtenerTodos()
    {
        return await _context.OrdenesServicio
            .Include(o => o.Cliente)
            .Include(o => o.Equipo)
            .Include(o => o.Tecnico)
            .Include(o => o.EstadoReparacion)
            .ToListAsync();
    }

    public async Task<OrdenServicio?> ObtenerPorId(int id)
    {
        return await _context.OrdenesServicio
            .Include(o => o.Cliente)
            .Include(o => o.Equipo)
            .Include(o => o.Tecnico)
            .Include(o => o.EstadoReparacion)
            .FirstOrDefaultAsync(o => o.Id == id);
    }

    public async Task Agregar(OrdenServicio orden)
    {
        _context.OrdenesServicio.Add(orden);
        await _context.SaveChangesAsync();
    }

    public async Task Actualizar(OrdenServicio orden)
    {
        _context.OrdenesServicio.Update(orden);
        await _context.SaveChangesAsync();
    }

    public async Task Eliminar(int id)
    {
        var orden = await _context.OrdenesServicio.FindAsync(id);

        if (orden != null)
        {
            _context.OrdenesServicio.Remove(orden);
            await _context.SaveChangesAsync();
        }
    }
}