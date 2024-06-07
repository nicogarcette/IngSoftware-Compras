using Compras.Aplication.Interfaces.IRepositories;
using Compras.Domain.Entidades;
using Compras.Infraestructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Compras.Infraestructure.Repositories
{
    public class ProveedorRepository : IProveedorRepository
    {
        public readonly ApplicationDbContext _context;

        public ProveedorRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task Add(Proveedor entity)
        {
            _context.Add(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(Proveedor entity)
        {
            _context.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Proveedor>> GetAllAsync()
        {
            return await _context.Proveedores.ToListAsync();
        }

        public async Task<Proveedor> GetByIdAsync(int id)
        {
            return await _context.Proveedores.FindAsync(id);
        }

        public async Task Update(Proveedor entity)
        {
            _context.Update(entity);
            await _context.SaveChangesAsync();
        }
    }
}
