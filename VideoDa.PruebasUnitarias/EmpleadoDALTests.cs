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
    public class EmpleadoDALTests
    {
        private static Empleado empleadoInicial = new Empleado { Id = 2, IdRol = 2 };
        [TestMethod()]
        public async Task T1CrearAsyncTest()
        {
            var empleado = new Empleado();
            empleado.IdRol = empleadoInicial.IdRol;
            empleado.Nombre = "Juan";
            empleado.Apellido = "Jose";
            empleado.Edad = "20";
            empleado.Telefono = "70117741";
            empleado.Dui = "06452899-7";
            empleado.Correo = "dfer4738@gmail.com";
            empleado.Direccion = "Armenia";
            empleado.Departamento = "Sonsonate";
            int result = await EmpleadoDAL.CrearAsync(empleado);
            Assert.AreNotEqual(0, result);
            empleadoInicial.Id = empleado.Id;
        }

        [TestMethod()]
        public async Task T2ModificarAsyncTest()
        {
            var empleado = new Empleado();
            empleado.Id = empleadoInicial.Id;
            empleado.IdRol = empleadoInicial.IdRol;
            empleado.Nombre = "Juancito";
            empleado.Apellido = "Jose";
            empleado.Edad = "20";
            empleado.Telefono = "70117743";
            empleado.Dui = "06452899-7";
            empleado.Correo = "dfer4738@gmail.com";
            empleado.Direccion = "Armenia";
            empleado.Departamento = "Sonsonate";
            int result = await EmpleadoDAL.ModificarAsync(empleado);
            Assert.AreNotEqual(0, result);
        }

        [TestMethod()]
        public async Task T3EliminarAsyncTest()
        {
            var empleado = new Empleado();
            empleado.Id = empleadoInicial.Id;
            int result = await EmpleadoDAL.EliminarAsync(empleado);
            Assert.AreNotEqual(0, result);
        }

        [TestMethod()]
        public async Task T4ObtenerPorIdAsyncTest()
        {
            var empleado = new Empleado();
            empleado.Id = empleadoInicial.Id;
            var resultEmpleado = await EmpleadoDAL.ObtenerPorIdAsync(empleado);
            Assert.AreEqual(empleado.Id, resultEmpleado.Id);
        }

        [TestMethod()]
        public async Task T5ObtenerTodosAsyncTest()
        {
            var resultEmpleado = await EmpleadoDAL.ObtenerTodosAsync();
            Assert.AreNotEqual(0, resultEmpleado.Count);
        }

        [TestMethod()]
        public async Task T6BuscarAsyncTest()
        {
            var empleado = new Empleado();
            empleado.IdRol = empleadoInicial.IdRol;
            empleado.Nombre = "A";
            empleado.Apellido = "a";
            empleado.Edad = "a";
            empleado.Telefono = "a";
            empleado.Dui = "a";
            empleado.Correo = "a";
            empleado.Direccion = "a";
            empleado.Departamento = "a";
            empleado.Top_Aux = 10;
            var resultEmpleado = await EmpleadoDAL.BuscarAsync(empleado);
            Assert.AreNotEqual(0, resultEmpleado.Count);

        }
    }
}