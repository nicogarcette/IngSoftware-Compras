using Compras.Aplication.Dtos;
using Compras.Aplication.Dtos.Request;
using Compras.Aplication.Interfaces.IRepositories;
using Compras.Aplication.Interfaces.IServices;
using Compras.Domain.Entidades;

namespace Compras.Aplication.Services
{
    public class ProductoService : IProductoService
    {

        private readonly IProductoRepository _productoRepository;

        public ProductoService(IProductoRepository productoRepository)
        {
            _productoRepository = productoRepository;
        }

        public async Task<int> AddProducto(ProductoRequest producto)
        {

            // hacer posible validaciones si fuera el caso.
            Producto entidad = new Producto()
            {
                //setears
            };

            await _productoRepository.Add(entidad);

            return entidad.Id;
        }


        public async Task DeleteProducto(int id)
        {
            try
            {
                var entidad = await _productoRepository.GetByIdAsync(id);

                if(entidad == null)
                    throw new Exception("El Producto no existe.");

                await _productoRepository.Delete(entidad);
            }
            catch(Exception)
            {
                throw;
            }
        }

        public async Task<List<ProductoDto>> GetAllProducto()
        {
            var proveedores = await _productoRepository.GetAllAsync();

            List<ProductoDto> ListResponse = proveedores.Select(proveedor => new ProductoDto()
            {
                // SETEAR
            }).ToList();

            return ListResponse;
        }

        public async Task<ProductoDto> GetProductoById(int id)
        {

            try
            {
                var entidad = await _productoRepository.GetByIdAsync(id);

                if(entidad is null)
                    throw new Exception("El producto no existe.");

                ProductoDto response = new ProductoDto()
                {
                    // setear los datos
                };

                return response;
            }
            catch(Exception)
            {
                throw;
            }
        }

        public async Task UpdateProducto(int id, ProductoRequest request)
        {
            try
            {
                var entidad = await _productoRepository.GetByIdAsync(id);

                if(entidad == null)
                    throw new Exception("El producto no existe.");


                // actualiazar los campos


                await _productoRepository.Update(entidad);
            }
            catch(Exception)
            {
                throw;
            }
        }
    }
}
