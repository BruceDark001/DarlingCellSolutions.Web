using DarlingCellSolutions.Application.Interfaces;
using DarlingCellSolutions.Infrastructure.Persistencia.Contexto;
using DarlingCellSolutions.Infrastructure.Persistencia.Repositorios;
using DarlingCellSolutions.Infrastructure.Persistencia.Repositorios.Clientes;
using DarlingCellSolutions.Infrastructure.Persistencia.Repositorios.Seguridad;

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
        services.AddScoped<IClienteRepository, ClienteRepository>();
        services.AddScoped<IProductoRepository, ProductoRepository>();
        services.AddScoped<IOrdenServicioRepository, OrdenServicioRepository>();

        return services;
    }
}

