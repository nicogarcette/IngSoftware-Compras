using Compras.Aplication.Dtos;
using Compras.Aplication.Dtos.Request;

namespace Compras.Aplication.Interfaces.IServices
{
    public interface IProveedorService
    {
        Task<List<ProveedorDto>> GetAllProveedores();
        Task<ProveedorDto> GetProveedorById(int id);
        Task<int> AddProveedor(ProveedorRequest proveedor);
        Task DeleteProveedor(int id);
        Task UpdateProveedor(int id, ProveedorRequest proveedor);
    }
}
