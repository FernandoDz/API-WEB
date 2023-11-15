using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoDa.EntidadesDeNegocio;

namespace VideoDa.AccesoADatos
{
    public  class TotalesDAL
    {
        public static async Task<Totales> ObtenerTotalesAsync()
        {
            Totales totales = new Totales();

            using (var bdContexto = new BDContexto())
            {
                totales.TotalCategorias = await bdContexto.Categorias.CountAsync();
                totales.TotalProductos = await bdContexto.Productos.CountAsync();
                totales.TotalArticulos = await bdContexto.Articulos.CountAsync();
                totales.TotalConsolas = await bdContexto.Consolas.CountAsync();
            }

            return totales;
        }

    }
}
