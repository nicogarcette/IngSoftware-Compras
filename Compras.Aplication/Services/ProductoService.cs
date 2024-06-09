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
        private readonly IProveedorRepository _proveedorRepository;


        public ProductoService(IProductoRepository productoRepository, IProveedorRepository proveedorRepository)
        {
            _productoRepository = productoRepository;
            _proveedorRepository = proveedorRepository;
        }

        public async Task<int> AddProducto(ProductoRequest producto)
        {
            var proveedor = await _proveedorRepository.GetByIdAsync(producto.IdProveedor);

            if(proveedor == null) throw new Exception("El proveedor no existe");

            // hacer posible validaciones si fuera el caso.
            Producto entidad = new Producto()
            {
                PrecioVenta = producto.PrecioVenta,
                Descripcion = producto.Descripcion,
                StockActual = producto.StockActual,
                StockMinimo = producto.StockMinimo,
                NumeroLote = producto.NumeroLote,
                FechaVencimiento = producto.FechaVencimiento,
                IdProveedor = producto.IdProveedor,

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

            List<ProductoDto> ListResponse = proveedores.Select(entidad => new ProductoDto()
            {
                Id = entidad.Id,
                PrecioVenta = entidad.PrecioVenta,
                Descripcion = entidad.Descripcion,
                StockActual = entidad.StockActual,
                StockMinimo = entidad.StockMinimo,
                NumeroLote = entidad.NumeroLote,
                FechaVencimiento = entidad.FechaVencimiento,
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
                    Id = entidad.Id,
                    PrecioVenta = entidad.PrecioVenta,
                    Descripcion = entidad.Descripcion,
                    StockActual = entidad.StockActual,
                    StockMinimo = entidad.StockMinimo,
                    NumeroLote = entidad.NumeroLote,
                    FechaVencimiento = entidad.FechaVencimiento,
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

                var proveedor = await _proveedorRepository.GetByIdAsync(request.IdProveedor);

                if(proveedor == null) throw new Exception("El proveedor no existe");

                entidad.PrecioVenta = request.PrecioVenta;
                entidad.Descripcion = request.Descripcion;
                entidad.StockActual = request.StockActual;
                entidad.StockMinimo = request.StockMinimo;
                entidad.NumeroLote = request.NumeroLote;
                entidad.FechaVencimiento = request.FechaVencimiento;
                entidad.IdProveedor = request.IdProveedor;

                await _productoRepository.Update(entidad);
            }
            catch(Exception)
            {
                throw;
            }
        }
    }
}
