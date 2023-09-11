using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoDa.EntidadesDeNegocio;

namespace VideoDa.AccesoADatos
{
    public class EmpleadoDAL
    {
        public static async Task<int> CrearAsync(Empleado pEmpleado)
        {
            int result = 0;
            using (var bdContexto = new BDContexto())
            {
                bdContexto.Add(pEmpleado);
                result = await bdContexto.SaveChangesAsync();
            }
            return result;
        }

        public static async Task<int> ModificarAsync(Empleado pEmpleado)
        {
            int result = 0;
            using (var bdContexto = new BDContexto())
            {
                var empleado = await bdContexto.Empleados.FirstOrDefaultAsync(s => s.Id == pEmpleado.Id);
                empleado.IdRol = pEmpleado.IdRol;
                empleado.Nombre = pEmpleado.Nombre;
                empleado.Apellido = pEmpleado.Apellido;
                empleado.Edad = pEmpleado.Edad;
                empleado.Telefono = pEmpleado.Telefono;
                empleado.Dui = pEmpleado.Dui;
                empleado.Correo = pEmpleado.Correo;
                empleado.Direccion = pEmpleado.Direccion;
                empleado.Departamento = pEmpleado.Departamento;
                bdContexto.Update(empleado);
                result = await bdContexto.SaveChangesAsync();
            }
            return result;
        }

        public static async Task<int> EliminarAsync(Empleado pEmpleado)
        {
            int result = 0;
            using (var bdContexto = new BDContexto())
            {
                var empleado = await bdContexto.Empleados.FirstOrDefaultAsync(s => s.Id == pEmpleado.Id);
                bdContexto.Empleados.Remove(empleado);
                result = await bdContexto.SaveChangesAsync();
            }
            return result;
        }

        public static async Task<Empleado> ObtenerPorIdAsync(Empleado pEmpleado)
        {
            var empleado = new Empleado();
            using (var bdContexto = new BDContexto())
            {
                empleado = await bdContexto.Empleados.FirstOrDefaultAsync(s => s.Id == pEmpleado.Id);
            }
            return empleado;
        }

        public static async Task<List<Empleado>> ObtenerTodosAsync()
        {
            var empleados = new List<Empleado>();
            using (var bdContexto = new BDContexto())
            {
                empleados = await bdContexto.Empleados.ToListAsync();
            }
            return empleados;
        }

        internal static IQueryable<Empleado> QuerySelect(IQueryable<Empleado> pQuery, Empleado pEmpleado)
        {
            if (pEmpleado.Id > 0)
                pQuery = pQuery.Where(s => s.Id == pEmpleado.Id);

            if (pEmpleado.IdRol > 0)
                pQuery = pQuery.Where(s => s.IdRol == pEmpleado.IdRol);

            if (!string.IsNullOrWhiteSpace(pEmpleado.Nombre))
                pQuery = pQuery.Where(s => s.Nombre.Contains(pEmpleado.Nombre));
            if (!string.IsNullOrWhiteSpace(pEmpleado.Apellido))
                pQuery = pQuery.Where(s => s.Apellido.Contains(pEmpleado.Apellido));
            if (!string.IsNullOrWhiteSpace(pEmpleado.Edad))
                pQuery = pQuery.Where(s => s.Edad.Contains(pEmpleado.Edad));
            if (!string.IsNullOrWhiteSpace(pEmpleado.Telefono))
                pQuery = pQuery.Where(s => s.Telefono.Contains(pEmpleado.Telefono));
            if (!string.IsNullOrWhiteSpace(pEmpleado.Dui))
                pQuery = pQuery.Where(s => s.Dui.Contains(pEmpleado.Dui));
            if (!string.IsNullOrWhiteSpace(pEmpleado.Correo))
                pQuery = pQuery.Where(s => s.Correo.Contains(pEmpleado.Correo));
            if (!string.IsNullOrWhiteSpace(pEmpleado.Direccion))
                pQuery = pQuery.Where(s => s.Direccion.Contains(pEmpleado.Direccion));
            if (!string.IsNullOrWhiteSpace(pEmpleado.Departamento))
                pQuery = pQuery.Where(s => s.Departamento.Contains(pEmpleado.Departamento));
            pQuery = pQuery.OrderByDescending(s => s.Id).AsQueryable();

            if (pEmpleado.Top_Aux > 0)
                pQuery = pQuery.Take(pEmpleado.Top_Aux).AsQueryable();

            return pQuery;
        }

        public static async Task<List<Empleado>> BuscarAsync(Empleado pEmpleado)
        {
            var empleados = new List<Empleado>();
            using (var bdContexto = new BDContexto())
            {
                var select = bdContexto.Empleados.AsQueryable();
                select = QuerySelect(select, pEmpleado);
                empleados = await select.ToListAsync();
            }
            return empleados;
        }
    }
}
