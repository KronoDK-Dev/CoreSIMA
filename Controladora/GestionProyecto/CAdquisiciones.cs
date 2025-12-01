using AccesoDatos.NoTransaccional.GestionProyecto;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controladora.GestionProyecto
{
    public class CAdquisiciones
    {
        public DataTable Listar_det_gasto_pry_ot_pgmsu(string V_CENTRO_OPERATIVO, string V_DIVISION, string V_PROYECTO, string UserName)
        {
            return (new AdquisicionesNTAD()).Listar_det_gasto_pry_ot_pgmsu(V_CENTRO_OPERATIVO, V_DIVISION, V_PROYECTO, UserName);
        }
    }
}
