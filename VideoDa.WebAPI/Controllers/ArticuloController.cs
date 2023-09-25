using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VideoDa.EntidadesDeNegocio;
using VideoDa.LogicaDeNegocio;
using System.Text.Json;
using Microsoft.AspNetCore.Authorization;

namespace VideoDa.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ArticuloController : ControllerBase
    {

        private ArticuloBL articuloBL = new ArticuloBL();
        [HttpGet]
        [AllowAnonymous]
        public async Task<IEnumerable<Articulo>> Get()
        {
            return await articuloBL.ObtenerTodosAsync();


        }
        [HttpGet("{id}")]
        [AllowAnonymous]
        public async Task<Articulo> Get(int id)
        {
            Articulo articulo = new Articulo();
            articulo.Id = id;
            return await articuloBL.ObtenerPorIdAsync(articulo);

        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Articulo articulo)
        {
            try
            {
                await articuloBL.CrearAsync(articulo);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        [HttpPut]
        public async Task<ActionResult> Put(int id, [FromBody] Articulo articulo)
        {
            if (articulo.Id == id)
            {
                await articuloBL.ModificarAsync(articulo);
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
                Articulo articulo = new Articulo();
                articulo.Id = id;
                await articuloBL.EliminarAsync(articulo);
                return Ok();

            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        [HttpPost("Buscar")]
        public async Task<List<Articulo>> Buscar([FromBody] object pArticulo)
        {
            var option = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            string strConsola = JsonSerializer.Serialize(pArticulo);
            Articulo articulo = JsonSerializer.Deserialize<Articulo>(strConsola, option);
            return await articuloBL.BuscarAsync(articulo);
        }



    }
}
