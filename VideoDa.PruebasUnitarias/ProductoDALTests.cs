using Microsoft.VisualStudio.TestTools.UnitTesting;
using VideoDa.AccesoADatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoDa.EntidadesDeNegocio;

namespace VideoDa.AccesoADatos.Tests
{
    [TestClass()]
    public class ProductoDALTests
    {
        private static Producto productoInicial = new Producto { Id = 2, IdCategoria = 2, IdConsola = 2 };
        [TestMethod()]
        public async Task T1CrearAsyncTest()
        {
            var producto = new Producto();
            producto.IdCategoria = productoInicial.IdCategoria;
            producto.IdConsola = productoInicial.IdConsola;
            producto.Nombre = "The Legend of Zelda: Breath of the Wild";
            producto.Descripcion = "Explora el mundo de Hyrule en este épico juego de aventuras.";
            producto.Cantidad = "30";
            producto.Precio = "$49.99";
            producto.Imagen = "Zelda Breath of the Wild.pnj";
            int result = await ProductoDAL.CrearAsync(producto);
            Assert.AreNotEqual(0, result);
            productoInicial.Id = producto.Id;
        }

        [TestMethod()]
        public async Task T2ModificarAsyncTest()
        {
            var producto = new Producto();
            producto.IdCategoria = productoInicial.IdCategoria;
            producto.IdConsola = productoInicial.IdConsola;
            producto.Nombre = "The Legend of Zelda: Breath of the Wild";
            producto.Descripcion = "Explora el mundo de Hyrule en este épico juego de aventuras.";
            producto.Cantidad = "30";
            producto.Precio = "$49.99";
            producto.Imagen = "Zelda Breath of the Wild.pnj";
            int result = await ProductoDAL.ModificarAsync(producto);
            Assert.AreNotEqual(0, result);
        }

        [TestMethod()]
        public async Task T3EliminarAsyncTest()
        {
            var producto = new Producto();
            producto.Id = productoInicial.Id;
            int result = await ProductoDAL.EliminarAsync(producto);
            Assert.AreNotEqual(0, result);
        }

        [TestMethod()]
        public async Task T4ObtenerPorIdAsyncTest()
        {
            var producto = new Producto();
            producto.Id = productoInicial.Id;
            var resultProducto = await ProductoDAL.ObtenerPorIdAsync(producto);
            Assert.AreEqual(producto.Id, resultProducto.Id);
        }

        [TestMethod()]
        public async Task T5ObtenerTodosAsyncTest()
        {
            var resultProducto = await ProductoDAL.ObtenerTodosAsync();
            Assert.AreNotEqual(0, resultProducto.Count);
        }

        [TestMethod()]
        public async Task T6BuscarAsyncTestAsync()
        {

            var producto = new Producto();
            producto.IdCategoria = productoInicial.IdCategoria;
            producto.IdConsola = productoInicial.IdConsola;
            producto.Nombre = "A";
            producto.Descripcion = "a";
            producto.Cantidad = "a";
            producto.Precio = "a";
            producto.Imagen = "a";
            var resultProducto = await ProductoDAL.BuscarAsync(producto);
            Assert.AreNotEqual(0, resultProducto.Count);
        }
    }
}