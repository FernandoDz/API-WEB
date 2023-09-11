using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoDa.AccesoADatos;
using VideoDa.EntidadesDeNegocio;

namespace VideoDa.LogicaDeNegocio
{
    public class ArticuloBL
    {
        public async Task<int> CrearAsync(Articulo pArticulo)
        {
            return await ArticuloDAL.CrearAsync(pArticulo);
        }
        public async Task<int> ModificarAsync(Articulo pArticulo)
        {
            return await ArticuloDAL.ModificarAsync(pArticulo);
        }
        public async Task<int> EliminarAsync(Articulo pArticulo)
        {
            return await ArticuloDAL.EliminarAsync(pArticulo);
        }
        public async Task<Articulo> ObtenerPorIdAsync(Articulo pArticulo)
        {
            return await ArticuloDAL.ObtenerPorIdAsync(pArticulo);
        }
        public async Task<List<Articulo>> ObtenerTodosAsync()
        {
            return await ArticuloDAL.ObtenerTodosAsync();
        }
        public async Task<List<Articulo>> BuscarAsync(Articulo pArticulo)
        {
            return await ArticuloDAL.BuscarAsync(pArticulo);
        }


    }
}
