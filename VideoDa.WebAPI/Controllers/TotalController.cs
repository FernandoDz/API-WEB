using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VideoDa.AccesoADatos;
using VideoDa.EntidadesDeNegocio;
using VideoDa.LogicaDeNegocio;

namespace VideoDa.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class TotalController : Controller
         
    {
        private TotalesBL totalesBL = new TotalesBL();
        [HttpGet("Totales")]
        [AllowAnonymous]
        public async Task<Totales> GetTotales()
        {
            return await totalesBL.ObtenerTotalesAsync();
        }
    }
}
