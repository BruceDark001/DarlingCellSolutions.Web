using DarlingCellSolutions.Application.Interfaces;
using DarlingCellSolutions.Domain.Entidades.Inventario;
using DarlingCellSolutions.Domain.Entidades.Ventas;
using DarlingCellSolutions.Domain.Enumeraciones;
using DarlingCellSolutions.Infrastructure.Persistencia.Contexto;
using Microsoft.EntityFrameworkCore;

namespace DarlingCellSolutions.Infrastructure.Persistencia.Repositorios;

public class VentaRepository : IVentaRepository
{
    private readonly DarlingCellSolutionsDbContext _context;

    public VentaRepository(DarlingCellSolutionsDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Venta>> ObtenerTodas()
    {
        return await _context.Ventas.ToListAsync();
    }

    public async Task<Venta?> ObtenerPorId(int id)
    {
        return await _context.Ventas.FindAsync(id);
    }

    public async Task Agregar(Venta venta)
    {
        _context.Ventas.Add(venta);
        await _context.SaveChangesAsync();
    }

    public async Task Actualizar(Venta venta)
    {
        _context.Ventas.Update(venta);
        await _context.SaveChangesAsync();
    }

    public async Task Eliminar(int id)
    {
        var venta = await _context.Ventas.FindAsync(id);

        if (venta != null)
        {
            _context.Ventas.Remove(venta);
            await _context.SaveChangesAsync();
        }
    }

    public async Task GuardarVentaCompleta(
        Venta venta,
        List<DetalleVenta> detalles)
    {
        using var transaction = await _context.Database.BeginTransactionAsync();

        _context.Ventas.Add(venta);
        await _context.SaveChangesAsync();

        foreach (var item in detalles)
        {
            item.VentaId = venta.Id;

            _context.DetallesVenta.Add(item);

            var producto = await _context.Productos.FindAsync(item.ProductoId);

            if (producto != null)
            {
                producto.Stock -= item.Cantidad;

                _context.Productos.Update(producto);

                _context.MovimientosInventario.Add(new MovimientoInventario
                {
                    ProductoId = producto.Id,
                    Cantidad = item.Cantidad,
                    TipoMovimiento = TipoMovimientoInventario.Salida,
                    Motivo = $"Venta N° {venta.Id}"
                });
            }
        }

        await _context.SaveChangesAsync();
        await transaction.CommitAsync();
    }
}