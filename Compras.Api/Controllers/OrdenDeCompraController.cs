using Compras.Domain.Entidades;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;

namespace Compras.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdenDeCompraController : ControllerBase
    {
        private readonly AppDbContext _context;

        public OrdenesDeComprasController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/OrdenesDeCompras
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OrdenDeCompra>>> ListarOrdenesDeCompra()
        {
            return await _context.OrdenesDeCompra.ToListAsync();
        }

        // GET: api/OrdenesDeCompras/5
        [HttpGet("{id}")]
        public async Task<ActionResult<OrdenDeCompra>> ConsultarOrdenDeCompra(int id)
        {
            var ordenDeCompra = await _context.OrdenesDeCompra.FindAsync(id);

            if (ordenDeCompra == null)
            {
                return NotFound();
            }

            return ordenDeCompra;
        }

        // PUT: api/OrdenesDeCompras/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> ModificarOrdenDeCompra(int id, OrdenDeCompra ordenDeCompra)
        {
            if (id != ordenDeCompra.IdOrdenDeCompra)
            {
                return BadRequest();
            }

            _context.Entry(ordenDeCompra).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OrdenDeCompraExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/OrdenesDeCompras
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<OrdenDeCompra>> RegistrarOrdenDeCompra(OrdenDeCompra ordenDeCompra)
        {
            _context.OrdenesDeCompra.Add(ordenDeCompra);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetOrdenDeCompra", new { id = ordenDeCompra.IdOrdenDeCompra }, ordenDeCompra);
        }

        // DELETE: api/OrdenesDeCompras/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DarDeBajaOrdenDeCompra(int id)
        {
            var ordenDeCompra = await _context.OrdenesDeCompra.FindAsync(id);
            if (ordenDeCompra == null)
            {
                return NotFound();
            }

            _context.OrdenesDeCompra.Remove(ordenDeCompra);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool OrdenDeCompraExists(int id)
        {
            return _context.OrdenesDeCompra.Any(e => e.IdOrdenDeCompra == id);
        }
    }
}
