using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VideoDa.EntidadesDeNegocio;
using VideoDa.LogicaDeNegocio;
using System.Text.Json;
using Microsoft.AspNetCore.Authorization;
using VideoDa.AccesoADatos;

namespace VideoDa.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ConsolaController : ControllerBase
    {
        
        private ConsolaBL consolaBL = new ConsolaBL();
        [HttpGet]
        [AllowAnonymous]
        public async Task<IEnumerable<Consola>> Get(){
            return await consolaBL.ObtenerTodosAsync();
        
        
        }
        [HttpGet("{id}")]
        [AllowAnonymous]
        public async Task<Consola> Get(int id) {
            Consola consola = new Consola();
            consola.Id = id;
            return await consolaBL.ObtenerPorIdAsync(consola);
           
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Consola consola)
        {
            try
            {
                await consolaBL.CrearAsync(consola);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        [HttpPut]
        public async Task<ActionResult> Put(int id, [FromBody] Consola consola)
        {
            if (consola.Id == id)
            {
                await consolaBL.ModificarAsync(consola);
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
                Consola consola = new Consola();
                consola.Id = id;
                await consolaBL.EliminarAsync(consola);
                return Ok();

            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        [HttpPost("Buscar")]
        public async Task<List<Consola>> Buscar([FromBody] object pConsola)
        {

            var option = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            string strConsola= JsonSerializer.Serialize(pConsola);
            Consola consola = JsonSerializer.Deserialize<Consola>(strConsola, option);
            var consolas = await consolaBL.BuscarAsync(consola);
            return consolas;
        }

    }

}
