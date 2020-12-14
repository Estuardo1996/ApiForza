using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApiForza.Data;
using ApiForza.Modelo;

namespace ApiForza.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComprasController : ControllerBase
    {
        private readonly ApiForzaContext _context;

        public ComprasController(ApiForzaContext context)
        {
            _context = context;
        }

        // GET: api/Compras
        [HttpGet]
        public  ActionResult<IEnumerable<Compras>> GetCompras()
        {
            return  _context.Compras.ToList();
        }

        // GET: api/Compras/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Compras>> GetCompras(int id)
        {
            var compras = await _context.Compras.FindAsync(id);

            if (compras == null)
            {
                return NotFound();
            }

            return compras;
        }

        // PUT: api/Compras/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCompras(int id, Compras compras)
        {
            if (id != compras.IdCompras)
            {
                return BadRequest();
            }

            _context.Entry(compras).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ComprasExists(id))
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

        // POST: api/Compras
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Compras>> PostCompras(Compras compras)
        {
            _context.Compras.Add(compras);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCompras", new { id = compras.IdCompras }, compras);
        }

        // DELETE: api/Compras/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Compras>> DeleteCompras(int id)
        {
            var compras = await _context.Compras.FindAsync(id);
            if (compras == null)
            {
                return NotFound();
            }

            _context.Compras.Remove(compras);
            await _context.SaveChangesAsync();

            return compras;
        }

        private bool ComprasExists(int id)
        {
            return _context.Compras.Any(e => e.IdCompras == id);
        }
    }
}
