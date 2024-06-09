using Compras.Aplication.Dtos;
using Compras.Aplication.Dtos.Request;

namespace Compras.Aplication.Interfaces.IServices
{
    public interface IProductoService
    {
        Task<List<ProductoDto>> GetAllProducto();
        Task<ProductoDto> GetProductoById(int id);
        Task<int> AddProducto(ProductoRequest producto);
        Task DeleteProducto(int id);
        Task UpdateProducto(int id, ProductoRequest producto);
    }
}
