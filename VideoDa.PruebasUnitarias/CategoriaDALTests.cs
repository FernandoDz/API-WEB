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
    public class CategoriaDALTests
    {
        private static Categoria categoriaInicial = new Categoria { Id = 2 };

        [TestMethod()]
        public async Task T1CrearAsyncTest()
        {
            var categoria = new Categoria();
            categoria.Nombre = "Producto";
            int result = await CategoriaDAL.CrearAsync(categoria);
            Assert.AreNotEqual(0, result);
            categoriaInicial.Id = categoria.Id;
        }

        [TestMethod()]
        public async Task T2ModificarAsyncTestAsync()
        {
            var categoria = new Categoria();
            categoria.Id = categoriaInicial.Id;
            categoria.Nombre = "Prod";
            int result = await CategoriaDAL.ModificarAsync(categoria);
            Assert.AreNotEqual(0, result);
        }

        [TestMethod()]
        public async Task T3EliminarAsyncTestAsync()
        {
            var categoria = new Categoria();
            categoria.Id = categoriaInicial.Id;
            int result = await CategoriaDAL.EliminarAsync(categoria);
            Assert.AreNotEqual(0, result);
        }

        [TestMethod()]
        public async Task T4ObtenerPorIdAsyncTest()
        {
            var categoria = new Categoria();
            categoria.Id = categoriaInicial.Id;
            var resultCategoria = await CategoriaDAL.ObtenerPorIdAsync(categoria);
            Assert.AreEqual(categoria.Id, resultCategoria.Id);
        }

        [TestMethod()]
        public async Task T5ObtenerTodosAsyncTest()
        {
            var resultCategoria = await CategoriaDAL.ObtenerTodosAsync();
            Assert.AreNotEqual(0, resultCategoria.Count);
        }

        [TestMethod()]
        public async Task T6BuscarAsyncTestAsync()
        {
            var categoria = new Categoria();
            categoria.Nombre = "a";
            categoria.Top_Aux = 10;
            var resultCategoria = await CategoriaDAL.BuscarAsync(categoria);
            Assert.AreNotEqual(0, resultCategoria.Count);
        }
    }
}