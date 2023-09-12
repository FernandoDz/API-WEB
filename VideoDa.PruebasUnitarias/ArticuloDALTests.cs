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
    public class ArticuloDALTests
    {
        private static Articulo articuloInicial = new Articulo { Id = 2, IdConsola = 2 };
        [TestMethod()]
        public async Task T1CrearAsyncTest()
        {
            var articulo = new Articulo();
            articulo.IdConsola = articuloInicial.IdConsola;
            articulo.Nombre = "Jack and Daxter III";
            articulo.Imagen = "JackIII.png";
            articulo.Descripcion = "Es un juego de accion  y aventura donde exploraras al limite junto a tu mejor amigo Daxter";
            int result = await ArticuloDAL.CrearAsync(articulo);
            Assert.AreNotEqual(0, result);
            articuloInicial.Id = articulo.Id;
        }
        [TestMethod()]
        public async Task T2ModificarAsyncTest()
        {
            var articulo = new Articulo();
            articulo.Id = articuloInicial.Id;
            articulo.IdConsola = articuloInicial.IdConsola;
            articulo.Nombre = "Jack and Daxter III";
            articulo.Imagen = "JackIII.png";
            articulo.Descripcion = "Es un juego de accion  y aventura donde exploraras al limite junto a tu mejor amigo Daxter";
            int result = await ArticuloDAL.ModificarAsync(articulo);
            Assert.AreNotEqual(0, result);
        }

        [TestMethod()]
        public async Task T3EliminarAsyncTest()
        {
            var articulo = new Articulo();
            articulo.Id = articuloInicial.Id;
            int result = await ArticuloDAL.EliminarAsync(articulo);
            Assert.AreNotEqual(0, result);
        }

        [TestMethod()]
        public async Task T4ObtenerPorIdAsyncTest()
        {
            var articulo = new Articulo();
            articulo.Id = articuloInicial.Id;
            var resultArticulo = await ArticuloDAL.ObtenerPorIdAsync(articulo);
            Assert.AreEqual(articulo.Id, resultArticulo.Id);
        }

        [TestMethod()]
        public async Task T5ObtenerTodosAsyncTest()
        {
            var resultArticulo = await ArticuloDAL.ObtenerTodosAsync();
            Assert.AreNotEqual(0, resultArticulo.Count);
        }

        [TestMethod()]
        public async Task T6BuscarAsyncTest()
        {
            var articulo = new Articulo();
            articulo.IdConsola = articuloInicial.IdConsola;
            articulo.Nombre = "A";
            articulo.Imagen = "a";
            articulo.Descripcion = "a";
            articulo.Top_Aux = 10;
            var resultarticulo = await ArticuloDAL.BuscarAsync(articulo);
            Assert.AreNotEqual(0, resultarticulo.Count);

        }
    }
}