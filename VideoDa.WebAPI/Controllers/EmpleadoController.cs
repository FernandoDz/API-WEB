using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using VideoDa.EntidadesDeNegocio;
using VideoDa.LogicaDeNegocio;

namespace VideoDa.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class EmpleadoController : ControllerBase
    {
        private EmpleadoBL empleadoBL = new EmpleadoBL();

        [HttpGet]
        public async Task<IEnumerable<Empleado>> Get()
        {
            return await empleadoBL.ObtenerTodosAsync();
        }
        [HttpGet("{id}")]
        public async Task<Empleado> Get(int id)
        {
            Empleado empleado = new Empleado();
            empleado.Id = id;
            return await empleadoBL.ObtenerPorIdAsync(empleado);
        }
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Empleado empleado)
        {
            try
            {
                await empleadoBL.CrearAsync(empleado);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        [HttpPut]
        public async Task<ActionResult> Put(int id, [FromBody] Empleado empleado)
        {
            if (empleado.Id == id)
            {
                await empleadoBL.ModificarAsync(empleado);
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                Empleado empleado = new Empleado();
                empleado.Id = id;
                await empleadoBL.EliminarAsync(empleado);
                return Ok();

            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        [HttpPost("Buscar")]
        public async Task<List<Empleado>> Buscar([FromBody] object pEmpleado)
        {
            var option = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            string strEmpleado = JsonSerializer.Serialize(pEmpleado);
            Empleado empleado = JsonSerializer.Deserialize<Empleado>(strEmpleado, option);
            return await empleadoBL.BuscarAsync(empleado);
        }
    }
}

