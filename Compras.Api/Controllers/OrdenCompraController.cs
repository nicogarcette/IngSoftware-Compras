using Compras.Aplication.Dtos.Request;
using Compras.Aplication.Interfaces.IServices;
using Microsoft.AspNetCore.Mvc;

namespace Compras.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdenCompraController : ControllerBase
    {
        private readonly IOrdenCompraService _ordenCompraService;

        public OrdenCompraController(IOrdenCompraService ordenCompraService)
        {
            _ordenCompraService = ordenCompraService;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] OrdenCompraRequest value)
        {

            try
            {
                var response = await _ordenCompraService.AddOrdenCompra(value);

                return StatusCode(StatusCodes.Status201Created, response);

                return Ok(response);
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
                var response = await _ordenCompraService.GetAllOrdenCompras();
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
                var response = await _ordenCompraService.GetOrdenCompraById(id);
                return Ok(response);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }


        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] OrdenCompraUpdate value)
        {
            try
            {
                await _ordenCompraService.UpdateOrdenCompra(id, value);
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
                await _ordenCompraService.DeleteOrdenCompra(id);
                return Ok();
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
