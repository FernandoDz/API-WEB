using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoDa.EntidadesDeNegocio;

namespace VideoDa.AccesoADatos
{
    public class ProductoDAL
    {
        public static async Task<int> CrearAsync(Producto pProducto)
        {
            int result = 0;
            using (var bdContexto = new BDContexto())
            {
                bdContexto.Add(pProducto);
                result = await bdContexto.SaveChangesAsync();
            }
            return result;
        }

        public static async Task<int> ModificarAsync(Producto pProducto)
        {
            int result = 0;
            using (var bdContexto = new BDContexto())
            {
                var producto = await bdContexto.Productos.FirstOrDefaultAsync(s => s.Id == pProducto.Id);
                producto.IdCategoria = pProducto.IdCategoria;
                producto.IdConsola = pProducto.IdConsola;
                producto.Nombre = pProducto.Nombre;
                producto.Descripcion = pProducto.Descripcion;
                producto.Cantidad = pProducto.Cantidad;
                producto.Precio = pProducto.Precio;
                producto.Imagen = pProducto.Imagen;
                bdContexto.Update(producto);
                result = await bdContexto.SaveChangesAsync();
            }
            return result;
        }

        public static async Task<int> EliminarAsync(Producto pProducto)
        {
            int result = 0;
            using (var bdContexto = new BDContexto())
            {
                var producto = await bdContexto.Productos.FirstOrDefaultAsync(s => s.Id == pProducto.Id);
                bdContexto.Productos.Remove(producto);
                result = await bdContexto.SaveChangesAsync();
            }
            return result;
        }

        public static async Task<Producto> ObtenerPorIdAsync(Producto pProducto)
        {
            var producto = new Producto();
            using (var bdContexto = new BDContexto())
            {
                producto = await bdContexto.Productos.FirstOrDefaultAsync(s => s.Id == pProducto.Id);
            }
            return producto;
        }

        public static async Task<List<Producto>> ObtenerTodosAsync()
        {
            var productos = new List<Producto>();
            using (var bdContexto = new BDContexto())
            {
                productos = await bdContexto.Productos.ToListAsync();
            }
            return productos;
        }

        internal static IQueryable<Producto> QuerySelect(IQueryable<Producto> pQuery, Producto pProducto)
        {
            if (pProducto.Id > 0)
                pQuery = pQuery.Where(s => s.Id == pProducto.Id);
            if (pProducto.IdCategoria > 0)
                pQuery = pQuery.Where(s => s.IdConsola == pProducto.IdCategoria);
            if (pProducto.IdConsola > 0)
                pQuery = pQuery.Where(s => s.IdConsola == pProducto.IdConsola);

            if (!string.IsNullOrWhiteSpace(pProducto.Nombre))
                pQuery = pQuery.Where(s => s.Nombre.Contains(pProducto.Nombre));
            if (!string.IsNullOrWhiteSpace(pProducto.Descripcion))
                pQuery = pQuery.Where(s => s.Descripcion.Contains(pProducto.Descripcion));
            if (!string.IsNullOrWhiteSpace(pProducto.Cantidad))
                pQuery = pQuery.Where(s => s.Cantidad.Contains(pProducto.Cantidad));
            if (!string.IsNullOrWhiteSpace(pProducto.Precio))
                pQuery = pQuery.Where(s => s.Precio.Contains(pProducto.Precio));

            if (!string.IsNullOrWhiteSpace(pProducto.Imagen))
                pQuery = pQuery.Where(s => s.Imagen.Contains(pProducto.Imagen));


            pQuery = pQuery.OrderByDescending(s => s.Id).AsQueryable();

            if (pProducto.Top_Aux > 0)
                pQuery = pQuery.Take(pProducto.Top_Aux).AsQueryable();

            return pQuery;
        }

        public static async Task<List<Producto>> BuscarAsync(Producto pProducto)
        {
            var productos = new List<Producto>();
            using (var bdContexto = new BDContexto())
            {
                var select = bdContexto.Productos.AsQueryable();
                select = QuerySelect(select, pProducto);
                productos = await select.ToListAsync();
            }
            return productos;
        }
    }
}
