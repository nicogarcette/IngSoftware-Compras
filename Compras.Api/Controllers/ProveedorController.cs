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

        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var response = await _proveedorServices.GetProveedorById(id);
            return Ok(response);
        }


        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ProveedorRequest value)
        {
            var response = await _proveedorServices.AddProveedor(value);
            return Ok(response);
        }

        [HttpPut]
        [Route("{id}")]
        public void Put(int id, [FromBody] string value)
        {

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
