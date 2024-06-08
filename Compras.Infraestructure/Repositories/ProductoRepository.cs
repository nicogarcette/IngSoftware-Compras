using Compras.Aplication.Interfaces.IRepositories;
using Compras.Domain.Entidades;
using Compras.Infraestructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Compras.Infraestructure.Repositories
{
    public class ProductoRepository : IProductoRepository
    {
        public readonly ApplicationDbContext _context;

        public ProductoRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task Add(Producto entity)
        {
            _context.Add(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(Producto entity)
        {
            _context.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Producto>> GetAllAsync()
        {
            return await _context.Productos.ToListAsync();
        }

        public async Task<Producto> GetByIdAsync(int id)
        {
            return await _context.Productos.FindAsync(id);
        }

        public async Task Update(Producto entity)
        {
            _context.Update(entity);
            await _context.SaveChangesAsync();
        }
    }
}
