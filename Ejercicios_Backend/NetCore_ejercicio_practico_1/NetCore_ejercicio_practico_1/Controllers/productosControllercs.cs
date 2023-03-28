using Microsoft.AspNetCore.Mvc;
using NetCore_ejercicio_practico_1.Data;
using NetCore_ejercicio_practico_1.Models;

namespace NetCore_ejercicio_practico_1.Controllers
{
    [ApiController]
    [Route("productos")]
    public class repository : ControllerBase
    {
        private readonly Iproductos _productosData;
        public repository(Iproductos productosData)
        {
            _productosData = productosData;
        }

        [HttpGet]
        public async Task<IActionResult> leerProductos()
        {
            return Ok(await _productosData.LeerProductos());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> leerDetalles(int id)
        {
            return Ok(await _productosData.leerDetalles(id));
        }

        [HttpPost]
        public async Task<IActionResult> agregarProducto([FromBody] producto producto)
        {
            if (producto == null)
                return BadRequest();
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var agregado = await _productosData.agregarProducto(producto);
            return Created("agregado", agregado);
        }
        
        
        [HttpPut]
        public async Task<IActionResult> acrualizarProducto([FromBody] producto producto)
        {
            if (producto == null)
                return BadRequest();
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            await _productosData.actualizarProducto(producto);
            return NoContent();
        }

        [HttpDelete]
        public async Task<IActionResult> borrarProducto(int id)
        {
            await _productosData.eliminarProducto(new producto { id = id });
            return NoContent();
        }
    }
}
