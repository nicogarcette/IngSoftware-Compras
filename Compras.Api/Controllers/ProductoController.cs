using Compras.Aplication.Dtos.Request;
using Compras.Aplication.Interfaces.IServices;
using Microsoft.AspNetCore.Mvc;

namespace Compras.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoController : ControllerBase
    {
        private readonly IProductoService _productoServices;

        public ProductoController(IProductoService productoService)
        {
            _productoServices = productoService;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ProductoRequest value)
        {
            try
            {
                var response = await _productoServices.AddProducto(value);
                return StatusCode(StatusCodes.Status201Created, response);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var response = await _productoServices.GetAllProducto();
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
                var response = await _productoServices.GetProductoById(id);
                return Ok(response);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] ProductoRequest value)
        {
            try
            {
                await _productoServices.UpdateProducto(id, value);
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
                await _productoServices.DeleteProducto(id);
                return Ok();
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
