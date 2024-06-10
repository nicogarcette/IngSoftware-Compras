using Compras.Aplication.Dtos.Request;
using Compras.Aplication.Interfaces.IServices;
using Microsoft.AspNetCore.Mvc;

namespace Compras.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProveedorController : ControllerBase
    {
        private readonly IProveedorService _proveedorServices;

        public ProveedorController(IProveedorService proveedorService)
        {
            _proveedorServices = proveedorService;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ProveedorRequest value)
        {
            try
            {
                var response = await _proveedorServices.AddProveedor(value);
                return StatusCode(StatusCodes.Status201Created, response);

            }
            catch(Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var response = await _proveedorServices.GetAllProveedores();
                return Ok(response);
            }
            catch(Exception)
            {
                return BadRequest();
            }
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var response = await _proveedorServices.GetProveedorById(id);
                return Ok(response);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }


        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] ProveedorRequest value)
        {
            try
            {
                await _proveedorServices.UpdateProveedor(id, value);
                return Ok();
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _proveedorServices.DeleteProveedor(id);
                return Ok();
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
