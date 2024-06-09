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

        public OrdenCompraService(IOrdenCompraRepository ordenCompraRepository, IProveedorRepository proveedorRepository)
        {
            _ordenCompraRepository = ordenCompraRepository;
            _proveedorRepository = proveedorRepository;
        }

        public async Task<int> AddOrdenCompra(OrdenCompraRequest orden)
        {

            var proveedor = await _proveedorRepository.GetByIdAsync(orden.IdProveedor);

            if(proveedor == null) throw new Exception("el proveedor no existe");

            OrdenDeCompra entidad = new OrdenDeCompra()
            {
                Descripcion = orden.Descripcion,
                PrecioTotal = 100, //calcular
                Fecha = orden.Fecha,
                IdProveedor = orden.IdProveedor,
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
                    throw new Exception("la orden no existe.");

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
                }

            }).ToList();

            return ListResponse;
        }

        public async Task<OrdenDeCompraDto> GetOrdenCompraById(int id)
        {

            try
            {
                var entidad = await _ordenCompraRepository.GetByIdAsync(id);

                if(entidad is null)
                    throw new Exception("El producto no existe.");

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
                    }
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
                    throw new Exception("El producto no existe.");

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
