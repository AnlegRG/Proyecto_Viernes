using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiAlmacen.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApiAlmacen.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransaccionesController : ControllerBase
    {
        private readonly BD_ALMACEN_CYSTELContext _db;

        public TransaccionesController(BD_ALMACEN_CYSTELContext db)
        {
            _db = db;
        }

        // GET: api/<TransaccionesController>
        [HttpGet("GetTransacciones")]
        public async Task<IActionResult> GetTransacciones()
        {
            var transacciones = await _db.Transacciones
                .ToListAsync();

            return Ok(transacciones);
        }

        // GET api/<TransaccionesController>/5
        [HttpGet("GetTransaccionById/{id}")]
        public async Task<IActionResult> GetTransaccionById(int id)
        {
            var transaccionBuscada = await _db.Transacciones.FindAsync(id);

            if(transaccionBuscada is null)
            {
                return BadRequest(new { message = $"Transaccion con Id {id} No Existe"});
            }

            return Ok(transaccionBuscada);
        }

        // POST api/<TransaccionesController>
        [HttpPost("CreateTransaccion")]
        public async Task<IActionResult> PostCreateTransaccion([FromBody] Transaccione transaccione)
        {
            var query = _db.Add(transaccione);

            await _db.SaveChangesAsync();

            return CreatedAtAction(nameof(GetTransaccionById), new { id = transaccione.Idtransaccion }, transaccione);
        }

        // DELETE api/<TransaccionesController>/5
        [HttpDelete("DeleteTransaccion/{id}")]
        public async Task<IActionResult> DeleteTransaccion(int id)
        {
            var transaccionBuscada = await _db.Transacciones.FindAsync(id);

            if (transaccionBuscada is null)
            {
                return BadRequest(new { message = $"Error al Eliminar Transaccion" });
            }

            _db.Remove(transaccionBuscada);

            await _db.SaveChangesAsync();
            
            return Ok(new { message = $"Se Elimino Transaccion" });
        }
    }
}
