using Compras.Aplication.Dtos;
using Compras.Aplication.Dtos.Request;
using Compras.Aplication.Interfaces.IRepositories;
using Compras.Aplication.Interfaces.IServices;
using Compras.Domain.Entidades;

namespace Compras.Aplication.Services
{
    public class OrdenCompraService : IOrdenCompraService
    {

        private readonly IOrdenCompraRepository _ordenCompraRepository;
        private readonly IProveedorRepository _proveedorRepository;
        private readonly IProductoRepository _productoRepository;


        public OrdenCompraService(IOrdenCompraRepository ordenCompraRepository,
                                    IProveedorRepository proveedorRepository,
                                    IProductoRepository productoRepository)
        {
            _ordenCompraRepository = ordenCompraRepository;
            _proveedorRepository = proveedorRepository;
            _productoRepository = productoRepository;
        }

        public async Task<int> AddOrdenCompra(OrdenCompraRequest orden)
        {

            var proveedor = await _proveedorRepository.GetByIdAsync(orden.IdProveedor);

            if(proveedor == null) throw new Exception("El proveedor no existe");

            List<OrdenProducto> ordenProductos = new List<OrdenProducto>();
            int precioTotal = 0;

            foreach(var item in orden.Productos)
            {

                if(item.Cantidad <= 0) throw new Exception($"La cantidad del producto {item.IdProducto} debe ser mayor a cero.");

                var producto = await _productoRepository.GetByIdAsync(item.IdProducto);

                if(producto == null) throw new Exception($"El producto {item.IdProducto} no existe.");

                if(producto.IdProveedor != orden.IdProveedor)
                    throw new Exception($"El producto {item.IdProducto} es de un proveedor diferente a la orden de compra.");


                var ordenProducto = new OrdenProducto
                {
                    IdProducto = producto.Id,
                    Cantidad = item.Cantidad,
                };

                ordenProductos.Add(ordenProducto);
                precioTotal += (int)producto.PrecioVenta * item.Cantidad;
            }

            OrdenDeCompra entidad = new OrdenDeCompra()
            {
                Descripcion = orden.Descripcion,
                PrecioTotal = precioTotal,
                Fecha = orden.Fecha,
                IdProveedor = orden.IdProveedor,
                OrdenProductos = ordenProductos
            };

            await _ordenCompraRepository.Add(entidad);

            return entidad.Id;
        }


        public async Task DeleteOrdenCompra(int id)
        {
            try
            {
                var entidad = await _ordenCompraRepository.GetByIdAsync(id);

                if(entidad == null)
                    throw new Exception("La orden de compra no existe.");

                await _ordenCompraRepository.Delete(entidad);
            }
            catch(Exception)
            {
                throw;
            }
        }

        public async Task<List<OrdenDeCompraDto>> GetAllOrdenCompras()
        {
            var ordenes = await _ordenCompraRepository.GetAllAsync();

            List<OrdenDeCompraDto> ListResponse = ordenes.Select(entidad => new OrdenDeCompraDto()
            {
                Id = entidad.Id,
                Descripcion = entidad.Descripcion,
                PrecioTotal = entidad.PrecioTotal,
                Fecha = entidad.Fecha,
                Proveedor = new ProveedorDto()
                {
                    Id = entidad.Proveedor.Id,
                    Nombre = entidad.Proveedor.Nombre,
                    Apellido = entidad.Proveedor.Apellido,
                    Direccion = entidad.Proveedor.Direccion,
                    Cuil = entidad.Proveedor.Cuil,
                    Telefono = entidad.Proveedor.Telefono,
                    NombreEmpresa = entidad.Proveedor.NombreEmpresa
                },
                Productos = entidad.OrdenProductos.Select(x => new ProductoDto()
                {
                    Id = x.Id,
                    PrecioVenta = x.Producto.PrecioVenta,
                    Descripcion = x.Producto.Descripcion,
                    StockActual = x.Producto.StockActual,
                    StockMinimo = x.Producto.StockMinimo,
                    NumeroLote = x.Producto.NumeroLote,
                    FechaVencimiento = x.Producto.FechaVencimiento,
                }).ToList()
            }).ToList();

            return ListResponse;
        }

        public async Task<OrdenDeCompraDto> GetOrdenCompraById(int id)
        {

            try
            {
                var entidad = await _ordenCompraRepository.GetByIdAsync(id);

                if(entidad is null)
                    throw new Exception("La orden de compra no existe.");

                OrdenDeCompraDto response = new OrdenDeCompraDto()
                {
                    Id = entidad.Id,
                    Descripcion = entidad.Descripcion,
                    PrecioTotal = entidad.PrecioTotal,
                    Fecha = entidad.Fecha,
                    Proveedor = new ProveedorDto()
                    {
                        Id = entidad.Proveedor.Id,
                        Nombre = entidad.Proveedor.Nombre,
                        Apellido = entidad.Proveedor.Apellido,
                        Direccion = entidad.Proveedor.Direccion,
                        Cuil = entidad.Proveedor.Cuil,
                        Telefono = entidad.Proveedor.Telefono,
                        NombreEmpresa = entidad.Proveedor.NombreEmpresa
                    },
                    Productos = entidad.OrdenProductos.Select(x => new ProductoDto()
                    {
                        Id = x.Id,
                        PrecioVenta = x.Producto.PrecioVenta,
                        Descripcion = x.Producto.Descripcion,
                        StockActual = x.Producto.StockActual,
                        StockMinimo = x.Producto.StockMinimo,
                        NumeroLote = x.Producto.NumeroLote,
                        FechaVencimiento = x.Producto.FechaVencimiento,
                    }).ToList()

                };

                return response;
            }
            catch(Exception)
            {
                throw;
            }
        }

        public async Task UpdateOrdenCompra(int id, OrdenCompraUpdate request)
        {
            try
            {
                var entidad = await _ordenCompraRepository.GetByIdAsync(id);

                if(entidad == null)
                    throw new Exception("La orden de compra no existe.");

                entidad.Descripcion = request.Descripcion;
                entidad.Fecha = request.Fecha;

                await _ordenCompraRepository.Update(entidad);
            }
            catch(Exception)
            {
                throw;
            }
        }
    }
}
