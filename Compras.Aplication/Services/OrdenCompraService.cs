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

        public OrdenCompraService(IOrdenCompraRepository ordenCompraRepository)
        {
            _ordenCompraRepository = ordenCompraRepository;
        }

        public async Task<int> AddOrdenCompra(OrdenCompraRequest orden)
        {

            // hacer posible validaciones si fuera el caso.
            OrdenDeCompra entidad = new OrdenDeCompra()
            {
                //setears
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
                    throw new Exception("El Producto no existe.");

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

            List<OrdenDeCompraDto> ListResponse = ordenes.Select(proveedor => new OrdenDeCompraDto()
            {
                // SETEAR
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
                    // setear los datos
                };

                return response;
            }
            catch(Exception)
            {
                throw;
            }
        }

        public async Task UpdateOrdenCompra(int id, OrdenCompraRequest request)
        {
            try
            {
                var entidad = await _ordenCompraRepository.GetByIdAsync(id);

                if(entidad == null)
                    throw new Exception("El producto no existe.");


                // actualiazar los campos


                await _ordenCompraRepository.Update(entidad);
            }
            catch(Exception)
            {
                throw;
            }
        }
    }
}
