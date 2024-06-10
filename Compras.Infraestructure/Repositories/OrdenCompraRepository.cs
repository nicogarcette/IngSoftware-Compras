using Compras.Aplication.Interfaces.IRepositories;
using Compras.Domain.Entidades;
using Compras.Infraestructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Compras.Infraestructure.Repositories
{
    public class OrdenCompraRepository : IOrdenCompraRepository
    {
        public readonly ApplicationDbContext _context;

        public OrdenCompraRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task Add(OrdenDeCompra entity)
        {
            _context.Add(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(OrdenDeCompra entity)
        {
            _context.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<OrdenDeCompra>> GetAllAsync()
        {
            return await _context.OrdenesCompras
                .Include(x => x.Proveedor)
                .Include(x => x.OrdenProductos).ThenInclude(op => op.Producto)
                .ToListAsync();
        }

        public async Task<OrdenDeCompra> GetByIdAsync(int id)
        {
            return await _context.OrdenesCompras
                .Include(x => x.Proveedor)
                .Include(x => x.OrdenProductos).ThenInclude(op => op.Producto)
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task Update(OrdenDeCompra entity)
        {
            _context.Update(entity);
            await _context.SaveChangesAsync();
        }
    }
}
