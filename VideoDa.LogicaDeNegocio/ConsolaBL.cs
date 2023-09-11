using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoDa.AccesoADatos;
using VideoDa.EntidadesDeNegocio;

namespace VideoDa.LogicaDeNegocio
{
    public class ConsolaBL
    {
        public async Task<int> CrearAsync(Consola pConsola)
        {
            return await ConsolaDAL.CrearAsync(pConsola);
        }
        public async Task<int> ModificarAsync(Consola pConsola)
        {
            return await ConsolaDAL.ModificarAsync(pConsola);
        }
        public async Task<int> EliminarAsync(Consola pConsola)
        {
            return await ConsolaDAL.EliminarAsync(pConsola);
        }
        public async Task<Consola> ObtenerPorIdAsync(Consola pConsola)
        {
            return await ConsolaDAL.ObtenerPorIdAsync(pConsola);
        }
        public async Task<List<Consola>> ObtenerTodosAsync()
        {
            return await ConsolaDAL.ObtenerTodosAsync();
        }
        public async Task<List<Consola>> BuscarAsync(Consola pConsola)
        {
            return await ConsolaDAL.BuscarAsync(pConsola);
        }


    }
}
