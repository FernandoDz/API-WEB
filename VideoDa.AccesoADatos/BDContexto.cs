using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//namespace
using VideoDa.EntidadesDeNegocio;
using Microsoft.EntityFrameworkCore;

namespace VideoDa.AccesoADatos
{
    public class BDContexto : DbContext
    {

        public DbSet<Articulo> Articulos { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Consola> Consolas { get; set; }
        public DbSet<Empleado> Empleados { get; set; }

        public DbSet<Producto> Productos { get; set; }
        public DbSet<Rol> Roles { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer(@"Data source = DESKTOP-5D189V7;
           Initial Catalog = VideoDaBD;

          Integrated Security =True");
        }

    }
}
