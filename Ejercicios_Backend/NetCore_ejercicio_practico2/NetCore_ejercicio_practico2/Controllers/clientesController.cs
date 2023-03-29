using Microsoft.AspNetCore.Mvc;
using NetCore_ejercicio_practico2.Data;

namespace NetCore_ejercicio_practico2.Controllers
{
    [ApiController]
    [Route("clienteModel")]
    public class clientesController : ControllerBase
    {
        private readonly Iclientes _clientesData;
        public clientesController(Iclientes clientesData)
        {
            _clientesData = clientesData;
        }
       
        [HttpGet]
        public async Task<IActionResult> leerclientes()
        {
            return Ok(await _clientesData.leerclientes());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> leerclientesxid(int id)
        {
            return Ok(await _clientesData.leerclientesxid(id));
        }
        [HttpGet("{nombre}")]
        public async Task<IActionResult> leerclientesxnombre(String nombre)
        {
            return Ok(await _clientesData.leerclientesxnombre(nombre));
        }
        [HttpGet("{edad}")]
        public async Task<IActionResult> leerclientesxedad(int edad)
        {
            return Ok(await _clientesData.leerclientesxedad(edad));
        }
    }
}
