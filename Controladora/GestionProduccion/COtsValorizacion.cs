using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccesoDatos.NoTransaccional.GestionProduccion;

namespace Controladora.GestionProduccion
{
    public class COtsValorizacion
    {
        public DataTable ListarTodos(int Centro, string CodigoDivision, string FechaIni, string FechaFin, int NOT, string UserName)
        {
            return (new OtsValorizacionNTAD()).ListarTodos(Centro, CodigoDivision, FechaIni, FechaFin, NOT, UserName);
        }

        public DataTable Lista_Valorizacion_OT_Callao(string sCentro, string sCodigoDivision, string sFechaIni, string sFechaFin, string UserName)
        {
            return (new OtsValorizacionNTAD()).Lista_Valorizacion_OT_Callao(sCentro, sCodigoDivision, sFechaIni, sFechaFin, UserName);
        }
    }
}
