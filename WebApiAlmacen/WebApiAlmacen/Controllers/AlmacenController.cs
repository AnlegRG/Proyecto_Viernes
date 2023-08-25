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
    public class AlmacenController : ControllerBase
    {
        //traemos la conexion
        private readonly BD_ALMACEN_CYSTELContext _db;

        public AlmacenController(BD_ALMACEN_CYSTELContext db)
        {
            _db = db;
        }

        // GET: api/<AlmacenController>
        [HttpGet("GetProductos")]
        public async Task<IActionResult> GetProductos()
        {
            var query = await _db.Productos.ToListAsync();

            return Ok(query);
        }

        // GET api/<AlmacenController>/5
        [HttpGet("ProductoPor/{id}")]
        public async Task <IActionResult> GetProductoById(int id)
        {
            var productoBuscado = await _db.Productos.FindAsync(id);

            if (productoBuscado is null)
            {
                return BadRequest(new { message = $"Producto con Id {id} No encontrado" });
            }
            return Ok(productoBuscado);

        }
        // POST api/<AlmacenController>
        [HttpPost("CreateProducto")]
        public async Task<IActionResult> PostCrearProducto([FromBody] Producto producto)
        {
            var query = _db.Productos.Add(producto);
            await _db.SaveChangesAsync();
            return CreatedAtAction(nameof(GetProductoById), new { id = producto.Idproducto }, producto);
        }

        // DELETE api/<AlmacenController>/5
        [HttpDelete("EliminarProducto/{id}")]
        public async Task<IActionResult> DeleteProducto(int id)
        {
            var productoBuscado = _db.Productos.Find(id);

            if (productoBuscado is null)
            {
                return BadRequest(new { message = $"Error Al Eliminar El Producto" });
            }

            _db.Remove(productoBuscado);
            await _db.SaveChangesAsync();

            return Ok(new { message = $"Producto Eliminado"});
        }
    }
}
