using Compras.Aplication.Dtos;
using Compras.Aplication.Dtos.Request;
using Compras.Aplication.Interfaces.IRepositories;
using Compras.Aplication.Interfaces.IServices;
using Compras.Domain.Entidades;

namespace Compras.Aplication.Services
{
    public class ProveedorService : IProveedorService
    {

        private readonly IProveedorRepository _proveedorRepository;

        public ProveedorService(IProveedorRepository proveedorRepository)
        {
            _proveedorRepository = proveedorRepository;
        }

        public async Task<int> AddProveedor(ProveedorRequest proveedor)
        {

            // hacer posible validaciones si fuera el caso.
            Proveedor nuevoProveedor = new Proveedor()
            {
                Nombre = proveedor.Nombre,
                Apellido = proveedor.Apellido,
                Cuil = proveedor.Cuil,
                Direccion = proveedor.Direccion,
                Telefono = proveedor.Telefono,
                NombreEmpresa = proveedor.NombreEmpresa
            };

            await _proveedorRepository.Add(nuevoProveedor);

            return nuevoProveedor.Id;
        }


        public Task DeleteProveedor(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<ProveedorDto>> GetAllProveedores()
        {
            throw new NotImplementedException();
        }

        public async Task<ProveedorDto> GetProveedorById(int id)
        {

            Proveedor proveedor = await _proveedorRepository.GetByIdAsync(id);

            ProveedorDto response = new ProveedorDto()
            {
                Id = proveedor.Id,
                Nombre = proveedor.Nombre,
                Apellido = proveedor.Apellido,
                Cuil = proveedor.Cuil,
                Direccion = proveedor.Direccion,
                Telefono = proveedor.Telefono,
                NombreEmpresa = proveedor.NombreEmpresa
            };

            return response;
        }

        public Task UpdateProveedor(ProveedorRequest proveedor)
        {
            throw new NotImplementedException();
        }
    }
}
