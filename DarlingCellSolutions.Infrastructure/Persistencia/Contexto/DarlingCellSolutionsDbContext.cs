using DarlingCellSolutions.Domain.Entidades.Clientes;
using DarlingCellSolutions.Domain.Entidades.Configuracion;
using DarlingCellSolutions.Domain.Entidades.Inventario;
using DarlingCellSolutions.Domain.Entidades.Seguridad;
using DarlingCellSolutions.Domain.Entidades.ServicioTecnico;
using DarlingCellSolutions.Domain.Entidades.Sistema;
using DarlingCellSolutions.Domain.Entidades.Ventas;
using Microsoft.EntityFrameworkCore;

namespace DarlingCellSolutions.Infrastructure.Persistencia.Contexto;

public class DarlingCellSolutionsDbContext : DbContext
{
    public DarlingCellSolutionsDbContext(DbContextOptions<DarlingCellSolutionsDbContext> options)
        : base(options)
    {
    }

    #region Seguridad

    public DbSet<Usuario> Usuarios => Set<Usuario>();

    public DbSet<Rol> Roles => Set<Rol>();

    public DbSet<Permiso> Permisos => Set<Permiso>();

    public DbSet<RolPermiso> RolesPermisos => Set<RolPermiso>();

    #endregion

    #region Clientes

    public DbSet<Cliente> Clientes => Set<Cliente>();

    public DbSet<Equipo> Equipos => Set<Equipo>();

    public DbSet<Marca> Marcas => Set<Marca>();

    public DbSet<TipoEquipo> TiposEquipo => Set<TipoEquipo>();

    #endregion

    #region Inventario

    public DbSet<Producto> Productos => Set<Producto>();

    public DbSet<Categoria> Categorias => Set<Categoria>();

    public DbSet<MovimientoInventario> MovimientosInventario => Set<MovimientoInventario>();

    #endregion

    #region Servicio Técnico

    public DbSet<OrdenServicio> OrdenesServicio => Set<OrdenServicio>();

    public DbSet<Cotizacion> Cotizaciones => Set<Cotizacion>();

    public DbSet<Garantia> Garantias => Set<Garantia>();

    public DbSet<Evidencia> Evidencias => Set<Evidencia>();

    public DbSet<HistorialEstado> HistorialEstados => Set<HistorialEstado>();

    public DbSet<EstadoReparacion> EstadosReparacion => Set<EstadoReparacion>();

    public DbSet<RepuestoUtilizado> RepuestosUtilizados => Set<RepuestoUtilizado>();

    #endregion

    #region Ventas

    public DbSet<Venta> Ventas => Set<Venta>();

    public DbSet<DetalleVenta> DetallesVenta => Set<DetalleVenta>();

    public DbSet<Pago> Pagos => Set<Pago>();

    #endregion

    #region Sistema

    public DbSet<ConfiguracionEmpresa> ConfiguracionEmpresa => Set<ConfiguracionEmpresa>();

    public DbSet<Auditoria> Auditorias => Set<Auditoria>();

    public DbSet<Notificacion> Notificaciones => Set<Notificacion>();

    #endregion

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfigurationsFromAssembly(typeof(DarlingCellSolutionsDbContext).Assembly);
    }

}