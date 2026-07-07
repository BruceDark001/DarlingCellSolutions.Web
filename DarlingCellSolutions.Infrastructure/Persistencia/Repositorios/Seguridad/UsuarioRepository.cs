using DarlingCellSolutions.Application.Interfaces;
using DarlingCellSolutions.Domain.Entidades.Seguridad;
using DarlingCellSolutions.Infrastructure.Persistencia.Contexto;
using Microsoft.EntityFrameworkCore;

namespace DarlingCellSolutions.Infrastructure.Persistencia.Repositorios.Seguridad;

public class UsuarioRepository : IUsuarioRepository
{
    private readonly DarlingCellSolutionsDbContext _context;

    public UsuarioRepository(DarlingCellSolutionsDbContext context)
    {
        _context = context;
    }

    public async Task<Usuario?> Login(string usuario, string password)
    {
        return await _context.Usuarios
            .Include(x => x.Rol)
            .FirstOrDefaultAsync(x =>
                x.NombreUsuario == usuario &&
                x.PasswordHash == password &&
                x.Estado);
    }
}