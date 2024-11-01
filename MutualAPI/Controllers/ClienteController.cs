using Microsoft.AspNetCore.Mvc;
using MutualService;
using MutualDTO;
namespace MutualAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private ClienteService Llamar { get; set; }
        public ClienteController()
        {
            Llamar = new ClienteService();
        }
        [HttpGet]
        public IActionResult Get()
        {
            var lista = Llamar.ObtenerClientes();
            return Ok(lista);
        }

        // GET api/<ValuesController>/5
        [HttpGet("{dni}")]
        public IActionResult Get(int dni)
        {
            var cliente = Llamar.ObtenerClientePorDni(dni);
            if (cliente == null) { return NotFound(9); }
            return Ok(cliente);
        }

        // POST api/<ValuesController>
        [HttpPost]
        public IActionResult Post([FromBody] ClienteDTO clienteDto)
        {
            if (!ModelState.IsValid) { return BadRequest(); }
            Llamar.AgregarCliente(clienteDto);
            return Created();
        }

        // PUT api/<ValuesController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] ClienteDTO clienteDto)
        {
            if (!ModelState.IsValid) { return BadRequest(); }
            var success = Llamar.EditarCliente(id, clienteDto);
            if (!success) { return NotFound(); }
            return Ok();

        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var success = Llamar.EliminarCliente(id);
            if (!success) { return NotFound(); }
            return Ok();
        }
    }
}
