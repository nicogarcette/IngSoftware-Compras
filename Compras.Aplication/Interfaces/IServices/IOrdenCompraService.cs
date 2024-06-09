using Compras.Aplication.Dtos;
using Compras.Aplication.Dtos.Request;

namespace Compras.Aplication.Interfaces.IServices
{
    public interface IOrdenCompraService
    {
        Task<List<OrdenDeCompraDto>> GetAllOrdenCompras();
        Task<OrdenDeCompraDto> GetOrdenCompraById(int id);
        Task<int> AddOrdenCompra(OrdenCompraRequest ordenCompra);
        Task DeleteOrdenCompra(int id);
        Task UpdateOrdenCompra(int id, OrdenCompraUpdate ordenCompra);
    }
}
