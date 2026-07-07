using DarlingCellSolutions.Application.Interfaces;
using DarlingCellSolutions.Domain.Entidades.Clientes;
using DarlingCellSolutions.Infrastructure.Persistencia.Contexto;
using Microsoft.EntityFrameworkCore;

namespace DarlingCellSolutions.Infrastructure.Persistencia.Repositorios.Clientes;

public class ClienteRepository : IClienteRepository
{
    private readonly DarlingCellSolutionsDbContext _context;

    public ClienteRepository(DarlingCellSolutionsDbContext context)
    {
        _context = context;
    }

    public async Task<List<Cliente>> ObtenerTodos()
    {
        return await _context.Clientes
            .OrderBy(x => x.Apellidos)
            .ToListAsync();
    }

    public async Task<Cliente?> ObtenerPorId(int id)
    {
        return await _context.Clientes.FindAsync(id);
    }

    public async Task Agregar(Cliente cliente)
    {
        _context.Clientes.Add(cliente);
        await _context.SaveChangesAsync();
    }

    public async Task Actualizar(Cliente cliente)
    {
        _context.Clientes.Update(cliente);
        await _context.SaveChangesAsync();
    }

    public async Task Eliminar(int id)
    {
        var cliente = await _context.Clientes.FindAsync(id);

        if (cliente != null)
        {
            _context.Clientes.Remove(cliente);
            await _context.SaveChangesAsync();
        }
    }
}