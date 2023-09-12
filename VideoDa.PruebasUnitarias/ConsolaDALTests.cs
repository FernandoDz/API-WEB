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
    public class ConsolaDALTests
    {
        private static Consola consolaInicial = new Consola { Id = 2 };
        [TestMethod()]
        public async Task T1CrearAsyncTest()
        {
            var consola = new Consola();
            consola.Id = consolaInicial.Id;
            consola.Nombre = "PlayStation 4";
            consola.Descripcion = "Consola de videojuegos para disfrutar con tu familia";
            consola.Serie = "2001";
            consola.Imagen = "ps4.png";
            consola.Fabricante = "Sony";
            consola.AñodeLanzamiento = "2014";
            int result = await ConsolaDAL.CrearAsync(consola);
            Assert.AreNotEqual(0, result);
            consolaInicial.Id = consola.Id;
        }

        [TestMethod()]
        public async Task T2ModificarAsyncTest()
        {
            var consola = new Consola();
            consola.Id = consolaInicial.Id;
            consola.Nombre = "PlayStation 4";
            consola.Descripcion = "Consola de videojuegos para disfrutar con tu familia";
            consola.Serie = "2001";
            consola.Imagen = "ps4.png";
            consola.Fabricante = "Sony";
            consola.AñodeLanzamiento = "2014";
            int result = await ConsolaDAL.ModificarAsync(consola);
            Assert.AreNotEqual(0, result);
        }
        [TestMethod()]
        public async Task T3EliminarAsyncTest()
        {
            var consola = new Consola();
            consola.Id = consolaInicial.Id;
            int result = await ConsolaDAL.EliminarAsync(consola);
            Assert.AreNotEqual(0, result);
        }
        [TestMethod()]
        public async Task T4ObtenerPorIdAsyncTest()
        {
            var consola = new Consola();
            consola.Id = consolaInicial.Id;
            var resultconsola = await ConsolaDAL.ObtenerPorIdAsync(consola);
            Assert.AreEqual(consola.Id, resultconsola.Id);
        }

        [TestMethod()]
        public async Task T5ObtenerTodosAsyncTest()
        {
            var resultconsola = await ConsolaDAL.ObtenerTodosAsync();
            Assert.AreNotEqual(0, resultconsola.Count);
        }

        [TestMethod()]
        public async Task T6BuscarAsyncTest()
        {
            var consola = new Consola();
            consola.Id = consolaInicial.Id;
            consola.Nombre = "A";
            consola.Descripcion = "a";
            consola.Serie = "a";
            consola.Imagen = "a";
            consola.Fabricante = "a";
            consola.AñodeLanzamiento = "a";
            consola.Top_Aux = 10;
            var resultconsola = await ConsolaDAL.BuscarAsync(consola);
            Assert.AreNotEqual(0, resultconsola.Count);

        }
    }
}