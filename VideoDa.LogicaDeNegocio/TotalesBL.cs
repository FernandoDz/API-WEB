using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoDa.AccesoADatos;
using VideoDa.EntidadesDeNegocio;

namespace VideoDa.LogicaDeNegocio
{
    public class TotalesBL
    {
        public async Task<Totales> ObtenerTotalesAsync()
        {
            return await TotalesDAL.ObtenerTotalesAsync();
        }

    }
}
