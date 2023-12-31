﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using VideoDa.AccesoADatos;
using VideoDa.EntidadesDeNegocio;
using VideoDa.LogicaDeNegocio;

namespace VideoDa.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CategoriaController : ControllerBase
    {
        private CategoriaBL categoriaBL = new CategoriaBL();

        [HttpGet]
        [AllowAnonymous]
        public async Task<IEnumerable<Categoria>> Get()
        {
            return await categoriaBL.ObtenerTodosAsync();
        }

        [HttpGet("{id}")]
        [AllowAnonymous]
        public async Task<Categoria> Get(int id)
        {
            Categoria categoria = new Categoria();
            categoria.Id = id;
            return await categoriaBL.ObtenerPorIdAsync(categoria);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Categoria categoria)
        {
            try
            {
                await categoriaBL.CrearAsync(categoria);
                return Ok();

            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] Categoria categoria)
        {
            if (categoria.Id == id)
            {
                await categoriaBL.ModificarAsync(categoria);
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
                Categoria categoria = new Categoria();
                categoria.Id = id;
                await categoriaBL.EliminarAsync(categoria);
                return Ok();

            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        [HttpPost("Buscar")]
        public async Task<List<Categoria>> Buscar([FromBody] object pCategoria)
        {

            var option = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            string strCategoria = JsonSerializer.Serialize(pCategoria);
            Categoria categoria = JsonSerializer.Deserialize<Categoria>(strCategoria, option);
            var categorias = await categoriaBL.BuscarAsync(categoria);
            return categorias;
        }
        
    }
    
}
