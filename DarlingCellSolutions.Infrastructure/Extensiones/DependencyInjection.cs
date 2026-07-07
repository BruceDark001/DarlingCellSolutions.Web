using DarlingCellSolutions.Application.Interfaces;
using DarlingCellSolutions.Infrastructure.Persistencia.Repositorios.Seguridad;
using DarlingCellSolutions.Infrastructure.Persistencia.Contexto;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DarlingCellSolutions.Infrastructure.Extensiones;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddDbContext<DarlingCellSolutionsDbContext>(options =>
        {
            options.UseSqlServer(
                configuration.GetConnectionString("DefaultConnection"));
        });

        services.AddScoped<IUsuarioRepository, UsuarioRepository>();

        return services;
    }
}