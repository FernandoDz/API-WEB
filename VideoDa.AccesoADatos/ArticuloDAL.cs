using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoDa.EntidadesDeNegocio;

namespace VideoDa.AccesoADatos
{
    public class ArticuloDAL
    {
        public static async Task<int> CrearAsync(Articulo pArticulo)
        {
            int result = 0;
            using (var bdContexto = new BDContexto())
            {
                bdContexto.Add(pArticulo);
                result = await bdContexto.SaveChangesAsync();
            }
            return result;
        }

        public static async Task<int> ModificarAsync(Articulo pArticulo)
        {
            int result = 0;
            using (var bdContexto = new BDContexto())
            {
                var articulo = await bdContexto.Articulos.FirstOrDefaultAsync(s => s.Id == pArticulo.Id);
                articulo.IdConsola = pArticulo.IdConsola;
                articulo.Nombre = pArticulo.Nombre;
                articulo.Descripcion = pArticulo.Descripcion;
                articulo.Cantidad = pArticulo.Cantidad;
                articulo.Imagen = pArticulo.Imagen;
                articulo.Precio = pArticulo.Precio;
                bdContexto.Update(articulo);
                result = await bdContexto.SaveChangesAsync();
            }
            return result;
        }

        public static async Task<int> EliminarAsync(Articulo pArticulo)
        {
            int result = 0;
            using (var bdContexto = new BDContexto())
            {
                var articulo = await bdContexto.Articulos.FirstOrDefaultAsync(s => s.Id == pArticulo.Id);
                bdContexto.Articulos.Remove(articulo);
                result = await bdContexto.SaveChangesAsync();
            }
            return result;
        }

        public static async Task<Articulo> ObtenerPorIdAsync(Articulo pArticulo)
        {
            var articulo = new Articulo();
            using (var bdContexto = new BDContexto())
            {
                articulo = await bdContexto.Articulos.FirstOrDefaultAsync(s => s.Id == pArticulo.Id);
            }
            return articulo;
        }

        public static async Task<List<Articulo>> ObtenerTodosAsync()
        {
            var articulos = new List<Articulo>();
            using (var bdContexto = new BDContexto())
            {
                articulos = await bdContexto.Articulos.ToListAsync();
            }
            return articulos;
        }

        internal static IQueryable<Articulo> QuerySelect(IQueryable<Articulo> pQuery, Articulo pArticulo)
        {
            if (pArticulo.Id > 0)
                pQuery = pQuery.Where(s => s.Id == pArticulo.Id);

            if (pArticulo.IdConsola > 0)
                pQuery = pQuery.Where(s => s.IdConsola == pArticulo.IdConsola);

            if (!string.IsNullOrWhiteSpace(pArticulo.Precio))
                pQuery = pQuery.Where(s => s.Precio.Contains(pArticulo.Precio));

            if (!string.IsNullOrWhiteSpace(pArticulo.Nombre))
                pQuery = pQuery.Where(s => s.Nombre.Contains(pArticulo.Nombre));
            if (!string.IsNullOrWhiteSpace(pArticulo.Descripcion))
                pQuery = pQuery.Where(s => s.Descripcion.Contains(pArticulo.Descripcion));
            if (!string.IsNullOrWhiteSpace(pArticulo.Cantidad))
                pQuery = pQuery.Where(s => s.Cantidad.Contains(pArticulo.Cantidad));
            if (!string.IsNullOrWhiteSpace(pArticulo.Imagen))
                pQuery = pQuery.Where(s => s.Imagen.Contains(pArticulo.Imagen));
            pQuery = pQuery.OrderByDescending(s => s.Id).AsQueryable();

            if (pArticulo.Top_Aux > 0)
                pQuery = pQuery.Take(pArticulo.Top_Aux).AsQueryable();

            return pQuery;
        }

        public static async Task<List<Articulo>> BuscarAsync(Articulo pArticulo)
        {
            var articulos = new List<Articulo>();
            using (var bdContexto = new BDContexto())
            {
                var select = bdContexto.Articulos.AsQueryable();
                select = QuerySelect(select, pArticulo);
                articulos = await select.ToListAsync();
            }
            return articulos;
        }
    }
}
