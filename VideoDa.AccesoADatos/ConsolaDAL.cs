using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoDa.EntidadesDeNegocio;

namespace VideoDa.AccesoADatos
{
    public class ConsolaDAL
    {
        public static async Task<int> CrearAsync(Consola pConsola)
        {
            int result = 0;
            using (var bdContexto = new BDContexto())
            {
                bdContexto.Add(pConsola);
                result = await bdContexto.SaveChangesAsync();
            }
            return result;
        }

        public static async Task<int> ModificarAsync(Consola pConsola)
        {
            int result = 0;
            using (var bdContexto = new BDContexto())
            {
                var consola = await bdContexto.Consolas.FirstOrDefaultAsync(s => s.Id == pConsola.Id);
                consola.Nombre = pConsola.Nombre;
                consola.Descripcion = pConsola.Descripcion;
                consola.Serie = pConsola.Serie;
                consola.Fabricante = pConsola.Fabricante;
                consola.Fabricante = pConsola.Fabricante;
                consola.Imagen = pConsola.Imagen;
                consola.AñodeLanzamiento = pConsola.AñodeLanzamiento;
                bdContexto.Update(consola);
                result = await bdContexto.SaveChangesAsync();
            }
            return result;
        }

        public static async Task<int> EliminarAsync(Consola pConsola)
        {
            int result = 0;
            using (var bdContexto = new BDContexto())
            {
                var consola = await bdContexto.Consolas.FirstOrDefaultAsync(s => s.Id == pConsola.Id);
                bdContexto.Consolas.Remove(consola);
                result = await bdContexto.SaveChangesAsync();
            }
            return result;
        }

        public static async Task<Consola> ObtenerPorIdAsync(Consola pConsola)
        {
            var consola = new Consola();
            using (var bdContexto = new BDContexto())
            {
                consola = await bdContexto.Consolas.FirstOrDefaultAsync(s => s.Id == pConsola.Id);
            }
            return consola;
        }

        public static async Task<List<Consola>> ObtenerTodosAsync()
        {
            var consolas = new List<Consola>();
            using (var bdContexto = new BDContexto())
            {
                consolas = await bdContexto.Consolas.ToListAsync();
            }
            return consolas;
        }

        internal static IQueryable<Consola> QuerySelect(IQueryable<Consola> pQuery, Consola pConsola)
        {
            if (pConsola.Id > 0)
                pQuery = pQuery.Where(s => s.Id == pConsola.Id);

            if (!string.IsNullOrWhiteSpace(pConsola.Nombre))
                pQuery = pQuery.Where(s => s.Nombre.Contains(pConsola.Nombre));
            if (!string.IsNullOrWhiteSpace(pConsola.Descripcion))
                pQuery = pQuery.Where(s => s.Descripcion.Contains(pConsola.Descripcion));
            if (!string.IsNullOrWhiteSpace(pConsola.Serie))
                pQuery = pQuery.Where(s => s.Serie.Contains(pConsola.Serie));
            if (!string.IsNullOrWhiteSpace(pConsola.Fabricante))
                pQuery = pQuery.Where(s => s.Fabricante.Contains(pConsola.Fabricante));
            if (!string.IsNullOrWhiteSpace(pConsola.AñodeLanzamiento))
                pQuery = pQuery.Where(s => s.AñodeLanzamiento.Contains(pConsola.AñodeLanzamiento));

            if (!string.IsNullOrWhiteSpace(pConsola.Imagen))
                pQuery = pQuery.Where(s => s.Imagen.Contains(pConsola.Imagen));


            pQuery = pQuery.OrderByDescending(s => s.Id).AsQueryable();

            if (pConsola.Top_Aux > 0)
                pQuery = pQuery.Take(pConsola.Top_Aux).AsQueryable();

            return pQuery;
        }

        public static async Task<List<Consola>> BuscarAsync(Consola pConsola)
        {
            var consolas = new List<Consola>();
            using (var bdContexto = new BDContexto())
            {
                var select = bdContexto.Consolas.AsQueryable();
                select = QuerySelect(select, pConsola);
                consolas = await select.ToListAsync();
            }
            return consolas;
        }
    }
}
