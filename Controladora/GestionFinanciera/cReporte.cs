using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccesoDatos.NoTransaccional.GestionFinanciera;

namespace Controladora.GestionFinanciera
{
    public class cReporte
    {
        public DataTable GenRptAnexosFinanciero(int IdFormato, int Periodo, string RangoMes, int IdUsuario,
            string UserName)
        {
            return (new Reportes()).GenRptAnexosFinanciero(IdFormato, Periodo, RangoMes, IdUsuario,
                UserName);
        }

        public DataTable GenRptAnexosFiltro(string IdProceso, string UserName)
        {
            return (new Reportes()).GenRptAnexosFiltro(IdProceso, UserName);
        }
    }
}
