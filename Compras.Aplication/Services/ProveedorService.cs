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


        public async Task DeleteProveedor(int id)
        {
            try
            {
                Proveedor proveedor = await _proveedorRepository.GetByIdAsync(id);

                if(proveedor == null)
                    throw new Exception("El proveedor no existe.");

                await _proveedorRepository.Delete(proveedor);
            }
            catch(Exception)
            {
                throw;
            }
        }

        public async Task<List<ProveedorDto>> GetAllProveedores()
        {
            var proveedores = await _proveedorRepository.GetAllAsync();

            List<ProveedorDto> ListResponse = proveedores.Select(proveedor => new ProveedorDto()
            {
                Id = proveedor.Id,
                Nombre = proveedor.Nombre,
                Apellido = proveedor.Apellido,
                Direccion = proveedor.Direccion,
                Cuil = proveedor.Cuil,
                Telefono = proveedor.Telefono,
                NombreEmpresa = proveedor.NombreEmpresa
            }).ToList();

            return ListResponse;
        }

        public async Task<ProveedorDto> GetProveedorById(int id)
        {

            try
            {
                Proveedor proveedor = await _proveedorRepository.GetByIdAsync(id);

                if(proveedor is null)
                    throw new Exception("El proveedor no existe.");

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
            catch(Exception)
            {

                throw;
            }
        }

        public async Task UpdateProveedor(int id, ProveedorRequest request)
        {
            try
            {
                Proveedor proveedor = await _proveedorRepository.GetByIdAsync(id);

                if(proveedor == null)
                    throw new Exception("El proveedor no existe.");

                proveedor.Nombre = request.Nombre;
                proveedor.Apellido = request.Apellido;
                proveedor.Direccion = request.Direccion;
                proveedor.Cuil = request.Cuil;
                proveedor.Telefono = request.Telefono;
                proveedor.NombreEmpresa = request.NombreEmpresa;

                await _proveedorRepository.Update(proveedor);
            }
            catch(Exception)
            {
                throw;
            }
        }
    }
}
